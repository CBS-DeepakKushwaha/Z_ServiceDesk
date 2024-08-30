using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zdesk_Report_scheduler.BusinessLayar
{
    public class HWChange
    {
        SmtpClient client = new SmtpClient();
        public string ConnectionString = "";
        string FilePath = "";
        string FromMail = "";
        SqlConnection connstr;
        public HWChange(int port, string Host, string fromEmail, string Password, string Connection, string _FilePath)
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

        public bool HWMailProcess()
        {

            foreach (var v in PendingUserList())
            {
                try
                {
                    SendAcknoledgeMail(v);
                    UpdateNotify(v.hw_audit_id_pk);
                }
                catch (Exception ex)
                {
                    File.AppendAllLines(Assembly.GetEntryAssembly().Location.ToString() + "\\HWMailLog.txt", new string[] { "Error :" + ex.Message });
                }

            }
            return true;
        }
        public List<HW_Audit> PendingUserList()
        {
            List<HW_Audit> list = new List<HW_Audit>();
            string Query1 = @"select h.*,ISNULL(a.asset_tag,'N/A') as asset_tag from zdesk_m_hardware_audit_tbl h left join zdesk_m_fixed_assets_mapping_tbl m with(nolock) on m.serial_no = h.serial left join zdesk_m_asset_tbl a with(nolock) on a.asset_id_pk = m.asset_id_pk where is_notify = 0";
            SqlDataAdapter cmd1 = new SqlDataAdapter(Query1, connstr);
            DataTable Dt = new DataTable();
            cmd1.Fill(Dt);

            foreach (DataRow dr in Dt.Rows)
            {
                list.Add(new HW_Audit
                {
                    hw_audit_id_pk = Convert.ToInt32(dr["hw_audit_id_pk"]),
                    serial = dr["serial"].ToString(),
                    old_value = dr["old_value"].ToString(),
                    new_value = (dr["new_value"].ToString()),
                    field = (dr["field"].ToString()),
                    created_date = (dr["created_date"].ToString()),
                    asset_tag = (dr["asset_tag"].ToString())
                });
            }
            File.AppendAllLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\HWMailLog.txt", new string[] { "Total No of Count:" + list.Count() + Environment.NewLine });
            return list;
        }

        public void UpdateNotify(int AssetId)
        {
            string Query1 = @"update zdesk_m_hardware_audit_tbl set is_notify = 1 where hw_audit_id_pk = @hw_audit_id_pk";
            SqlCommand cmd1 = new SqlCommand(Query1, connstr);
            cmd1.Parameters.AddWithValue("@hw_audit_id_pk", AssetId);
            connstr.Open();
            cmd1.ExecuteNonQuery();
            connstr.Close();

        }

        public void SendAcknoledgeMail(HW_Audit model)
        {
            using (MailMessage user = new MailMessage(FromMail, ConfigurationManager.AppSettings["HWChange"].ToString()))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 35;
                string cc = string.Empty;
                if(ConfigurationManager.AppSettings["CC_Change"].ToString() != null)
                {
                    cc = ConfigurationManager.AppSettings["CC_Change"].ToString();
                    user.CC.Add(cc);
                }
                t = gettemplate(t.id ?? default(int));
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$AssetTag$$", model.asset_tag.ToString());
                myString = myString.Replace("$$Serial$$", model.serial);
                myString = myString.Replace("$$Field$$", model.field);
                myString = myString.Replace("$$OldValue$$", model.old_value);
                myString = myString.Replace("$$NewValue$$", model.new_value);
                myString = myString.Replace("$$DateTime$$", model.created_date);
                user.Subject = t.subject;
                myString = getorgInfoConfiguration(myString);
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
            }
        }
        public string getorgInfoConfiguration(string value)
        {
            EmailTemplateModel emailTemplateModel = new EmailTemplateModel();
            string Query1 = "select * from Zdesk_m_organization_Info_tbl";
            SqlDataAdapter cmd1 = new SqlDataAdapter(Query1, connstr);
            DataTable Dt = new DataTable();
            cmd1.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {               
                value = value.Replace("$$image$$", Dt.Rows[0]["logo"].ToString());
                value = value.Replace("$$OrgName$$", Dt.Rows[0]["OrganizationName"].ToString());
                value = value.Replace("$$Address$$", Dt.Rows[0]["Address"].ToString());
                value = value.Replace("$$Email$$", Dt.Rows[0]["ApplicationAdmin"].ToString());
            }
            return value;
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
    }
}
