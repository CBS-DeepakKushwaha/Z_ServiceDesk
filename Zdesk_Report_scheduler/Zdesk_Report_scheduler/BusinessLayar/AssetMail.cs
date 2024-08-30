using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Zdesk_Report_scheduler.BusinessLayar
{
    public class AssetMail
    {
        SmtpClient client = new SmtpClient();
        public string ConnectionString = "";
        string FilePath = "";
        string FromMail = "";
        SqlConnection connstr;
        public AssetMail(int port, string Host, string fromEmail, string Password, string Connection, string _FilePath)
        {
            client.Port = port;
            client.Host = Host;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(fromEmail, Password);
            ConnectionString = Connection;
            FilePath = _FilePath;
            FromMail = fromEmail;
            connstr = new SqlConnection(Connection);
        }

        public bool AssetMailProcess()
        {

            foreach (var v in PendingUserList())
            {
                try
                {
                    if (v.Is_acknowledgeMailCount == 3)
                    {
                        SendAcknoledgeMail(v);
                        Updateis_acknowledge(v.asset_id_pk);
                    }
                    else
                    {
                        sendWarraningMail(v);
                    }
                }
                catch (Exception ex)
                {
                    File.AppendAllLines(@"C:\Service\AssetMailLog.txt", new string[] { "Error :" + ex.Message });
                }

            }

            return true;
        }
        public List<AssetMailModel> PendingUserList()
        {
            List<AssetMailModel> list = new List<AssetMailModel>();
            string Query1 = "asset_tbl_acknowledge_Mail";
            SqlDataAdapter cmd1 = new SqlDataAdapter(Query1, connstr);
            cmd1.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable Dt = new DataTable();
            cmd1.Fill(Dt);

            foreach (DataRow dr in Dt.Rows)
            {
                list.Add(new AssetMailModel
                {
                    Client_name = dr["Client_name"].ToString(),
                    asset_cat_name = dr["asset_cat_name"].ToString(),
                    asset_tag = dr["asset_tag"].ToString(),
                    model_name = (dr["model_name"].ToString()),
                    serial_number = (dr["serial_number"].ToString()),
                    email = (dr["email"].ToString()),
                    user_name = (dr["user_name"].ToString()),
                    asset_id_pk = Convert.ToInt32(dr["asset_id_pk"].ToString()),
                    Is_acknowledgeMailCount = Convert.ToInt32(dr["Is_acknowledgeMailCount"].ToString()),

                });


            }
            File.AppendAllLines(@"C:\Service\AssetMailLog.txt", new string[] { "Total No of Count:" + list.Count() });
            return list;


        }

        public void Updateis_acknowledge(int AssetId)
        {
            string Query1 = @"update zdesk_m_asset_tbl set is_acknowledge=2,
                                Is_acknowledgeMailCount=Is_acknowledgeMailCount+1
                               where asset_id_pk=@asset_id_pk";
            SqlCommand cmd1 = new SqlCommand(Query1, connstr);
            cmd1.Parameters.AddWithValue("@asset_id_pk", AssetId);
            connstr.Open();
            cmd1.ExecuteNonQuery();
            connstr.Close();

        }

        public void SendAcknoledgeMail(AssetMailModel model)
        {
            using (MailMessage user = new MailMessage(FromMail, model.email))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 34;
                t = gettemplate(t.id ?? default(int));
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$AssetID$$", model.asset_id_pk.ToString());
                myString = myString.Replace("$$Category$$", model.asset_cat_name);
                myString = myString.Replace("$$Make$$", model.model_name);
                myString = myString.Replace("$$Model$$", model.model_name);
                myString = myString.Replace("$$SerialNo$$", model.serial_number);
                user.Subject = "Reminder : " + t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);

            }

        }
        public void sendWarraningMail(AssetMailModel model)
        {
            string username = userName(model.email);
            using (MailMessage user = new MailMessage(FromMail, model.email))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 18;
                t = gettemplate(t.id ?? default(int));
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$User$$", username);
                myString = myString.Replace("$$AssetID$$", model.asset_id_pk.ToString());
                myString = myString.Replace("$$Category$$", model.asset_cat_name);
                myString = myString.Replace("$$Make$$", model.model_name);
                myString = myString.Replace("$$Model$$", model.model_name);
                myString = myString.Replace("$$SerialNo$$", model.serial_number);
                user.Subject = "Reminder : " + t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);

            }
        }
        public EmailTemplateModel gettemplate(int? id)
        {
            EmailTemplateModel emailTemplateModel = new EmailTemplateModel();
            string Query1 = "efp_get_template_sp";
            SqlDataAdapter cmd1 = new SqlDataAdapter(Query1, connstr);
            cmd1.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd1.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable Dt = new DataTable();
            cmd1.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                emailTemplateModel.Description = (Dt.Rows[0]["Description"].ToString());
                emailTemplateModel.name = (Dt.Rows[0]["name"].ToString());
                emailTemplateModel.subject = (Dt.Rows[0]["subject"].ToString());
                emailTemplateModel.Template = (Dt.Rows[0]["Template"].ToString());
            }

            return emailTemplateModel;

        }
        public bool SmtpSend(MailMessage message)
        {
            client.Send(message);
            return true;

        }
        public string userName(string email)
        {
            string user = string.Empty;
            string Query1 = "select user_name from zdesk_m_users_tbl where email='"+email+"'";
            SqlCommand cmd1 = new SqlCommand(Query1, connstr);
            connstr.Open();
            user = cmd1.ExecuteScalar().ToString();
            connstr.Close();
            return user;

        }
    }
}
