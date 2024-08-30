using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api_ZserviceDesk.Models
{
    public class EmailTemplateModel
    {
        public Nullable<int> id { get; set; }
        public Nullable<int> templete_type { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }
        public string subject { get; set; }
    }
    public class AssetAllocation
    {
        public string ReceiptEmail { get; set; }
        public int UserID { get; set; }
        public string AssetID { get; set; }
        public string PMID { get; set; }
        public string AssetTag { get; set; }
        public string Category { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string SerialNo { get; set; }
        public string Name { get; set; }
        public string MomentType { get; set; }
        public string GatePasType { get; set; }
        public string Item { get; set; }
        public string TicketID { get; set; }
        public string Qty { get; set; }
        public string Remarks { get; set; }
        public string Status{ get; set; }
        public string user_named { get; set; }
        public string Location { get; set; }
        public string UpdatedBy { get; set; }
        public string AssetImagePath { get; set; }
    }

    public class SoftwareAllocation
    {
        public string ReceiptEmail { get; set; }
        public string AssetID { get; set; }
        public string SoftwareName { get; set; }
        public string Category { get; set; }
        public string LicenseNo { get; set; }
        public string UpdatedBy { get; set; }

    }
    public class Email
    {
        public string FromMail { get; set; }
        public string Tomail { get; set; }
        public string Name { get; set; }
        public string BusinessType { get; set; }
        public string Subject { get; set; }
        public string Url { get; set; }
        public string TemplatePath { get; set; }
        public string status { get; set; }
        public string contact_number { get; set; }
        public string attachment { get; set; }
        public string Month { get; set; }
        public string Link { get; set; }
    }
    public partial class ExceptionTracking
    {
        public string status { get; set; }
        public string message { get; set; }
        public string exception_message { get; set; }
        public string exception_type { get; set; }
        public string StackTrace { get; set; }
        public int is_sent { get; set; }
    }
    public partial class zdesk_m_notification_tbl 
    {
        public Nullable<int> notif_id_pk { get; set; }
        public Nullable<int> category_id_fk { get; set; }
        public Nullable<int> sub_category_id_fk { get; set; }
        public Nullable<int> min_qty { get; set; }
        public Nullable<int> tech_id_fk { get; set; } 
        public string other_tech_email { get; set; }
        public string tech_email { get; set; }
        public string category_name { get; set; }
        public string item_name { get; set; }

    }
    public partial class DirectorsDetails
    {
        public Nullable<int> user_mst_fk { get; set; }
        public Nullable<int> director_mst_pk { get; set; }
        public Nullable<int> isinitiator { get; set; }
        public string first_name { get; set; }
        public string business_type_name { get; set; }
        public string status { get; set; }
        public string email { get; set; }
    }
    public class CourierEmail
    {
        public string ReceiptEmail { get; set; }
        public string TrackingCode { get; set; }
        public string DescriptionCourier { get; set; }
        public string CourierService { get; set; }
        public string DispatchDate { get; set; }
        public string CourierContact { get; set; }
    }
    public class TicketStatus
    {
        public string ReceiptEmail { get; set; }
        public string TicketId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Assign { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }
    }

    public class IncidentRequestStatus
    {
        public string ApproverLevel { get; set; }
        public string ReceiptEmail { get; set; }
        public string AssingTo { get; set; }
        public string AssingDate { get; set; }
        public string AssingBy { get; set; }
        public string UpdatedBy { get; set; }
        public string TicketId { get; set; }
        public int service_req_id_pk { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string UserEmail { get; set; }
        public string TechnicianEmail { get; set; }
        public string Status { get; set; }
        public string NewStatus { get; set; }
        public string OldStatus { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string UrlApp { get; set; }
        public string UrlRej { get; set; }
        public string ApproverID { get; set; }
        public string RequestDescription { get; set; }
        public string UserName { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }

        public string Description { get; set; }
        public string ApproverName { get; set; }
        public string StatusComments { get; set; }
    }

    public class ServiceRequestStatus
    {
        public string ApproverLevel { get; set; }        
        public string ReceiptEmail { get; set; }
        public string AssingTo { get; set; }
        public string AssingDate { get; set; }
        public string AssingBy { get; set; }
        public string UpdatedBy { get; set; }
        public int TicketId { get; set; }
        public int service_req_id_pk { get; set; }
        public string ID { get; set; }
        public string ServiceRequestId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string UserEmail { get; set; }
        public string TechnicianEmail { get; set; }
        public string Status { get; set; }
        public string NewStatus { get; set; }
        public string OldStatus { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string UrlApp { get; set; }
        public string UrlRej { get; set; }
        public string ApproverID { get; set; }
        public string RequestDescription { get; set; }
        public string UserName { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }

        public string Description { get; set; }
        public string ApproverName { get; set; }
        public string StatusComments { get; set; }
        public string StatusComments1 { get; set; }
        public string StatusComments2 { get; set; }
    }
    public class RequestApprovalStatus 
    {
        public string ReceiptEmail { get; set; }
        public string ReqID { get; set; } 
        public string Email { get; set; } 
        public string ContactNo { get; set; } 
        public string Subject { get; set; } 
    }
    public class GatePassStatus
    {
        public string ApproverLevel { get; set; }
        public string ApproverName { get; set; }
        public string ReceiptEmail { get; set; }
        public string GatePassID { get; set; }
        public string Name { get; set; }
        public string MomentType { get; set; }
        public string GatePasType { get; set; }
    }

    public class PurchaseOrderStatus
    {
        public string ID { get; set; }
        public string ApproverLevel { get; set; }
        public string ApproverName { get; set; }
        public string ReceiptEmail { get; set; }
        public string PurchaseOrderID { get; set; }
        public string Name { get; set; }
        public string POName { get; set; }
        //////public string MomentType { get; set; }
        //////public string GatePasType { get; set; }
    }

    public class AssetStatus
    {
        public string status { get; set; }
        public string asset_tag { get; set; }
    }
    public class TicketReplyStatus
    {
        public string ReceiptEmail { get; set; }
        public string CCEmail { get; set; }
        public string TicketId { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Remaining_Time { get; set; }
        public string UserName { get; set; }
        public string AssignTo { get; set; }
        public string TicketStatus { get; set; }
        public string url { get; set; }
    }
    public class ServiceRequestReplyStatus
    {
        public string ReceiptEmail { get; set; }
        public string CCEmail { get; set; }
        public string RequestID { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
    public partial class GSTDetail
    {
        public string UserName { get; set; }
        public string ReceiptEmail { get; set; }
        public string gstin_no { get; set; }
        public string login_id { get; set; }
        public string gst_password { get; set; }
        public string trn_no { get; set; }
        public string arn_no { get; set; }
        public string gstin_issue_date { get; set; }
        public string attachment { get; set; }
    }
    public partial class TestingPopulation
    {
        public float Male { get; set; }
        public float Female { get; set; }
        public float Others { get; set; }
        public string Country { get; set; }
    }

    public class UserStatusChnage
    {
        public string ReceiptEmail { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
       

    }

    public class linkStatusChange
    {
        public string ipAddress { get; set; }
        public string ipStatus { get; set; }
        public string ReceiptEmail { get; set; }
    }

    public class ChangeRequestReview
    {
        public string ChangeID { get; set; }
        public int UserID { get; set; }
        public int StageID { get; set; }
        public string ReceiptEmail { get; set; }
        public string UserName { get; set; }
        public string ChangeName { get; set; }
        public string ChangeReason { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Subject { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
    }

    public class ProblemTicketReview
    {
        public string ProblemID { get; set; }
        public int UserID { get; set; }
        public int StageID { get; set; }
        public string ReceiptEmail { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Subject { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
    }
}