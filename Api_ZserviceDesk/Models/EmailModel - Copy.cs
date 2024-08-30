using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Net.Mime;
using Api_ZserviceDesk.Controllers;
using Api_ZserviceDesk.Models;
using PetaPoco;

namespace Api_ZserviceDesk.Models
{
    public class EmailModel
    {
        Zdesk_m_smpt_tbl zdesk_M_Smpt_Tbl;
        Zdesk_m_logo_tbl Zdesk_m_logo_tbl;
        public EmailModel()
        {
            getMailConfiguration();
            getorgInfoConfiguration();
        }

        public string urlShorter(string url)
        {
            string post = "{\"longUrl\": \"" + url + "\"}";
            string shortUrl = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["shorturlkey"].ToString());
            try
            {
                request.ServicePoint.Expect100Continue = false;
                request.Method = "POST";
                request.ContentLength = post.Length;
                request.ContentType = "application/json";
                request.Headers.Add("Cache-Control", "no-cache");
                using (Stream requestStream = request.GetRequestStream())
                {
                    byte[] postBuffer = Encoding.ASCII.GetBytes(post);
                    requestStream.Write(postBuffer, 0, postBuffer.Length);
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader responseReader = new StreamReader(responseStream))
                        {
                            string json = responseReader.ReadToEnd();
                            dynamic stuff = JObject.Parse(json);
                            shortUrl = stuff.id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionTracking et = new ExceptionTracking();
                et.status = ((System.Net.WebException)ex.InnerException) != null ? ((System.Net.WebException)ex.InnerException).Status.ToString() : null;
                et.message = ex.Message;
                et.exception_message = ex.InnerException != null ? ex.InnerException.Message : null;
                et.exception_type = ex.Message;
                et.StackTrace = ex.StackTrace;
                new UtilityController().InsException(et);
            }
            return shortUrl;
        }
        public ExceptionTracking SmtpSend(MailMessage user)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = zdesk_M_Smpt_Tbl.ServiceProtocol;
            smtp.EnableSsl = zdesk_M_Smpt_Tbl.Isssl ?? default(bool);
            NetworkCredential NetworkCred = new NetworkCredential(zdesk_M_Smpt_Tbl.UserName, zdesk_M_Smpt_Tbl.Password);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = NetworkCred;
            //smtp.Timeout = 300;
            smtp.Port = Convert.ToInt32(zdesk_M_Smpt_Tbl.SmptPort);
            try
            {
                smtp.Send(user);
                ExceptionTracking et = new ExceptionTracking();
                et.is_sent = 1;
                return et;
            }
            catch (SmtpException ex)
            {
                ExceptionTracking et = new ExceptionTracking();
                et.status = ((System.Net.WebException)ex.InnerException) != null ? ((System.Net.WebException)ex.InnerException).Status.ToString() : null;
                et.message = ex.Message;
                et.exception_message = ex.InnerException != null ? ex.InnerException.Message : null;
                et.exception_type = ex.Message;
                et.StackTrace = ex.StackTrace;
                et.is_sent = 0;
                new UtilityController().InsException(et);
                return et;
            }
            catch (Exception ex)
            {
                ExceptionTracking et = new ExceptionTracking();
                et.status = ((System.Net.WebException)ex.InnerException) != null ? ((System.Net.WebException)ex.InnerException).Status.ToString() : null;
                et.message = ex.Message;
                et.exception_message = ex.InnerException != null ? ex.InnerException.Message : null;
                et.exception_type = ex.Message;
                et.StackTrace = ex.StackTrace;
                et.is_sent = 0;
                new UtilityController().InsException(et);
                return et;
            }
        }
        public static ExceptionTracking SendEmail(MailMessage user)
        {
            //  MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient();
            //  mail.From = new MailAddress(MessageFrom);
            //   mail.IsBodyHtml = true;
            SmtpServer.Host = "192.168.19.37";
            SmtpServer.Port = 25;
            SmtpServer.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            try
            {
                SmtpServer.Send(user);
                ExceptionTracking et = new ExceptionTracking();
                et.is_sent = 1;
                return et;
            }
            catch (SmtpException ex)
            {
                ExceptionTracking et = new ExceptionTracking();
                et.status = ((System.Net.WebException)ex.InnerException) != null ? ((System.Net.WebException)ex.InnerException).Status.ToString() : null;
                et.message = ex.Message;
                et.exception_message = ex.InnerException != null ? ex.InnerException.Message : null;
                et.exception_type = ex.Message;
                et.StackTrace = ex.StackTrace;
                et.is_sent = 0;
                new UtilityController().InsException(et);
                return et;
            }
            catch (Exception ex)
            {
                ExceptionTracking et = new ExceptionTracking();
                et.status = ((System.Net.WebException)ex.InnerException) != null ? ((System.Net.WebException)ex.InnerException).Status.ToString() : null;
                et.message = ex.Message;
                et.exception_message = ex.InnerException != null ? ex.InnerException.Message : null;
                et.exception_type = ex.Message;
                et.StackTrace = ex.StackTrace;
                et.is_sent = 0;
                new UtilityController().InsException(et);
                return et;
            }
        }

