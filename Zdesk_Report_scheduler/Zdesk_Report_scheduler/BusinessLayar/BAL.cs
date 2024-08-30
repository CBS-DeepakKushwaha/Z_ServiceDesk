using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Zdesk_Report_scheduler.BusinessLayar
{
   public class BAL
    {
        SmtpClient client = new SmtpClient();
        public string ConnectionString = "";
        string FilePath = "";
        string FromMail = "";
        SqlConnection connstr;
        int totalreport = 0;
        public BAL(int port,string Host,string fromEmail,string Password,string Connection,string _FilePath)
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
            connstr= new SqlConnection(Connection);
        }
        public static string GetConnection()
        {
            string Connection = "";
            string filePath = @"C:\Service\ConnectionString.txt";
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        while (sr.Peek() > 0)
                        {
                            string ss = sr.ReadLine();
                            string[] textsplit = ss.Split(';');
                            string ServerName = textsplit[0].ToString();
                            string DataBase = textsplit[1].ToString();
                            string UserId = textsplit[2].ToString();
                            string Password = textsplit[3].ToString();
                            Connection = ServerName + ";" + DataBase + ";" + UserId + ";" + Password;
                        }
                    }
                }
                return Connection;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        
        public bool ReportGenerate()
        {

            foreach(var v in TempleteList())
            {
                string[] lines = new string[] { DateTime.Now.ToString() + "total Record---" + totalreport + "Current RowId---"+v.Id };
                File.AppendAllLines(@"C:\Service\ZdeskLogSGRLReport.txt", lines);

                var Path = GenerateReport(v.ReportId);
                MailAddress obj = new MailAddress(FromMail);
                sendEmail(obj, v.EmailTo, v.Subject, "Please find the attached Report.", v.EmailCC, "", Path);
            }
            return true;
        }

        public List<ReportSchedulerModel> TempleteList()
        {
            string[] lines = new string[] { DateTime.Now.ToString() + " -- Template List Sp Execute" };
            File.AppendAllLines(@"C:\Service\ZdeskLogSGRLReport.txt", lines);
            List<ReportSchedulerModel> list = new List<ReportSchedulerModel>();
            //string Query1 = "select  * from dbo.zdesk_m_Report_s_tbl_scheduler where cast(Time as datetime)>= cast(cast(dateadd(mi,-10,getdate()) as time) as datetime) and cast(Time as datetime)< cast(cast(getdate() as time) as datetime)";
            //SqlDataAdapter cmd1 = new SqlDataAdapter(Query1, connstr);
            //string Query1 = "select  * from dbo.zdesk_m_Report_s_tbl_scheduler where cast(Time as datetime)>= cast(cast(dateadd(mi,-10,getdate()) as time) as datetime) and cast(Time as datetime)< cast(cast(getdate() as time) as datetime)";
            string Query1 = "Report_Schedular_Mail";
            SqlDataAdapter cmd1 = new SqlDataAdapter(Query1, connstr);
            cmd1.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable Dt = new DataTable();
            cmd1.Fill(Dt);

            foreach(DataRow dr in Dt.Rows)
            {
                list.Add(new ReportSchedulerModel
                {
                    EmailCC=dr["EmailCC"].ToString(),
                    EmailTo=dr["EmailTo"].ToString(),
                    Subject=dr["Subject"].ToString(),
                    Id=Convert.ToInt16(dr["id"].ToString()),
                    ReportId= Convert.ToInt16(dr["ReportId"].ToString()),
                    schedulerTypeId= Convert.ToInt16(dr["schedulerTypeId"].ToString()),
                    
                });

                
            }
            totalreport = list.Count();
            return list;


        }

        public string GenerateReport(int ReportID)
        {

            string ColumnName = "";
            string where = "";
            int ReportType = 0;
            
            string Query1 = "zdesk_Get_Report_Template";
            SqlDataAdapter cmd1 = new SqlDataAdapter(Query1, connstr);
            cmd1.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd1.SelectCommand.Parameters.AddWithValue("@Id", ReportID);

            DataTable Dt = new DataTable();
            cmd1.Fill(Dt);
            if (!String.IsNullOrEmpty(Dt.Rows[0]["ReportId"].ToString()))
            {
                ReportType = Convert.ToInt32(Dt.Rows[0]["ReportId"].ToString());
            }
           
            if (ReportType == 3)
            {
              return   AssetReport(Dt);
            }
            if (ReportType == 5)
            {
                return ProblemReport(Dt);
            }
            if (ReportType == 6)
            {
                return ChangeReport(Dt);
            }
            if (ReportType == 7)
            {
                return TaskReport(Dt);
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["ColumnName"].ToString()))
            {
                ColumnName = Dt.Rows[0]["ColumnName"].ToString();
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["client_id_pk"].ToString()))
            {
                where += " and  t.client_id_pk in (" + Dt.Rows[0]["client_id_pk"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["common_cat_id_pk"].ToString()))
            {
                where += " and t.common_cat_id_pk in (" + Dt.Rows[0]["common_cat_id_pk"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["location_id_fk"].ToString()))
            {
                where += " and t.location_id_fk in (" + Dt.Rows[0]["location_id_fk"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["priority_id_pk"].ToString()))
            {
                where += " and t.priority_id_pk in (" + Dt.Rows[0]["priority_id_pk"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["sub_category_id"].ToString()))
            {
                where += " and t.sub_category_id in (" + Dt.Rows[0]["sub_category_id"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["support_dep_id_pk"].ToString()))
            {
                where += " and t.support_dep_id_pk in (" + Dt.Rows[0]["support_dep_id_pk"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["ticket_status_id_pk"].ToString()))
            {
                where += " and t.ticket_status_id_pk in (" + Dt.Rows[0]["ticket_status_id_pk"].ToString() + ")";
            }
            if (Dt.Rows[0]["Range"].ToString() != "0")
            {
                DateTime from = Convert.ToDateTime(Dt.Rows[0]["from_date"]);
                DateTime to = Convert.ToDateTime(Dt.Rows[0]["to_date"]);
                string FromData = "'" + from.ToString("MM-dd-yyyy") + "'";
                string toData = "'" + to.ToString("MM-dd-yyyy") + "'";
                where += " and convert(date, t.created_date) >= convert(Date, " + FromData + ") and convert(date, t.created_date) <= convert(date, " + toData + ")";
            }
            else
            {
                where += " and convert(date, t.created_date)=convert(date, getdate())";
            }

            if (ReportType==1)
            {
                where += " order by t.created_date asc DROP TABLE #TicketResolutionRecord";
                //string Query = "zdesk_Get_Report_Generate";
                string Query = "zdesk_Get_Report_Generate1"; //By COlumn filter
                SqlDataAdapter cmd = new SqlDataAdapter(Query, connstr);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@ColumnName", ColumnName);
                cmd.SelectCommand.Parameters.AddWithValue("@where", where);
                // cmd1.SelectCommand.Parameters.AddWithValue("@ReportType", ReportType);

                DataTable DtReport = new DataTable();
                cmd.Fill(DtReport);
                string Path = ExportData(DtReport, "Report");
                return Path;
            }
            else if(ReportType ==2)
            {
                string Query = "zdesk_Get_Report_ServiceRequest_Generate";
                SqlDataAdapter cmd = new SqlDataAdapter(Query, connstr);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@ColumnName", ColumnName);
                cmd.SelectCommand.Parameters.AddWithValue("@where", where);
                
                DataTable DtReport = new DataTable();
                cmd.Fill(DtReport);
                string Path = ExportData(DtReport, "Report");
                return Path;
            }
            
            else if(ReportType==4)
            {
                string Query = "zdesk_get_ticket_workload_notification_sp";
                SqlDataAdapter cmd = new SqlDataAdapter(Query, connstr);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;           
                DataTable DtReport = new DataTable();
                cmd.Fill(DtReport);
                string Path = ExportData(DtReport, "Report");
                return Path;
            }
            else
            {
                return string.Empty;
            }
            

        }

        public string AssetReport(DataTable Dt)
        {
            string ColumnName = "";
            string where = "";

            if (!String.IsNullOrEmpty(Dt.Rows[0]["pass_id"].ToString()))
            {
                ColumnName =
                     "declare @asset varchar(max)='';" +
                     "select asset_id into #temp2 from zdesk_m_gate_pass_tbl where gate_pass_id_pk in (" + Dt.Rows[0]["pass_id"].ToString() + ");" +
                     "select @asset = coalesce(@asset + ',', '') + asset_id from #temp2;" +
                     "select @asset = stuff(@asset, 1, 0, '');" +
                     "drop table #temp2;";
                where += "and (a.asset_id_pk in (select CAST(Item as int) as owner_flag from dbo.SplitString(@asset,',')) or @asset is null)";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["client_id_pk"].ToString()))
            {
                where += " and a.client_id_fk in (" + Dt.Rows[0]["client_id_pk"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["Asset_Category"].ToString()))
            {
                where += " and a.asset_category_id_fk in (" + Dt.Rows[0]["Asset_Category"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["manufacture"].ToString()))
            {
                where += " and a.manufacturer_name in ('" + Dt.Rows[0]["manufacture"].ToString() + "')";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["asset_category_id_pk"].ToString()))
            {
                where += " and ac.asset_category_id_pk in (" + Dt.Rows[0]["asset_category_id_pk"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["model"].ToString()))
            {
                where += " and a.model_name in ('" + Dt.Rows[0]["model"].ToString() + "')";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["serial_no"].ToString()))
            {
                where += " and a.serial_number in ('" + Dt.Rows[0]["serial_no"].ToString() + "')";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["location_id_fk"].ToString()))
            {
                where += " and a.location_id_pk in (" + Dt.Rows[0]["location_id_fk"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["sub_location_id"].ToString()))
            {
                where += " and a.sub_location_id_fk in (" + Dt.Rows[0]["sub_location_id"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["vandor"].ToString()))
            {
                where += " and a.supplier_id_pk in (" +Dt.Rows[0]["vandor"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["condition_id_fk"].ToString()))
            {
                where += " and a.condition_id_fk in (" + Dt.Rows[0]["condition_id_fk"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["asset_support_id"].ToString()))
            {
                where += " and a.support_type in (" + Dt.Rows[0]["asset_support_id"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["po_number"].ToString()))
            {
                where += " and a.po_num in ('" + Dt.Rows[0]["po_number"].ToString() + "')";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["invoice_number"].ToString()))
            {
                where += " and a.invoice_no in ('" + Dt.Rows[0]["invoice_number"].ToString() + "')";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["pass_status"].ToString()))
            {
                where += "and a.gate_pass_status in (" + Dt.Rows[0]["pass_status"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["cost"].ToString()))
            {
                where += "and a.cc_id_fk in (" + Dt.Rows[0]["cost"].ToString() + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["ddlAssetToBeCollected"].ToString()))
            {
                where += "and Convert(date, u.resign_date) between Convert(date, getdate()) and Convert(date, DATEADD(DAY," + Convert.ToInt32(Dt.Rows[0]["ddlAssetToBeCollected"].ToString()) + ",getdate()))";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["warranty_end_id"].ToString()) && (Dt.Rows[0]["warranty_end_id"].ToString()!="0"))
            {
                string Datefrom = "'" +Convert.ToDateTime(Dt.Rows[0]["warranty_end_from"].ToString()).ToString("MM-dd-yyyy") + "'";
                string Dateto = "'" + Convert.ToDateTime(Dt.Rows[0]["warranty_end_to"].ToString()).ToString("MM-dd-yyyy")  + "'";
                where += " and a.warranty_end_date >= (" + Datefrom + ") and a.warranty_end_date <= (" + Dateto + ")";
            }
            if (!String.IsNullOrEmpty(Dt.Rows[0]["amc_end_id"].ToString()) && (Dt.Rows[0]["amc_end_id"].ToString() != "0"))
            {
                string Datefrom = "'" + Convert.ToDateTime(Dt.Rows[0]["amc_end_from"].ToString()).ToString("MM-dd-yyyy") + "'"; 
                string Dateto = "'" + Convert.ToDateTime(Dt.Rows[0]["amc_end_to"].ToString()).ToString("MM-dd-yyyy") + "'";
                where += " and a.warranty_end_date >= (" + Datefrom + ") and a.warranty_end_date <= (" + Dateto + ")";
            }
            string Query = "zdesk_Get_Report_assetReport_Generate";
            SqlDataAdapter cmd = new SqlDataAdapter(Query, connstr);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.SelectCommand.Parameters.AddWithValue("@ColumnName", ColumnName);
            cmd.SelectCommand.Parameters.AddWithValue("@where", where);
            DataTable DtReport = new DataTable();
            cmd.Fill(DtReport);
            string Path = ExportData(DtReport, "Report");
            return Path;

        }
        public string ProblemReport(DataTable Dt)
        {
            string ColumnName = "";
            string where = "";          
                                   
            //if (!String.IsNullOrEmpty(Dt.Rows[0]["cost"].ToString()))
            //{
            //    where += "and a.cc_id_fk in (" + Dt.Rows[0]["cost"].ToString() + ")";
            //}
           
            string Query = "zdesk_Get_Report_Problem_Generate";
            SqlDataAdapter cmd = new SqlDataAdapter(Query, connstr);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.SelectCommand.Parameters.AddWithValue("@ColumnName", ColumnName);
            cmd.SelectCommand.Parameters.AddWithValue("@where", where);
            DataTable DtReport = new DataTable();
            cmd.Fill(DtReport);
            string Path = ExportData(DtReport, "Report");
            return Path;

        }
        public string ChangeReport(DataTable Dt)
        {
            string ColumnName = "";
            string where = "";

            //if (!String.IsNullOrEmpty(Dt.Rows[0]["cost"].ToString()))
            //{
            //    where += "and a.cc_id_fk in (" + Dt.Rows[0]["cost"].ToString() + ")";
            //}

            string Query = "zdesk_Get_Report_Change_Generate";
            SqlDataAdapter cmd = new SqlDataAdapter(Query, connstr);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.SelectCommand.Parameters.AddWithValue("@ColumnName", ColumnName);
            cmd.SelectCommand.Parameters.AddWithValue("@where", where);
            DataTable DtReport = new DataTable();
            cmd.Fill(DtReport);
            string Path = ExportData(DtReport, "Report");
            return Path;
        }
        public string TaskReport(DataTable Dt)
        {
            string ColumnName = "";
            string where = "";

            //if (!String.IsNullOrEmpty(Dt.Rows[0]["cost"].ToString()))
            //{
            //    where += "and a.cc_id_fk in (" + Dt.Rows[0]["cost"].ToString() + ")";
            //}

            string Query = "zdesk_Get_Report_Task_Generate";
            SqlDataAdapter cmd = new SqlDataAdapter(Query, connstr);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.SelectCommand.Parameters.AddWithValue("@ColumnName", ColumnName);
            cmd.SelectCommand.Parameters.AddWithValue("@where", where);
            DataTable DtReport = new DataTable();
            cmd.Fill(DtReport);
            string Path = ExportData(DtReport, "Report");
            return Path;
        }
        public string ExportData(DataTable dt, string aTitle)
        {
            var path = FilePath;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
                

            var guid = Guid.NewGuid();
            var FileName = $"{aTitle}-{guid}.csv";

            string filePath = Path.Combine(path, FileName);
            string delimiter = ",";
            StringBuilder sb = new StringBuilder();
            List<string> CsvRow = new List<string>();
            foreach (DataColumn c in dt.Columns)
            {
                CsvRow.Add(c.ColumnName);
            }
            sb.AppendLine(string.Join(delimiter, CsvRow));
            foreach (DataRow r in dt.Rows)
            {
                CsvRow.Clear();
                foreach (DataColumn c in dt.Columns)
                {
                    CsvRow.Add(r[c].ToString());
                }
                sb.AppendLine(string.Join(delimiter, CsvRow));
            }

            System.IO.File.WriteAllText(filePath, sb.ToString());

            return filePath;
        }

        public string sendEmail(MailAddress fromAddress, string toAddresses, string subject, string emailBody, string ccAddresses = "", string bccAddresses = "", string Path = "")
        {
            client.Timeout = 100000;//more than 1 s

            MailMessage message = new MailMessage();

            message.From = fromAddress;
            message.To.Add(toAddresses);
            message.Subject = subject;
            message.Body = emailBody;
            if (ccAddresses != "")
            {
                string[] CCId = ccAddresses.Split(',');

                foreach (string CCEmail in CCId)
                {
                    message.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
                }
            }
            if (bccAddresses != "") { message.Bcc.Add(bccAddresses); }
            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(Path);
            message.Attachments.Add(attachment);

            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(message);
            // Clean up.
            message.Dispose();

            return "Mail Sent";

           // return "Ok";
        }


    }
}