        // Send Email for Consumable Allocation
        public void SendConsumableAllocateNotification(AssetAllocation ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 22;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$TicketID$$", ce.TicketID);
                myString = myString.Replace("$$Category$$", ce.Category);
                myString = myString.Replace("$$Item$$", ce.Item);
                myString = myString.Replace("$$Qty$$", ce.Qty);
                myString = myString.Replace("$$User$$", ce.Name);
                myString = myString.Replace("$$SerialNo$$", ce.SerialNo);

                user.Subject = t.subject;
                myString = BindOrgInfo(myString);
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for Software Allocation
        public void SendSoftwareAllocateNotification(SoftwareAllocation ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                string username = userName(ce.ReceiptEmail);
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 45;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$UserName$$", username);
                myString = myString.Replace("$$SoftwareName$$", ce.SoftwareName);
                myString = myString.Replace("$$LicenseNo$$", ce.LicenseNo);
                user.Subject = t.subject;
                myString = BindOrgInfo(myString);
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }


        //send set password link to initiator at index page Template Id:1
        public void SendPasswordLink(Email e)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, e.Tomail.Trim()))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 1;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$Name$$", e.Name.Trim());
                myString = myString.Replace("$$Services$$", e.BusinessType);
                myString = myString.Replace("$$link-1$$", e.Url);   //  urlShorter(e.Url)
                myString = myString.Replace("$$Contact$$", e.contact_number);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                HttpWebRequest MyRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["FileUploadPath"].ToString() + "Step By Step Process.pdf");
                HttpWebResponse MyResponse = (HttpWebResponse)MyRequest.GetResponse();
                Stream file = MyResponse.GetResponseStream();
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                Attachment at = new Attachment(ms, "Step By Step Process.pdf", MediaTypeNames.Application.Pdf);
                user.Attachments.Add(at);
                MyResponse.Close();
                SmtpSend(user);
            }
        }
        public void SendResetPasswordLink(Email e)
        {
            using (MailMessage user = new MailMessage("eFiling Portal.in<" + zdesk_M_Smpt_Tbl.FromAddress + ">", e.Tomail.Trim()))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 7;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$link-1$$", e.Url);  //urlShorter(e.Url)
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
            }
        }
        //Send New Ticket Create Details for Incident
        public void SendNewTickets(TicketStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                //t.id = 11;
                t.id = 10;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$TicketId$$", ce.TicketId);
                myString = myString.Replace("$$Name$$", ce.Name);
                myString = myString.Replace("$$Status$$", ce.Status);
                myString = myString.Replace("$$Assign$$", ce.Assign);
                myString = myString.Replace("$$Subject$$", ce.Subject);
                myString = myString.Replace("$$User$$", ce.Name);
                user.Subject = t.subject + " - #" + ce.TicketId;
                myString = BindOrgInfo(myString);
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        //Send Vendor Asset notification
        public void Vendornotification(Vendornotification vendornotification)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, vendornotification.VendorEmail))
            {


                StringBuilder myString = new StringBuilder();
                //myString.Append("Dear " + vendornotification.VendorName+",<br/>");
                //myString.Append("Please find the below new assets info, <br/><br/>");
                myString.Append(vendornotification.Message + "<br/><br/>");
                myString.Append("Serial No : " + vendornotification.serialno + "<br/>");
                myString.Append("Make : " + vendornotification.make + "<br/>");
                myString.Append("Model : " + vendornotification.model + "<br/>");
                myString.Append("Express Code : " + vendornotification.expressCode + "<br/>");

                user.Subject = vendornotification.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
            }

        }
        //Send Incident ticket status change
        public void SendIncidentStatusChange(TicketStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                //t.id = 11;
                t.id = 11;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$TicketId$$", ce.TicketId);
                //myString = myString.Replace("$$Name$$", ce.Name);
                myString = myString.Replace("$$Status$$", ce.Status);
                myString = myString.Replace("$$Assign$$", ce.Assign);
                myString = myString.Replace("$$Subject$$", ce.Subject);
                myString = myString.Replace("$$User$$", ce.Name);
                user.Subject = t.subject + " - #" + ce.TicketId;
                myString = BindOrgInfo(myString);
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        public void SendTicketAssignTechnician(TicketStatus ce)
        {
            var data = getIncidentRequestDetails(Convert.ToInt32(ce.TicketId)).FirstOrDefault();

            if (data != null)
            {
                var ReceiptEmail = "";

                if (data.TechnicianEmail != "")
                {
                    ReceiptEmail = data.TechnicianEmail;
                }

                using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ReceiptEmail))
                {
                    EmailTemplateModel t = new EmailTemplateModel();
                    t.id = 23;
                    t = new UtilityController().GetTemplate(t);
                    string myString = "";
                    myString = t.Template;
                    myString = myString.Replace("$$IncidentRequestId$$", data.TicketId);
                    myString = myString.Replace("$$UserName$$", data.Name);
                    myString = myString.Replace("$$Title$$", data.Title);
                    myString = myString.Replace("$$RequestDescription$$", data.Description);
                    myString = myString.Replace("$$Category$$", data.Category);
                    myString = myString.Replace("$$SubCategory$$", data.SubCategory);
                    ////myString = myString.Replace("$$UpdatedBy$$", data.UpdatedBy);
                    ////myString = myString.Replace("$$StatusComments$$", data.StatusComments);
                    user.Subject = t.subject.Replace("$$TicketId$$", data.TicketId);
                    myString = BindOrgInfo(myString);
                    user.Body = myString.ToString();
                    user.IsBodyHtml = true;
                    var result = SmtpSend(user);
                    zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                    ea.email_to = ce.ReceiptEmail;
                    ea.subject = t.subject.Replace("$$TicketId$$", data.TicketId);
                    ea.status = result.is_sent;
                    ea.email_status = result.status;
                    ea.error_message = result.exception_message;
                    ea.exception_message = result.exception_message;
                    ea.exception_type = result.exception_type;
                    ea.stack_trace = result.StackTrace;
                    new UtilityController().InsMailError(ea);
                }
            }
        }
        // Send Email
        public void SendNewTicketsCreate(TicketStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 10;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$TicketId$$", ce.TicketId);
                myString = myString.Replace("$$User$$", ce.Name);
                myString = myString.Replace("$$Status$$", ce.Status);
                myString = myString.Replace("$$Subject$$", ce.Subject);
                myString = myString.Replace("$$Assign$$", "");
                myString = BindOrgInfo(myString);
                user.Subject = t.subject + " - #" + ce.TicketId;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        // Send Email New Service Request 
        public void SendNewServiceRequestCreate(ServiceRequestStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                ////t.id = 17;
                t.id = 67;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$ServiceRequestId$$", ce.ServiceRequestId);
                myString = myString.Replace("$$Name$$", ce.Name);
                myString = myString.Replace("$$Status$$", ce.Status);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        // Send Email Change Status Service Request 
        public void SendServiceRequestChangeStatus(ServiceRequestStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 18;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$ServiceRequestId$$", ce.ServiceRequestId);
                myString = myString.Replace("$$Name$$", ce.Name);
                myString = myString.Replace("$$Status$$", ce.Status);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        // Send Email Change Status Approved Service Request  
        public void SendServiceRequestChangeStatusAprooved(ServiceRequestStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 19;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$ServiceRequestId$$", ce.ServiceRequestId);
                myString = myString.Replace("$$Name$$", ce.Name);
                myString = myString.Replace("$$Status$$", ce.Status);
                myString = myString.Replace("$$FeedBack$$", ce.Url);  //urlShorter(e.Url)
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        // Send Email Service Request Status Approved or Reject 
        public void SendServiceRequestChangeStatusAproovedOrRejected(ServiceRequestStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 20;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$ServiecRequestID$$", ce.ServiceRequestId);
                myString = myString.Replace("$$Subject$$", ce.Subject);
                myString = myString.Replace("$$UserEmail$$", ce.UserEmail);
                //  myString = myString.Replace("$$ApproverID$$", ce.ApproverID);  
                myString = myString.Replace("$$UrlApp$$", ce.UrlApp);  //urlShorter(e.Url)
                myString = myString.Replace("$$UrlRej$$", ce.UrlRej);  //urlShorter(e.Url) 
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for Service Request when request Created  
        public void SendEmailChangeStatus_SR(ServiceRequestStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 55;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$ApproverLevel$$", EncryptDecrypt.EncryptUrl(ce.ApproverLevel));
                myString = myString.Replace("$$SRID$$", EncryptDecrypt.EncryptUrl(ce.ID));
                myString = myString.Replace("$$ServiceRequestID$$", ce.ServiceRequestId);
                myString = myString.Replace("$$Title$$", ce.Title);
                myString = myString.Replace("$$RequestDescription$$", ce.RequestDescription);
                myString = myString.Replace("$$UserName$$", ce.UserName);
                myString = myString.Replace("$$Category$$", ce.Category);
                myString = myString.Replace("$$SubCategory$$", ce.SubCategory);
                myString = myString.Replace("$$ApproverName$$", ce.ApproverName);
                user.Subject = t.subject;
                myString = BindOrgInfo(myString);
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        // send email when Convert from ticket to Service request Create
        public void SendEmailCreateServiceRequest(ServiceRequestStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 67;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$ServiceRequestID$$", ce.ServiceRequestId);
                myString = myString.Replace("$$UserName$$", ce.UserName);
                myString = myString.Replace("$$Title$$", ce.Title);
                myString = myString.Replace("$$RequestDescription$$", ce.Description);
                myString = myString.Replace("$$Category$$", ce.Category);
                myString = myString.Replace("$$SubCategory$$", ce.SubCategory);
                user.Subject = t.subject;
                myString = BindOrgInfo(myString);
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // send email when Service Request Status Change
        public void SendEmailStatusChangeServiceRequest(ServiceRequestStatus ce)
        {
            var data = getServiceRequestDetails(Convert.ToInt32(ce.service_req_id_pk)).FirstOrDefault();

            if (data != null)
            {
                var ReceiptEmail = "";

                if (data.UserEmail != "")
                {
                    ReceiptEmail = data.UserEmail;
                }

                if (data.NewStatus != "Assigned" && data.TechnicianEmail != "" && data.TechnicianEmail != null)
                {
                    if (ReceiptEmail != "")
                    {
                        ReceiptEmail = ReceiptEmail + "," + data.TechnicianEmail;
                    }
                    else
                    {
                        ReceiptEmail = ReceiptEmail + data.TechnicianEmail;
                    }
                }

                using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ReceiptEmail))
                {
                    EmailTemplateModel t = new EmailTemplateModel();
                    t.id = 68;
                    t = new UtilityController().GetTemplate(t);
                    string myString = "";
                    myString = t.Template;
                    myString = myString.Replace("$$ServiceRequestID$$", data.ServiceRequestId);
                    ////myString = myString.Replace("$$UserName$$", ce.UserName);
                    myString = myString.Replace("$$Title$$", data.Title);
                    myString = myString.Replace("$$RequestDescription$$", data.Description);
                    myString = myString.Replace("$$Category$$", data.Category);
                    myString = myString.Replace("$$SubCategory$$", data.SubCategory);
                    myString = myString.Replace("$$OldStatus$$", ce.OldStatus);
                    myString = myString.Replace("$$NewStatus$$", data.NewStatus);
                    myString = myString.Replace("$$UpdatedBy$$", data.UpdatedBy);
                    myString = myString.Replace("$$StatusComments$$", data.StatusComments);
                    user.Subject = t.subject;
                    myString = BindOrgInfo(myString);
                    user.Body = myString.ToString();
                    user.IsBodyHtml = true;
                    var result = SmtpSend(user);
                    zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                    ea.email_to = ce.ReceiptEmail;
                    ea.subject = t.subject;
                    ea.status = result.is_sent;
                    ea.email_status = result.status;
                    ea.error_message = result.exception_message;
                    ea.exception_message = result.exception_message;
                    ea.exception_type = result.exception_type;
                    ea.stack_trace = result.StackTrace;
                    new UtilityController().InsMailError(ea);
                }
            }
        }

        // send email when Service Request is assigned to Technician
        public void SendEmailTechnicianAssignServiceRequest(ServiceRequestStatus ce)
        {
            var data = getServiceRequestDetails(Convert.ToInt32(ce.service_req_id_pk)).FirstOrDefault();

            if (data != null)
            {
                var ReceiptEmail = "";

                if (data.TechnicianEmail != "")
                {
                    ReceiptEmail = data.TechnicianEmail;
                }

                using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ReceiptEmail))
                {
                    EmailTemplateModel t = new EmailTemplateModel();
                    t.id = 69;
                    t = new UtilityController().GetTemplate(t);
                    string myString = "";
                    myString = t.Template;
                    myString = myString.Replace("$$ServiceRequestID$$", data.ServiceRequestId);
                    myString = myString.Replace("$$UserName$$", data.Name);
                    myString = myString.Replace("$$Title$$", data.Title);
                    myString = myString.Replace("$$RequestDescription$$", data.Description);
                    myString = myString.Replace("$$Category$$", data.Category);
                    myString = myString.Replace("$$SubCategory$$", data.SubCategory);
                    myString = myString.Replace("$$UpdatedBy$$", data.UpdatedBy);
                    myString = myString.Replace("$$StatusComments$$", data.StatusComments);
                    user.Subject = t.subject.Replace("$$ServiceRequestID$$", data.ServiceRequestId);
                    myString = BindOrgInfo(myString);
                    user.Body = myString.ToString();
                    user.IsBodyHtml = true;
                    var result = SmtpSend(user);
                    zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                    ea.email_to = ce.ReceiptEmail;
                    ea.subject = t.subject.Replace("$$ServiceRequestID$$", data.ServiceRequestId);
                    ea.status = result.is_sent;
                    ea.email_status = result.status;
                    ea.error_message = result.exception_message;
                    ea.exception_message = result.exception_message;
                    ea.exception_type = result.exception_type;
                    ea.stack_trace = result.StackTrace;
                    new UtilityController().InsMailError(ea);
                }
            }
        }


        // Send Email for Gate Pass when gate pass Created 3 approval 
        public void SendEmailChangeGatePassStatus(GatePassStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 12;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$ApproverLevel$$", ce.ApproverLevel);
                myString = myString.Replace("$$GatePasID$$", ce.GatePassID);
                myString = myString.Replace("$$Description$$", ce.MomentType);
                myString = myString.Replace("$$GatePassType$$", ce.GatePasType);
                myString = myString.Replace("$$UserName$$", ce.Name);
                myString = myString.Replace("$$ApproverName$$", ce.ApproverName);
                user.Subject = t.subject;
                myString = BindOrgInfo(myString);
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        // Send Email for Gate Pass Approved and rejected 
        public void SendEmailChangeGatePassStatusChange(GatePassStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 40;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$NotifierName$$", ce.Name);
                myString = myString.Replace("$$GatePasID$$", ce.GatePassID);
                myString = myString.Replace("$$ApproverName$$", ce.ApproverName);
                myString = myString.Replace("$$ActionStatus$$", ce.ApproverLevel);
                user.Subject = t.subject;
                myString = BindOrgInfo(myString);
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        //public void SendEmailChangeGatePassStatusFirst(GatePassStatus ce)
        //{
        //    using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
        //    {
        //        EmailTemplateModel t = new EmailTemplateModel();
        //        t.id = 15;
        //        t = new UtilityController().GetTemplate(t);
        //        string myString = "";
        //        myString = t.Template;
        //        myString = myString.Replace("$$GatePasID$$", ce.GatePassID);
        //        myString = myString.Replace("$$Description$$", ce.MomentType);
        //        myString = myString.Replace("$$GatePassType$$", ce.GatePasType);
        //        myString = myString.Replace("$$UserName$$", ce.Name);
        //        user.Subject = t.subject;
        //        user.Body = myString.ToString();
        //        user.IsBodyHtml = true;
        //        var result = SmtpSend(user);
        //        zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
        //        ea.email_to = ce.ReceiptEmail;
        //        ea.subject = t.subject;
        //        ea.status = result.is_sent;
        //        ea.email_status = result.status;
        //        ea.error_message = result.exception_message;
        //        ea.exception_message = result.exception_message;
        //        ea.exception_type = result.exception_type;
        //        ea.stack_trace = result.StackTrace;
        //        new UtilityController().InsMailError(ea);
        //    }
        //}
        //public void SendEmailChangeGatePassStatusSc(GatePassStatus ce)
        //{
        //    using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
        //    {
        //        EmailTemplateModel t = new EmailTemplateModel();
        //        t.id = 15;
        //        t = new UtilityController().GetTemplate(t);
        //        string myString = "";
        //        myString = t.Template;
        //        myString = myString.Replace("$$GatePasID$$", ce.GatePassID);
        //        myString = myString.Replace("$$Description$$", ce.MomentType);
        //        myString = myString.Replace("$$GatePassType$$", ce.GatePasType);
        //        myString = myString.Replace("$$UserName$$", ce.Name);
        //        user.Subject = t.subject;
        //        user.Body = myString.ToString();
        //        user.IsBodyHtml = true;
        //        var result = SmtpSend(user);
        //        zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
        //        ea.email_to = ce.ReceiptEmail;
        //        ea.subject = t.subject;
        //        ea.status = result.is_sent;
        //        ea.email_status = result.status;
        //        ea.error_message = result.exception_message;
        //        ea.exception_message = result.exception_message;
        //        ea.exception_type = result.exception_type;
        //        ea.stack_trace = result.StackTrace;
        //        new UtilityController().InsMailError(ea);
        //    }
        //}
        //public void SendEmailChangeGatePassStatusSecond(GatePassStatus ce)
        //{
        //    using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
        //    {
        //        EmailTemplateModel t = new EmailTemplateModel();
        //        t.id = 16;
        //        t = new UtilityController().GetTemplate(t);
        //        string myString = "";
        //        myString = t.Template;
        //        myString = myString.Replace("$$GatePasID$$", ce.GatePassID);
        //        myString = myString.Replace("$$Description$$", ce.MomentType);
        //        myString = myString.Replace("$$GatePassType$$", ce.GatePasType);
        //        myString = myString.Replace("$$UserName$$", ce.Name);
        //        user.Subject = t.subject;
        //        user.Body = myString.ToString();
        //        user.IsBodyHtml = true;
        //        var result = SmtpSend(user);
        //        zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
        //        ea.email_to = ce.ReceiptEmail;
        //        ea.subject = t.subject;
        //        ea.status = result.is_sent;
        //        ea.email_status = result.status;
        //        ea.error_message = result.exception_message;
        //        ea.exception_message = result.exception_message;
        //        ea.exception_type = result.exception_type;
        //        ea.stack_trace = result.StackTrace;
        //        new UtilityController().InsMailError(ea);
        //    }
        //}
        //public void SendEmailChangeGatePassStatusThird(GatePassStatus ce)
        //{
        //    using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
        //    {
        //        EmailTemplateModel t = new EmailTemplateModel();
        //        t.id = 16;
        //        t = new UtilityController().GetTemplate(t);
        //        string myString = "";
        //        myString = t.Template;
        //        myString = myString.Replace("$$GatePasID$$", ce.GatePassID);
        //        myString = myString.Replace("$$Description$$", ce.MomentType);
        //        myString = myString.Replace("$$GatePassType$$", ce.GatePasType);
        //        myString = myString.Replace("$$UserName$$", ce.Name);
        //        user.Subject = t.subject;
        //        user.Body = myString.ToString();
        //        user.IsBodyHtml = true;
        //        var result = SmtpSend(user);
        //        zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
        //        ea.email_to = ce.ReceiptEmail;
        //        ea.subject = t.subject;
        //        ea.status = result.is_sent;
        //        ea.email_status = result.status;
        //        ea.error_message = result.exception_message;
        //        ea.exception_message = result.exception_message;
        //        ea.exception_type = result.exception_type;
        //        ea.stack_trace = result.StackTrace;
        //        new UtilityController().InsMailError(ea);
        //    }
        //}
        // Send Email Ticket Reply Status 
        public void SendEmailTicketReplyStatus(TicketReplyStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 13;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$TicketID$$", ce.TicketId);
                myString = myString.Replace("$$Description$$", ce.Description);
                myString = myString.Replace("$$Subject$$", ce.Subject);
                myString = myString.Replace("$$User$$", ce.UserName);
                if (ce.CCEmail != null || ce.CCEmail != "")
                {
                    string[] CCId = ce.CCEmail.Split(',');
                    foreach (string CCEmail in CCId)
                    {
                        user.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id  
                    }
                }
                user.Subject = t.subject + " - #" + ce.TicketId;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        public void SendEmailTicketReplyStatusNew(TicketReplyStatus ce, HttpPostedFile file)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 13;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$TicketID$$", ce.TicketId);
                myString = myString.Replace("$$Description$$", ce.Description);
                myString = myString.Replace("$$Subject$$", ce.Subject);
                myString = myString.Replace("$$User$$", ce.UserName);
                if (ce.CCEmail.EndsWith(","))
                {
                    ce.CCEmail = ce.CCEmail.TrimEnd(',');
                }
                if (ce.CCEmail != null && ce.CCEmail != "")
                {
                    string[] CCId = ce.CCEmail.Split(',');
                    foreach (string CCEmail in CCId)
                    {
                        user.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id  
                    }
                }
                if (file != null)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    user.Attachments.Add(new Attachment(file.InputStream, fileName));
                }
                user.Subject = ce.Subject + " - #" + ce.TicketId;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = ce.Subject + " " + t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        // Send Email Service Request Reply Status 
        public void SendEmailServiceRequestReplyStatus(ServiceRequestReplyStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 14;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$RequestID$$", ce.RequestID);
                myString = myString.Replace("$$Description$$", ce.Description);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                if (ce.CCEmail.EndsWith(","))
                {
                    ce.CCEmail = ce.CCEmail.TrimEnd(',');
                }
                if (ce.CCEmail != null && ce.CCEmail != "")
                {
                    string[] CCId = ce.CCEmail.Split(',');
                    foreach (string CCEmail in CCId)
                    {
                        user.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id  
                    }
                }
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        // Send Email for Approval Request Change 
        public void SendEmailRequestApprovalStatus(RequestApprovalStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 17;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$ReqID$$", ce.ReqID);
                myString = myString.Replace("$$Subject$$", ce.Subject);
                myString = myString.Replace("$$ContactNo$$", ce.ContactNo);
                myString = myString.Replace("$$UserName$$", ce.Email);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for Asset Allocation 
        public void SendAssetAllocateNotification(AssetAllocation ce)
        {
            string username = userName(ce.ReceiptEmail);
            string UserID = userID(ce.ReceiptEmail);
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 18;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;

                if (ce.AssetImagePath == "" || ce.AssetImagePath == null)
                {
                    myString = myString.Replace("$$DocPath$$", ConfigurationManager.AppSettings["AssetImageDefaultPath"].ToString());
                }
                else
                {
                    myString = myString.Replace("$$DocPath$$", ce.AssetImagePath.Replace("~", ""));
                }

                myString = myString.Replace("$$User$$", username);
                myString = myString.Replace("$$UID$$", EncryptDecrypt.EncryptUrl(UserID));
                myString = myString.Replace("$$AssetID$$", ce.AssetID);
                myString = myString.Replace("$$Category$$", ce.Category);
                myString = myString.Replace("$$Make$$", ce.Make);
                myString = myString.Replace("$$Model$$", ce.Model);
                myString = myString.Replace("$$SerialNo$$", ce.SerialNo);
                myString = myString.Replace("$$Tag$$", ce.AssetTag);
                myString = myString.Replace("$$UpdatedBy$$", ce.UpdatedBy);
                myString = myString.Replace("$$Remarks$$", ce.Remarks);
                myString = myString.Replace("$$Compnents$$", getAssetComponent(Convert.ToInt32(ce.AssetID)));

                myString = BindOrgInfo(myString);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email For Ticket Status Not Resolved 
        public void SendEmailTicketStatusNotResolved(TicketReplyStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 19;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$TicketID$$", ce.TicketId);
                myString = myString.Replace("$$UserName$$", ce.UserName);
                myString = myString.Replace("$$Subject$$", ce.Subject);
                myString = myString.Replace("$$AssignedEng$$", ce.AssignTo);
                myString = myString.Replace("$$IncidentStatus$$", ce.TicketStatus);
                myString = myString.Replace("$$Remaining_Time$$", ce.Remaining_Time);
                user.Subject = t.subject + " - #" + ce.TicketId;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SendEmail(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        // Send Email for Asset Status Change 
        public void SendAssetStatusNotification(AssetAllocation ce)
        {
            string oldStatus = ce.Status;
            var data = getAssetStatusoLd(Convert.ToInt32(ce.AssetID));
            if (data.Count() == 2)
            {
                oldStatus = data[1];
            }
            else
            {
                oldStatus = data.Count() == 0 ? "N/A" : data[0];
            }

            AssetStatus CurrentStatus = getAssetStatus(Convert.ToInt32(ce.AssetID));
            string cc = ConfigurationManager.AppSettings["CC_Email"].ToString();
            string[] _user = ce.ReceiptEmail.Split(',');
            string[] _cc = cc.Split(',');
            string EmailIds = "";

            if (ce.ReceiptEmail != "")
            {
                EmailIds = EmailIds + ce.ReceiptEmail;
            }

            if (cc != "")
            {
                if (EmailIds != "")
                {
                    EmailIds = EmailIds + "," + cc;
                }
                else
                {
                    EmailIds = EmailIds + cc;
                }
            }
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, EmailIds))
            {
                if (_user.Length > 1)
                {
                    foreach (var i in _user)
                    {
                        user.CC.Add(i);

                    }
                }
                if (cc.Length > 1)
                {
                    foreach (var i in _cc)
                    {
                        if (i != _cc[0])
                            user.CC.Add(i);
                    }
                }

                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 26;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$AssetID$$", ce.AssetID);
                myString = myString.Replace("$$Category$$", ce.Category);
                myString = myString.Replace("$$Make$$", ce.Make);
                myString = myString.Replace("$$Model$$", ce.Model);
                myString = myString.Replace("$$SerialNo$$", ce.SerialNo);
                myString = myString.Replace("$$Remarks$$", ce.Remarks);
                myString = myString.Replace("$$OldStatus$$", oldStatus);
                myString = myString.Replace("$$NewStatus$$", CurrentStatus.status);
                myString = myString.Replace("$$AssetTag$$", CurrentStatus.asset_tag);
                myString = myString.Replace("$$Location$$", ce.Location);
                myString = myString.Replace("$$UpdatedBy$$", ce.UpdatedBy);

                myString = BindOrgInfo(myString);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = cc + "," + ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        // Send Email for Asset Created 
        public void SendNewAssetNotification(AssetAllocation ce)
        {
            if (ce.ReceiptEmail == null)
            {
                ce.ReceiptEmail = ConfigurationManager.AppSettings["NewAsset"].ToString();
            }
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 33;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$Category$$", ce.Category);
                myString = myString.Replace("$$Make$$", ce.Make);
                myString = myString.Replace("$$Model$$", ce.Model);
                myString = myString.Replace("$$SerialNo$$", ce.SerialNo);
                myString = myString.Replace("$$Tag$$", ce.AssetTag);
                myString = BindOrgInfo(myString);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for Asset User Response
        public void SendAssetUserResponseNotification(AssetAllocation ce)
        {
            string AssetTag = "", UserName = "", EmailTo = "", ApproverEmail = "", ApproverName = "", Category = "", Make = "", Model = "", SerialNo = "";

            var data = getAssetDetails(Convert.ToInt32(ce.AssetID));

            if (data != null)
            {
                AssetTag = data.asset_tag;
                UserName = data.asset_admin_name;
                ApproverName = data.asset_user_name;
                ApproverEmail = data.email;
                Category = data.asset_cat_name;
                Make = data.manufacturer_name;
                Model = data.model_name;
                SerialNo = data.serial_number;
                EmailTo = TechnicianEmailByID(Convert.ToInt32(data.allocated_by));

                if (ce.UserID > 0)
                {
                    ApproverEmail = userEmailByID(Convert.ToInt32(ce.UserID));
                    ApproverName = userNameByID(Convert.ToInt32(ce.UserID)) + " (" + ApproverEmail + ")";
                }

                if (EmailTo != "")
                {
                    EmailTo = EmailTo + "," + ConfigurationManager.AppSettings["CC_Email"].ToString();
                }
            }

            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, EmailTo))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 56;
                t = new UtilityController().GetTemplate(t);

                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$AssetTag$$", AssetTag);
                myString = myString.Replace("$$UserName$$", UserName);
                myString = myString.Replace("$$Status$$", ce.Status);
                myString = myString.Replace("$$ApproverName$$", ApproverName);
                myString = myString.Replace("$$Category$$", Category);
                myString = myString.Replace("$$Make$$", Make);
                myString = myString.Replace("$$Model$$", Model);
                myString = myString.Replace("$$SerialNo$$", SerialNo);
                user.Subject = t.subject.Replace("$$Status$$", ce.Status);
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = EmailTo;
                ea.subject = t.subject.Replace("$$Status$$", ce.Status);
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for Asset InTransit Response
        public void SendAssetVerificationNotification(AssetAllocation ce)
        {
            string AssetTag = "", UserName = "", ApproverEmail = "", POD = "", EDD = "", Make = "", Model = "", SerialNo = "";

            var data = getAssetDetails(Convert.ToInt32(ce.AssetID), 1);

            if (data != null)
            {
                AssetTag = data.asset_tag;
                UserName = data.asset_admin_name;
                ApproverEmail = data.email;
                POD = data.pod;
                EDD = Convert.ToDateTime(data.edd).ToString("dd-MM-yyyy");
                Make = data.manufacturer_name;
                Model = data.model_name;
                SerialNo = data.serial_number;

                if (ce.UserID > 0)
                {
                    ApproverEmail = userEmailByID(ce.UserID);
                    ////UserName = userNameByID(ce.UserID) + " (" + ApproverEmail + ")";
                    UserName = userNameByID(ce.UserID);
                }
            }

            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ApproverEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 57;
                t = new UtilityController().GetTemplate(t);

                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$AssetTag$$", AssetTag);
                myString = myString.Replace("$$UserName$$", UserName);
                myString = myString.Replace("$$Make$$", Make);
                myString = myString.Replace("$$Model$$", Model);
                myString = myString.Replace("$$SerialNo$$", SerialNo);
                myString = myString.Replace("$$POD$$", POD);
                myString = myString.Replace("$$EDD$$", EDD);
                myString = myString.Replace("$$AssetID$$", EncryptDecrypt.EncryptUrl(data.asset_id_pk.ToString()));
                myString = myString.Replace("$$UserID$$", EncryptDecrypt.EncryptUrl(ce.UserID.ToString()));
                myString = BindOrgInfo(myString);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ApproverEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for Asset InTransit Approval Notification
        public void SendAssetVerificationApprovalNotification(AssetAllocation ce)
        {
            string AssetTag = "", ImageURl = "", Remarks = "", UserName = "", ApproverEmail = "", POD = "", EDD = "", Make = "", Model = "", SerialNo = "";

            var data = getAssetDetails(Convert.ToInt32(ce.AssetID), 1);

            if (data != null)
            {
                ImageURl = ConfigurationManager.AppSettings["APIUrl"].ToString() + data.in_transit_images;
                Remarks = data.in_transit_remarks;
                AssetTag = data.asset_tag;
                UserName = data.asset_admin_name;
                ApproverEmail = data.email;
                POD = data.pod;
                EDD = Convert.ToDateTime(data.edd).ToString("dd-MM-yyyy");
                Make = data.manufacturer_name;
                Model = data.model_name;
                SerialNo = data.serial_number;

                if (data.allocated_by > 0)
                {
                    ApproverEmail = TechnicianEmailByID(Convert.ToInt32(data.allocated_by));
                    ////UserName = TechnicianNameByID(Convert.ToInt32(data.allocated_by)) + " (" + ApproverEmail + ")";
                    UserName = TechnicianNameByID(Convert.ToInt32(data.allocated_by));
                }
            }

            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ApproverEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 58;
                t = new UtilityController().GetTemplate(t);

                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$AssetTag$$", AssetTag);
                myString = myString.Replace("$$UserName$$", UserName);
                myString = myString.Replace("$$Make$$", Make);
                myString = myString.Replace("$$Model$$", Model);
                myString = myString.Replace("$$SerialNo$$", SerialNo);
                myString = myString.Replace("$$POD$$", POD);
                myString = myString.Replace("$$EDD$$", EDD);
                myString = myString.Replace("$$InTransitAssetImages$$", ImageURl);
                myString = myString.Replace("$$Remarks$$", Remarks);
                myString = myString.Replace("$$AssetID$$", EncryptDecrypt.EncryptUrl(data.asset_id_pk.ToString()));
                myString = myString.Replace("$$UserID$$", EncryptDecrypt.EncryptUrl(ce.UserID.ToString()));

                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ApproverEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for Preventive Maintenance Allocation to User
        public void SendPreventiveMaintenanceUserNotification(AssetAllocation ce)
        {
            int UserID = 0;
            string AssetTag = "", UserName = "", TechnicianName = "", ApproverEmail = "", PMDD = "", Make = "", Model = "", SerialNo = "";

            var data = getAssetDetails(Convert.ToInt32(ce.AssetID), 1);
            var PMData = getPreventiveMaintenanceDetails(Convert.ToInt32(ce.AssetID));

            if (data != null)
            {
                AssetTag = data.asset_tag;
                if (data.asset_user_id > 0)
                {
                    UserID = Convert.ToInt32(data.asset_user_id);
                }

                Make = data.manufacturer_name;
                Model = data.model_name;
                SerialNo = data.serial_number;

                if (UserID > 0)
                {
                    ApproverEmail = userEmailByID(UserID);
                    ////UserName = userNameByID(ce.UserID) + " (" + ApproverEmail + ")";
                    UserName = userNameByID(UserID);
                }
            }

            if (data.asset_user_id > 0)
            {
                if (PMData != null)
                {
                    PMDD = Convert.ToDateTime(PMData.due_date).ToString("dd-MM-yyyy");
                    TechnicianName = TechnicianNameByID(Convert.ToInt32(PMData.assign_to));
                }

                using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ApproverEmail))
                {
                    EmailTemplateModel t = new EmailTemplateModel();
                    t.id = 59;
                    t = new UtilityController().GetTemplate(t);

                    string myString = "";
                    myString = t.Template;
                    myString = myString.Replace("$$AssetTag$$", AssetTag);
                    myString = myString.Replace("$$UserName$$", UserName);
                    myString = myString.Replace("$$Make$$", Make);
                    myString = myString.Replace("$$Model$$", Model);
                    myString = myString.Replace("$$SerialNo$$", SerialNo);
                    myString = myString.Replace("$$PMDD$$", PMDD);
                    myString = myString.Replace("$$AssignedTo$$", TechnicianName);

                    user.Subject = t.subject;
                    user.Body = myString.ToString();
                    user.IsBodyHtml = true;
                    var result = SmtpSend(user);
                    zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                    ea.email_to = ApproverEmail;
                    ea.subject = t.subject;
                    ea.status = result.is_sent;
                    ea.email_status = result.status;
                    ea.error_message = result.exception_message;
                    ea.exception_message = result.exception_message;
                    ea.exception_type = result.exception_type;
                    ea.stack_trace = result.StackTrace;
                    new UtilityController().InsMailError(ea);
                }
            }
        }

        // Send Email for Preventive Maintenance Allocation to Technician
        public void SendPreventiveMaintenanceTechnicianNotification(AssetAllocation ce)
        {
            int UserID = 0;
            string AssetTag = "", UserName = "", TechnicianName = "", ApproverEmail = "", Location = "", PMDD = "", Make = "", Model = "", SerialNo = "";

            var data = getAssetDetails(Convert.ToInt32(ce.AssetID), 1);
            var PMData = getPreventiveMaintenanceDetails(Convert.ToInt32(ce.AssetID));

            if (data != null)
            {
                AssetTag = data.asset_tag;
                UserID = Convert.ToInt32(data.asset_user_id);
                PMDD = Convert.ToDateTime(data.edd).ToString("dd-MM-yyyy");
                Make = data.manufacturer_name;
                Model = data.model_name;
                SerialNo = data.serial_number;
                Location = data.location_name;

                if (UserID > 0)
                {
                    ////UserName = userNameByID(ce.UserID) + " (" + ApproverEmail + ")";
                    UserName = userNameByID(UserID);
                }
            }

            if (PMData != null)
            {
                PMDD = Convert.ToDateTime(PMData.due_date).ToString("dd-MM-yyyy");
                TechnicianName = TechnicianNameByID(Convert.ToInt32(PMData.assign_to));
                ApproverEmail = TechnicianEmailByID(Convert.ToInt32(PMData.assign_to));
            }

            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ApproverEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 60;
                t = new UtilityController().GetTemplate(t);

                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$AssetTag$$", AssetTag);
                myString = myString.Replace("$$UserName$$", TechnicianName);
                myString = myString.Replace("$$Make$$", Make);
                myString = myString.Replace("$$Model$$", Model);
                myString = myString.Replace("$$SerialNo$$", SerialNo);
                myString = myString.Replace("$$PMDD$$", PMDD);
                myString = myString.Replace("$$Location$$", Location);
                myString = myString.Replace("$$AllocatedTo$$", UserName);

                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ApproverEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for Preventive Maintenance Status Change
        public void SendPreventiveMaintenanceStatusNotification(AssetAllocation ce)
        {
            string AssetTag = "", UserName = "", EmailTo = "", ApproverEmail = "", ApproverName = "", Category = "", Make = "", Model = "", SerialNo = "";

            var PMData = getPreventiveMaintenanceDetails(Convert.ToInt32(ce.PMID), 1);
            var AssetID = 0;
            if (PMData != null)
            {
                AssetID = Convert.ToInt32(PMData.asset_id);
                ApproverName = TechnicianNameByID(Convert.ToInt32(PMData.assign_to));
            }

            var data = getAssetDetails(Convert.ToInt32(AssetID));

            if (data != null)
            {
                AssetTag = data.asset_tag;
                //UserName = data.asset_admin_name;
                //ApproverName = data.asset_user_name;
                //ApproverEmail = data.email;
                Category = data.asset_cat_name;
                Make = data.manufacturer_name;
                Model = data.model_name;
                SerialNo = data.serial_number;
                //EmailTo = TechnicianEmailByID(Convert.ToInt32(data.allocated_by));

                if (data.asset_user_id > 0)
                {
                    EmailTo = userEmailByID(Convert.ToInt32(data.asset_user_id));
                    UserName = userNameByID(Convert.ToInt32(data.asset_user_id));
                    ////EmailTo = ApproverEmail;

                    using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, EmailTo))
                    {
                        EmailTemplateModel t = new EmailTemplateModel();
                        t.id = 61;
                        t = new UtilityController().GetTemplate(t);

                        string myString = "";
                        myString = t.Template;
                        myString = myString.Replace("$$AssetTag$$", AssetTag);
                        myString = myString.Replace("$$UserName$$", UserName);
                        myString = myString.Replace("$$Status$$", ce.Status);
                        myString = myString.Replace("$$ApproverName$$", ApproverName);
                        myString = myString.Replace("$$Category$$", Category);
                        myString = myString.Replace("$$Make$$", Make);
                        myString = myString.Replace("$$Model$$", Model);
                        myString = myString.Replace("$$SerialNo$$", SerialNo);
                        user.Subject = t.subject.Replace("$$Status$$", ce.Status);
                        user.Body = myString.ToString();
                        user.IsBodyHtml = true;
                        var result = SmtpSend(user);
                        zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                        ea.email_to = EmailTo;
                        ea.subject = t.subject.Replace("$$Status$$", ce.Status);
                        ea.status = result.is_sent;
                        ea.email_status = result.status;
                        ea.error_message = result.exception_message;
                        ea.exception_message = result.exception_message;
                        ea.exception_type = result.exception_type;
                        ea.stack_trace = result.StackTrace;
                        new UtilityController().InsMailError(ea);
                    }
                }
            }
        }

        // Send Email for User Status Change Notification
        public void SendUserStatusChangeNotification(UserStatusChnage ce)
        {

            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 39;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$UserName$$", ce.UserName);
                myString = myString.Replace("$$UserEmail$$", ce.UserEmail);
                myString = myString.Replace("$$OldStatus$$", ce.OldStatus);
                myString = myString.Replace("$$NewStatus$$", ce.NewStatus);
                myString = BindOrgInfo(myString);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for New Taks Ticket Creation Notification
        public void NewTaksCreationNotification(ServiceRequestStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 48;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$TicketID$$", ce.TicketId.ToString());
                myString = myString.Replace("$$Subject$$", ce.Subject);
                myString = myString.Replace("$$Category$$", ce.Category);
                myString = myString.Replace("$$SubCategory$$$", ce.SubCategory);
                myString = myString.Replace("$$Assignto$$", ce.AssingTo);
                myString = myString.Replace("$$AssignDate$$", ce.AssingDate);
                myString = myString.Replace("$$AssignBy$$", ce.AssingBy);
                myString = BindOrgInfo(myString);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        // Send Email for Link Status Change Notification
        public void LinkStatusChangeNotification(linkStatusChange ce)
        {

            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 46;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$IPAddress$$", ce.ipAddress);
                myString = myString.Replace("$$IPStatus$$", ce.ipStatus);
                myString = BindOrgInfo(myString);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for New problem Ticket Creation Notification
        public void NewProblemCreationNotification(ServiceRequestStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 49;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$TicketID$$", ce.TicketId.ToString());
                myString = myString.Replace("$$Subject$$", ce.Subject);
                myString = myString.Replace("$$Category$$", ce.Category);
                myString = myString.Replace("$$SubCategory$$$", ce.SubCategory);
                myString = myString.Replace("$$Assignto$$", ce.AssingTo);
                myString = myString.Replace("$$AssignDate$$", ce.AssingDate);
                myString = myString.Replace("$$AssignBy$$", ce.AssingBy);
                myString = BindOrgInfo(myString);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        // Send Email for New Change Ticket Creation Notification
        public void NewChangeCreationNotification(ServiceRequestStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 50;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$TicketID$$", ce.TicketId.ToString());
                myString = myString.Replace("$$Subject$$", ce.Subject);
                myString = myString.Replace("$$Category$$", ce.Category);
                myString = myString.Replace("$$SubCategory$$$", ce.SubCategory);
                myString = myString.Replace("$$Assignto$$", ce.AssingTo);
                myString = myString.Replace("$$AssignDate$$", ce.AssingDate);
                myString = myString.Replace("$$AssignBy$$", ce.AssingBy);
                myString = BindOrgInfo(myString);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for Task Status Change  Notification
        public void TaskStatusChangeNotification(ServiceRequestStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 51;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$TicketID$$", ce.TicketId.ToString());
                myString = myString.Replace("$$Subject$$", ce.Subject);
                myString = myString.Replace("$$Category$$", ce.Category);
                myString = myString.Replace("$$SubCategory$$$", ce.SubCategory);
                myString = myString.Replace("$$oldStatus$$", ce.OldStatus);
                myString = myString.Replace("$$newStatus$$$", ce.NewStatus);
                myString = myString.Replace("$$updatedBy$$", ce.UpdatedBy);
                myString = BindOrgInfo(myString);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for Problem Status Change  Notification
        public void ProblemStatusChangeNotification(ServiceRequestStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 52;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$TicketID$$", ce.TicketId.ToString());
                myString = myString.Replace("$$Subject$$", ce.Subject);
                myString = myString.Replace("$$Category$$", ce.Category);
                myString = myString.Replace("$$SubCategory$$$", ce.SubCategory);
                myString = myString.Replace("$$oldStatus$$", ce.OldStatus);
                myString = myString.Replace("$$newStatus$$$", ce.NewStatus);
                myString = myString.Replace("$$updatedBy$$", ce.UpdatedBy);
                myString = BindOrgInfo(myString);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }
        // Send Email for Change Status Change  Notification
        public void ChangeStatusChangeNotification(ServiceRequestStatus ce)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 53;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;
                myString = myString.Replace("$$TicketID$$", ce.TicketId.ToString());
                myString = myString.Replace("$$Subject$$", ce.Subject);
                myString = myString.Replace("$$Category$$", ce.Category);
                myString = myString.Replace("$$SubCategory$$$", ce.SubCategory);
                myString = myString.Replace("$$oldStatus$$", ce.OldStatus);
                myString = myString.Replace("$$newStatus$$$", ce.NewStatus);
                myString = myString.Replace("$$updatedBy$$", ce.UpdatedBy);
                myString = BindOrgInfo(myString);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for Change Request Review Notification
        public void SendChangeRequestReviewNotification(ChangeRequestReview ce)
        {
            string UserName = "", ApproverEmail = "", ChangeName = "", Category = "", SubCategory = "";

            var data = getChangeManagementDetails(Convert.ToInt32(ce.ChangeID));

            if (data != null)
            {
                ChangeName = data.subject;
                Category = data.category_name;
                SubCategory = data.sub_category_id;

                if (ce.UserID > 0)
                {
                    ApproverEmail = userEmailByID(Convert.ToInt32(ce.UserID));
                    UserName = userNameByID(Convert.ToInt32(ce.UserID));
                }
            }

            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ApproverEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 62;
                t = new UtilityController().GetTemplate(t);

                string myString = "";

                myString = t.Template;

                myString = myString.Replace("$$ChangeName$$", ChangeName);
                myString = myString.Replace("$$UserName$$", UserName);
                myString = myString.Replace("$$Category$$", Category);
                myString = myString.Replace("$$SubCategory$$", SubCategory);
                myString = myString.Replace("$$ChangeID$$", EncryptDecrypt.EncryptUrl(ce.ChangeID.ToString()));
                myString = myString.Replace("$$UserID$$", EncryptDecrypt.EncryptUrl(ce.UserID.ToString()));
                myString = myString.Replace("$$StageID$$", EncryptDecrypt.EncryptUrl(ce.StageID.ToString()));

                myString = BindOrgInfo(myString);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ApproverEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for New Change Request Notification
        public void SendNewChangeRequestNotification(ChangeRequestReview ce)
        {
            string ApproverEmail = "", ChangeName = "", Category = "", SubCategory = "", ChangeReason = "",
                CABMembers = "", ChangeTester = "", ChangeImplementer = "", ChangeReviewer = "", ChangeApprover = "";
            int? ChangeSubmitter = 0;

            var data = getChangeManagementDetails(Convert.ToInt32(ce.ChangeID));

            if (data != null)
            {
                ChangeName = data.subject;
                Category = data.category_name;
                SubCategory = data.sub_category_id;
                ChangeReason = data.change_reason_name;
                CABMembers = data.cab_members;
                ChangeTester = data.tester_id;
                ChangeImplementer = data.implementer_id;
                ChangeReviewer = data.reviewer_id;
                ChangeApprover = data.change_approver_id;
                ChangeSubmitter = data.created_by;

                if (CABMembers != "" && CABMembers != null)
                {
                    ApproverEmail = ApproverEmail + CABMembers;
                }

                if (ChangeSubmitter > 0)
                {
                    if (ApproverEmail == "")
                    {
                        ApproverEmail = ApproverEmail + TechnicianEmailByID(Convert.ToInt32(ChangeSubmitter));
                    }
                    else
                    {
                        ApproverEmail = ApproverEmail + "," + TechnicianEmailByID(Convert.ToInt32(ChangeSubmitter));
                    }
                }

                if (ChangeTester.Length > 0 && ChangeTester != null)
                {
                    var IDs = ChangeTester.Split(',');

                    for (int i = 0; i < IDs.Length; i++)
                    {
                        if (ApproverEmail == "")
                        {
                            ApproverEmail = ApproverEmail + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                        else
                        {
                            ApproverEmail = ApproverEmail + "," + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                    }
                }

                if (ChangeImplementer.Length > 0 && ChangeImplementer != null)
                {
                    var IDs = ChangeImplementer.Split(',');

                    for (int i = 0; i < IDs.Length; i++)
                    {
                        if (ApproverEmail == "")
                        {
                            ApproverEmail = ApproverEmail + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                        else
                        {
                            ApproverEmail = ApproverEmail + "," + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                    }
                }

                if (ChangeReviewer.Length > 0 && ChangeReviewer != null)
                {
                    var IDs = ChangeReviewer.Split(',');

                    for (int i = 0; i < IDs.Length; i++)
                    {
                        if (ApproverEmail == "")
                        {
                            ApproverEmail = ApproverEmail + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                        else
                        {
                            ApproverEmail = ApproverEmail + "," + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                    }
                }

                if (ChangeApprover.Length > 0 && ChangeApprover != null)
                {
                    var IDs = ChangeApprover.Split(',');

                    for (int i = 0; i < IDs.Length; i++)
                    {
                        if (ApproverEmail == "")
                        {
                            ApproverEmail = ApproverEmail + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                        else
                        {
                            ApproverEmail = ApproverEmail + "," + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                    }
                }
            }

            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ApproverEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 63;
                t = new UtilityController().GetTemplate(t);

                string myString = "";

                myString = t.Template;

                myString = myString.Replace("$$ChangeName$$", ChangeName);
                myString = myString.Replace("$$Category$$", Category);
                myString = myString.Replace("$$SubCategory$$", SubCategory);
                myString = myString.Replace("$$ChangeID$$", EncryptDecrypt.EncryptUrl(ce.ChangeID.ToString()));
                myString = myString.Replace("$$ChangeReason$$", ChangeReason);

                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ApproverEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for New Change Request Notification
        public void SendChangeRequestStatusChangeNotification(ChangeRequestReview ce)
        {
            string ApproverEmail = "", ChangeName = "", Category = "", SubCategory = "", ChangeReason = "", OldStatus = "", NewStatus = "",
                CABMembers = "", ChangeTester = "", ChangeImplementer = "", ChangeReviewer = "", ChangeApprover = "";
            int? ChangeSubmitter = 0;

            var data = getChangeManagementDetails(Convert.ToInt32(ce.ChangeID));

            if (data != null)
            {
                ChangeName = data.subject;
                Category = data.category_name;
                SubCategory = data.sub_category_id;
                ChangeReason = data.change_reason_name;
                CABMembers = data.cab_members;
                ChangeTester = data.tester_id;
                ChangeImplementer = data.implementer_id;
                ChangeReviewer = data.reviewer_id;
                ChangeApprover = data.change_approver_id;
                OldStatus = ce.OldStatus;
                NewStatus = ce.NewStatus;
                ChangeSubmitter = data.created_by;


                if (CABMembers != "" && CABMembers != null)
                {
                    ApproverEmail = ApproverEmail + CABMembers;
                }

                if (ChangeSubmitter > 0)
                {
                    if (ApproverEmail == "")
                    {
                        ApproverEmail = ApproverEmail + TechnicianEmailByID(Convert.ToInt32(ChangeSubmitter));
                    }
                    else
                    {
                        ApproverEmail = ApproverEmail + "," + TechnicianEmailByID(Convert.ToInt32(ChangeSubmitter));
                    }
                }

                if (ChangeTester.Length > 0 && ChangeTester != null)
                {
                    var IDs = ChangeTester.Split(',');

                    for (int i = 0; i < IDs.Length; i++)
                    {
                        if (ApproverEmail == "")
                        {
                            ApproverEmail = ApproverEmail + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                        else
                        {
                            ApproverEmail = ApproverEmail + "," + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                    }
                }

                if (ChangeImplementer.Length > 0 && ChangeImplementer != null)
                {
                    var IDs = ChangeImplementer.Split(',');

                    for (int i = 0; i < IDs.Length; i++)
                    {
                        if (ApproverEmail == "")
                        {
                            ApproverEmail = ApproverEmail + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                        else
                        {
                            ApproverEmail = ApproverEmail + "," + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                    }
                }

                if (ChangeReviewer.Length > 0 && ChangeReviewer != null)
                {
                    var IDs = ChangeReviewer.Split(',');

                    for (int i = 0; i < IDs.Length; i++)
                    {
                        if (ApproverEmail == "")
                        {
                            ApproverEmail = ApproverEmail + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                        else
                        {
                            ApproverEmail = ApproverEmail + "," + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                    }
                }

                if (ChangeApprover.Length > 0 && ChangeApprover != null)
                {
                    var IDs = ChangeApprover.Split(',');

                    for (int i = 0; i < IDs.Length; i++)
                    {
                        if (ApproverEmail == "")
                        {
                            ApproverEmail = ApproverEmail + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                        else
                        {
                            ApproverEmail = ApproverEmail + "," + userEmailByID(Convert.ToInt32(IDs[i]));
                        }
                    }
                }
            }

            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ApproverEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 64;
                t = new UtilityController().GetTemplate(t);

                string myString = "";

                myString = t.Template;

                myString = myString.Replace("$$ChangeName$$", ChangeName);
                myString = myString.Replace("$$Category$$", Category);
                myString = myString.Replace("$$SubCategory$$", SubCategory);
                myString = myString.Replace("$$ChangeID$$", EncryptDecrypt.EncryptUrl(ce.ChangeID.ToString()));
                myString = myString.Replace("$$ChangeReason$$", ChangeReason);
                myString = myString.Replace("$$OldStatus$$", OldStatus);
                myString = myString.Replace("$$NewStatus$$", NewStatus);

                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ApproverEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for New Problem Ticket Notification
        public void SendNewProblemTicketNotification(ProblemTicketReview ce)
        {
            int? UserID = 0, Technician = 0;
            string ApproverEmail = "", Name = "", Category = "", SubCategory = "";

            var data = getProblemManagementDetails(Convert.ToInt32(ce.ProblemID));

            if (data != null)
            {
                Name = data.subject;
                Category = data.category_name;
                SubCategory = data.sub_category_id;
                UserID = data.submitted_by_id;
                Technician = data.assign_to;

                if (UserID > 0)
                {
                    ApproverEmail = ApproverEmail + TechnicianEmailByID(Convert.ToInt32(UserID));
                }

                if (Technician > 0 && Technician != null)
                {
                    var IDs = Technician.ToString().Split(',');

                    for (int i = 0; i < IDs.Length; i++)
                    {
                        if (ApproverEmail == "")
                        {
                            ApproverEmail = ApproverEmail + TechnicianEmailByID(Convert.ToInt32(IDs[i]));
                        }
                        else
                        {
                            ApproverEmail = ApproverEmail + "," + TechnicianEmailByID(Convert.ToInt32(IDs[i]));
                        }
                    }
                }
            }

            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ApproverEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 65;
                t = new UtilityController().GetTemplate(t);

                string myString = "";

                myString = t.Template;

                myString = myString.Replace("$$ChangeName$$", Name);
                myString = myString.Replace("$$Category$$", Category);
                myString = myString.Replace("$$SubCategory$$", SubCategory);
                ////myString = myString.Replace("$$ChangeID$$", EncryptDecrypt.EncryptUrl(ce.ProblemID.ToString()));
                ////myString = myString.Replace("$$ChangeReason$$", ChangeReason);

                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ApproverEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        // Send Email for Problem Ticket Status Change Notification
        public void SendProblemStatusChangeNotification(ProblemTicketReview ce)
        {
            int? UserID = 0, Technician = 0;
            string ApproverEmail = "", Name = "", Category = "", SubCategory = "", OldStatus = "", NewStatus = "";

            var data = getProblemManagementDetails(Convert.ToInt32(ce.ProblemID));

            if (data != null)
            {
                Name = data.subject;
                Category = data.category_name;
                SubCategory = data.sub_category_id;
                UserID = data.submitted_by_id;
                Technician = data.assign_to;
                OldStatus = ce.OldStatus;
                NewStatus = ce.NewStatus;

                if (UserID > 0)
                {
                    ApproverEmail = ApproverEmail + TechnicianEmailByID(Convert.ToInt32(UserID));
                }

                if (Technician > 0 && Technician != null)
                {
                    var IDs = Technician.ToString().Split(',');

                    for (int i = 0; i < IDs.Length; i++)
                    {
                        if (ApproverEmail == "")
                        {
                            ApproverEmail = ApproverEmail + TechnicianEmailByID(Convert.ToInt32(IDs[i]));
                        }
                        else
                        {
                            ApproverEmail = ApproverEmail + "," + TechnicianEmailByID(Convert.ToInt32(IDs[i]));
                        }
                    }
                }
            }

            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ApproverEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 66;
                t = new UtilityController().GetTemplate(t);

                string myString = "";

                myString = t.Template;

                myString = myString.Replace("$$Name$$", Name);
                myString = myString.Replace("$$Category$$", Category);
                myString = myString.Replace("$$SubCategory$$", SubCategory);
                myString = myString.Replace("$$OldStatus$$", OldStatus);
                myString = myString.Replace("$$NewStatus$$", NewStatus);
                ////myString = myString.Replace("$$ChangeID$$", EncryptDecrypt.EncryptUrl(ce.ProblemID.ToString()));
                ////myString = myString.Replace("$$ChangeReason$$", ChangeReason);

                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ApproverEmail;
                ea.subject = t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        public string userName(string email)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<string>("select user_name from zdesk_m_users_tbl where email=@email", new { email });
        }

        public string userID(string email)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<string>("select user_id_pk from zdesk_m_users_tbl where email=@email", new { email });
        }

        public string userNameByID(int user_id_pk)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<string>("select user_name from zdesk_m_users_tbl where user_id_pk=@user_id_pk", new { user_id_pk });
        }

        public string userEmailByID(int user_id_pk)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<string>("select email from zdesk_m_users_tbl where user_id_pk=@user_id_pk", new { user_id_pk });
        }

        public string TechnicianEmailByID(int user_id_pk)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<string>("select email from people where id=@user_id_pk", new { user_id_pk });
        }

        public string TechnicianNameByID(int user_id_pk)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<string>("select name from people where id=@user_id_pk", new { user_id_pk });
        }

        public AssetStatus getAssetStatus(int asset_id_pk)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<AssetStatus>(@"select zdesk_m_asset_status_tbl.status,zdesk_m_asset_tbl.asset_tag from zdesk_m_asset_tbl
                                        inner join zdesk_m_asset_status_tbl
                                        on zdesk_m_asset_tbl.status_id_pk
                                            =zdesk_m_asset_status_tbl.status_id_pk
                                                    where zdesk_m_asset_tbl.asset_id_pk=@asset_id_pk", new { asset_id_pk });
        }
        public List<string> getAssetStatusoLd(int asset_id_pk)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<string>(@"select top 1 old_value from zdesk_m_audit_trail_tbl where table_name='zdesk_m_asset_tbl' and field_id = @asset_id_pk and field_name = 'Status' order by update_date desc", new { asset_id_pk }).ToList();
        }
        public string getAssetComponent(int asset_id_fk)
        {
            StringBuilder d = new StringBuilder();
            List<zdesk_t_asset_component_tbl> data = new List<zdesk_t_asset_component_tbl>();
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            data = db.Query<zdesk_t_asset_component_tbl>("Exec zdesk_get_asset_component_list_sp @asset_id_fk", new { asset_id_fk }).ToList();
            if (data != null)
            {
                foreach (var v in data)
                {
                    d.Append(v.component_name + "(" + v.serial_no + "), ");
                }

            }
            else
            {
                d.Append("N/A");
            }


            return d.ToString();
        }

        //Send notification for Asset Upload
        public void SendAssetUploadNotification(TicketReplyStatus ce, HttpPostedFile file)
        {
            using (MailMessage user = new MailMessage(zdesk_M_Smpt_Tbl.FromAddress, ce.ReceiptEmail))
            {
                EmailTemplateModel t = new EmailTemplateModel();
                t.id = 36;
                t = new UtilityController().GetTemplate(t);
                string myString = "";
                myString = t.Template;

                if (ce.CCEmail != null && ce.CCEmail != "")
                {
                    string[] CCId = ce.CCEmail.Split(',');
                    foreach (string CCEmail in CCId)
                    {
                        user.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id  
                    }
                }
                if (file != null)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    user.Attachments.Add(new Attachment(file.InputStream, fileName));
                }
                myString = BindOrgInfo(myString);
                user.Subject = t.subject;
                user.Body = myString.ToString();
                user.IsBodyHtml = true;
                var result = SmtpSend(user);
                zdesk_m_email_audit_tbl ea = new zdesk_m_email_audit_tbl();
                ea.email_to = ce.ReceiptEmail;
                ea.subject = ce.Subject + " " + t.subject;
                ea.status = result.is_sent;
                ea.email_status = result.status;
                ea.error_message = result.exception_message;
                ea.exception_message = result.exception_message;
                ea.exception_type = result.exception_type;
                ea.stack_trace = result.StackTrace;
                new UtilityController().InsMailError(ea);
            }
        }

        public void getMailConfiguration()
        {

            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            zdesk_M_Smpt_Tbl = db.SingleOrDefault<Zdesk_m_smpt_tbl>(@"select * from Zdesk_m_smpt_tbl where IsActive = 1");

        }
        public void getorgInfoConfiguration()
        {

            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            Zdesk_m_logo_tbl = db.SingleOrDefault<Zdesk_m_logo_tbl>(@"select * from Zdesk_m_organization_Info_tbl");

        }

        public string BindOrgInfo(string value)
        {
            value = value.Replace("$$image$$", Zdesk_m_logo_tbl.logo);
            value = value.Replace("$$OrgName$$", Zdesk_m_logo_tbl.OrganizationName);
            value = value.Replace("$$Address$$", Zdesk_m_logo_tbl.Address);
            value = value.Replace("$$Email$$", Zdesk_m_logo_tbl.ApplicationAdmin);

            return value;
        }


        public zdesk_m_preventive_maintainance_activity_tbl getPreventiveMaintenanceDetails(int asset_id, int IsPMID = 0)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            string Query = "";
            //Query += "declare @Prefix Varchar(50),@Prefix_Val Varchar(70); select @Prefix = prefix_value  from zdesk_m_prefix_value_tbl where master_value = 'Preventive Mainatainance';";

            if (IsPMID == 1)
            {
                int p_m_activity_id_pk = asset_id;
                Query += "select * from zdesk_m_preventive_maintainance_activity_tbl where p_m_activity_id_pk=@p_m_activity_id_pk";
                return db.SingleOrDefault<zdesk_m_preventive_maintainance_activity_tbl>(Query, new { p_m_activity_id_pk });
            }
            else
            {
                Query += "select TOP 1 * from zdesk_m_preventive_maintainance_activity_tbl where asset_id=@asset_id order by p_m_activity_id_pk desc";
                return db.SingleOrDefault<zdesk_m_preventive_maintainance_activity_tbl>(Query, new { asset_id });
            }


        }
        public zdesk_m_asset_tbl getAssetDetails(int asset_id_pk, int AllAssets = 0)
        {
            string Query = "";

            if (AllAssets == 1)
            {
                Query = "select * from zdesk_m_asset_tbl where asset_id_pk=@asset_id_pk";
            }
            else
            {
                Query = "select allocated_by,asset_tag,asset_cat_name,manufacturer_name,model_name,serial_number,us.user_name +' ('+us.email+')' AS asset_user_name,us1.name AS asset_admin_name,us1.email as email,asset_user_id FROM zdesk_m_asset_tbl ast LEFT JOIN zdesk_m_users_tbl us on us.user_id_pk=ast.asset_user_id LEFT JOIN people us1 on us1.id=ast.allocated_by where ast.asset_id_pk=@asset_id_pk";
            }
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_asset_tbl>(Query, new { asset_id_pk });
        }

        public zdesk_m_change_management_tbl getChangeManagementDetails(int change_category_id_pk)
        {
            string Query = "";

            Query = "SELECT subject AS subject,category_name AS category_name,sub_cat_name AS sub_category_id,reason_name AS change_reason_name,CAD.cab_members,tester_id,implementer_id,reviewer_id,change_approver_id,created_by FROM zdesk_m_change_management_tbl CM LEFT OUTER JOIN zdesk_m_service_category_tbl cc on CM.common_cat_id_pk=cc.service_cat_id_pk LEFT OUTER JOIN zdesk_m_service_sub_cat_tbl csc on CM.sub_category_id_pk=csc.service_sub_cat_id_pk LEFT OUTER JOIN zdesk_m_reason_for_change_tbl rc ON CM.reason_id_fk=rc.reason_id_pk LEFT OUTER JOIN zdesk_m_change_approval_details_tbl CAD on CAD.change_approval_details_id_pk=CM.change_approval_details_id_fk where change_category_id_pk=@change_category_id_pk";
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_change_management_tbl>(Query, new { change_category_id_pk });
        }

        public zdesk_m_problems_tbl getProblemManagementDetails(int promblems_id_pk)
        {
            string Query = "";

            Query = "SELECT subject AS subject,submitted_by_id,category_name AS category_name,sub_category_name AS sub_category_id,assign_to FROM zdesk_m_problems_tbl CM LEFT OUTER JOIN zdesk_m_common_category_tbl cc on CM.common_cat_id_pk=cc.common_cat_id_pk LEFT OUTER JOIN zdesk_m_common_sub_category_tbl csc on CM.sub_category_id_pk=csc.sub_category_id_pk where promblems_id_pk=@promblems_id_pk";
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_problems_tbl>(Query, new { promblems_id_pk });
        }

        public IEnumerable<ServiceRequestStatus> getServiceRequestDetails(int service_req_id_pk)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<ServiceRequestStatus>("exec zdesk_get_service_req_status_change_send_email_to_user_sp @service_req_id_pk", new { service_req_id_pk });
        }

        public IEnumerable<IncidentRequestStatus> getIncidentRequestDetails(int ticket_id_pk)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<IncidentRequestStatus>("exec zdesk_get_ticket_details_send_email_to_user_sp @ticket_id_pk", new { ticket_id_pk });
        }
    }
}