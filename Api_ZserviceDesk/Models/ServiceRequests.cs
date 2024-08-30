using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public partial class zdesk_m_request_approval_tbl 
    {
        public string incident_id { get; set; }
        public string location_name { get; set; } 
        public string sub_location { get; set; } 
        public string room_no { get; set; } 
        public Nullable<int> location_id_fk { get; set; }
        public Nullable<int> sub_location_id_fk { get; set; }
        public Nullable<int> floor_id_fk { get; set; } 
        public Nullable<int> req_app_id_pk { get; set; } 
        public string subject { get; set; }
        public string category_name { get; set; } 
        public string sub_category_name { get; set; }
        public string name { get; set; } 
        
        public Nullable<int> category_id_fk { get; set; }
        public Nullable<int> sub_category_id_fk { get; set; } 
        public string description { get; set; }
        public Nullable<int> user_id_fk { get; set; }
        public string user_contact_no { get; set; }
        public string user_email { get; set; } 
        public string user_department { get; set; } 
        public Nullable<int> app_id_fk { get; set; }  
        public Nullable<int> is_active { get; set; }
    }
    public partial class Zdesk_m_Incident_to_Service
    {
        public string ids { get; set; }
        public string ddlServiceCategoryid { get; set; }
        public string ddlServiceSubCategoryid { get; set; }
    }
    public partial class zdesk_m_service_request_tbl
    {
        public string ids { get; set; }
        public string ddlServiceCategoryid { get; set; }
        public string ddlServiceSubCategoryid { get; set; }
        public Nullable<int> consultant_id_fk { get; set; }
        public Nullable<int> pending_category_id { get; set; }
        public Nullable<int> pending_reason_id_fk { get; set; }
        public Nullable<int> is_sla_applicable { get; set; }
        public Nullable<int> is_satisfied_id { get; set; }
        public Nullable<int> supplier_id_fk { get; set; }
        public Nullable<int> closer_id_fk { get; set; }
        public string asset_category_id_fk { get; set; }
        public string user_con_no { get; set; }
        public string sla_applicable { get; set; }
        public string pending_remarks { get; set; }
        public string department_name { get; set; }
        public string closer_code { get; set; }
        public string SlaStatus { get; set; }
        public string feedback { get; set; }
        public int IncidentId { get; set; }
        public Nullable<int> mapping_priority_id_pk { get; set; }
        public Nullable<int> service_req_id_pk { get; set; }
        public Nullable<int> ser_req_status_id_pk { get; set; }
        public Nullable<int> p_def_r_id_fk { get; set; }
        public Nullable<int> tecnician_id { get; set; }
        public string tech_id { get; set; }
        public string client_name { get; set; }
        public string user_name { get; set; }
        public string user_sub_location { get; set; }
        public string email_id { get; set; }
        public string LOCATION { get; set; }
        public string ASSIGNED_ENGINEER { get; set; }
        public string USER_CONTACT_NUMBER { get; set; }
        public string USER_EMAIL { get; set; }
        public Nullable<DateTime> RESLOVED_DATE { get; set; }
        public string PRIORITY { get; set; }
        public string SUPPORT_DEPARTMENT { get; set; }
        public string SUPPORT_DEPARTMENT_GROUP { get; set; }
        public string CATEGORY { get; set; }
        public string SUB_CATEGORY { get; set; }
        public string building_room_no { get; set; }
        public string mobile_no { get; set; }
        public string content { get; set; }
        public string business_unit { get; set; }
        public string created_by { get; set; }
        public string prefix { get; set; }
        public string ticket_prefix_val { get; set; }
        public string subject { get; set; }
        public string status { get; set; }
        public string ser_req_status { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public Nullable<int> support_dep_id_pk { get; set; }
        public Nullable<int> support_group_id_fk { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> logged_date { get; set; }
        public string logged_time { get; set; }
        public Nullable<DateTime> response_date { get; set; }
        public string response_time { get; set; }
        public Nullable<DateTime> resolution_date { get; set; }
        public string non_negative { get; set; }
        public string resolution_time { get; set; }
        public Nullable<int> client_id_pk { get; set; }
        public Nullable<int> asign_to { get; set; }
        public Nullable<int> asset_id_pk { get; set; }
        public Nullable<int> common_cat_id_pk { get; set; }
        public Nullable<int> admin_id { get; set; }
        public Nullable<int> sub_category_id_pk { get; set; }
        public string message { get; set; }
        public Nullable<int> send_ticket_notification { get; set; }
        public Nullable<int> priority_id_pk { get; set; }
        public Nullable<int> is_active { get; set; }
        public string support_dep_name { get; set; }
        public string support_dep_group_name { get; set; }
        public string title { get; set; }
        public string asset_name { get; set; }
        public string category_name { get; set; }
        public string sub_category_name { get; set; }
        public string sub_cat_name { get; set; }
        public string priority_name { get; set; }
        public string logged_via { get; set; }
        public Nullable<int> department_id_fk { get; set; }
        public Nullable<int> user_id_fk { get; set; }
        public Nullable<int> urgency_id_fk { get; set; }
        public Nullable<int> impact_id_fk { get; set; }
        public Nullable<int> location_id_fk { get; set; }
        public Nullable<int> is_send_email { get; set; }
        public Nullable<int> is_send_message { get; set; }
        public string location_id { get; set; }
        public string user_id { get; set; }
        public string client_id { get; set; }
        public string department_id { get; set; }
        public string priority_id { get; set; }
        public string common_cat_id { get; set; }
        public string sub_category_id { get; set; }
        public Nullable<DateTime> from_date { get; set; }
        public Nullable<DateTime> to_date { get; set; }
        public string resolution_sla { get; set; }
        public string response_sla { get; set; }
        public Nullable<int> is_purchase_required { get; set; }
        public Nullable<decimal> cost { get; set; }
        public string catalogue_description { get; set; }
        public Nullable<int> approval_required { get; set; }
        public Nullable<int> sub_location_id_fk { get; set; }
        public Nullable<int> section_id_fk { get; set; }
        public Nullable<int> floor_id_fk { get; set; }
        public string sub { get; set; }
        public string sub_location { get; set; }
        public string section_name { get; set; }
        public string consultant_name { get; set; }
        public string consultant_contact { get; set; }
        public string consultant_email { get; set; }
        public string floor_name { get; set; }
        public string gate { get; set; }
        public string custom_field_s_no { get; set; }
        public string custom_field_make { get; set; }
        public string custom_field_model { get; set; }
        public string approver_one { get; set; }
        public string approver_two { get; set; }
        public string approver_three { get; set; }
        public int other_approver { get; set; }
        public int approver1 { get; set; }
        public int approver2 { get; set; }
        public int approver3 { get; set; }
        public int approver1_status { get;set;}
        public int approver2_status { get;set;}
        public int approver3_status { get;set;}
        public int other_approver_status { get;set;}
        public int approval_type { get;set;}
        public string resolution_notes { get; set; }
        public int login_id { get; set; }
        public string approver_id_email { get; set; }        
        public string approver_name { get; set; }
        public int ApproverLevel { get; set; }
        public Nullable<int> service_request_status { get; set; }
        public string approver_comments { get; set; }
        public string approver_comments1 { get; set; }
        public string approver_comments2 { get; set; }
        public string Approval_status { get; set; }
        public Nullable<int> updated_by { get; set; }
        public string status_comments { get; set; }
    }
    public partial class zdesk_m_service_request_templete_tbl
    {
        public int approval_type { get; set; }
        public Nullable<int> service_req_templete_id_pk { get; set; }
        //public Nullable<int> ser_req_status_id_pk { get; set; }
        public string template_name { get; set; }
        public string logged_via { get; set; }
        public Nullable<int> common_cat_id_pk { get; set; }
        public Nullable<int> sub_category_id_pk { get; set; }
        public string request_desc { get; set; }
        public string catalogue_description { get; set; }
        public Nullable<int> is_purchase_required { get; set; }
        public Nullable<decimal> cost { get; set; }
        //public Nullable<int> fulfilment_time { get; set; }
        public Nullable<int> approval_required { get; set; }
        public Nullable<int> approver_level1 { get; set; }
        public Nullable<int> approver_level2 { get; set; }
        public Nullable<int> approver_level3 { get; set; }
        public string other_approver { get; set; }
        public Nullable<int> user_id_fk { get; set; }
        public string mobile { get; set; }
        public Nullable<int> asset_id_pk { get; set; }
        public string serial_no { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int business_unit { get; set; }
        public Nullable<int> location_id_fk { get; set; }
        public Nullable<int> department_id_fk { get; set; }
        public int building { get; set; }
        public int floor { get; set; }
        public string fulfilment_time { get; set; }
        public int room_no { get; set; }
        public int is_sla { get; set; }
        public int severity_id_fk { get; set; }
        public Nullable<int> support_dep_id_pk { get; set; }
        public Nullable<int> support_group_id_fk { get; set; }
        public int technician_id_fk { get; set; }
        public Nullable<int> admin_id { get; set; }
        public Nullable<int> reporting_manager { get; set; }
        public Nullable<int> department_head { get; set; }
        public Nullable<int> business_head { get; set; }
        public Nullable<int> supp_group_head { get; set; }
        public Nullable<int> supp_org_head { get; set; }
        public string client_name { get; set; }
        public string prefix { get; set; }
        public string ticket_prefix_val { get; set; }
        public string subject { get; set; }
        public string status { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> logged_date { get; set; }
        public string logged_time { get; set; }
        public Nullable<DateTime> response_date { get; set; }
        public string response_time { get; set; }
        public Nullable<DateTime> resolution_date { get; set; }
        public string resolution_time { get; set; }
        public Nullable<int> client_id_pk { get; set; }
        public Nullable<int> asign_to { get; set; }
        public string message { get; set; }
        public Nullable<int> send_ticket_notification { get; set; }
        public Nullable<int> priority_id_pk { get; set; }
        public Nullable<int> is_active { get; set; }
        public string support_dep_name { get; set; }
        public string support_dep_group_name { get; set; }
        public string title { get; set; }
        public string asset_name { get; set; }
        public string category_name { get; set; }
        public string sub_category_name { get; set; }
        public string sub_cat_name { get; set; }
        public string priority_name { get; set; }
        public Nullable<int> urgency_id_fk { get; set; }
        public Nullable<int> impact_id_fk { get; set; }
        
        public Nullable<int> is_send_email { get; set; }
        public Nullable<int> is_send_message { get; set; }
    }
    public class zdesk_m_service_req_status_tbl
    {
        public Nullable<int> service_req_id_pk { get; set; }
        public Nullable<int> ser_req_status_id_pk { get; set; }
        public string ser_req_status { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
    }
    public class zdesk_t_service_req_approval_status_tbl
    {
        public Nullable<int> ser_req_approval_id_pk { get; set; }
        public Nullable<int> service_req_id_fk { get; set; }
        public Nullable<int> approver_id_pk { get; set; }
        public Nullable<int> ser_req_approval_status { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public string status { get; set; }
        public string email { get; set; }
        public string user_name { get; set; }
        public string title { get; set; }
        public string display_name { get; set; }
        public string approver_comments { get; set; }
    }
    public class zdesk_m_service_req_predefine_reply_tbl
    {
        public Nullable<int> p_def_r_id_pk { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<int> updated_by { get; set; }
    }
    public class zdesk_t_service_request_reply_conversation_tbl
    {
        public Nullable<int> ser_req_rep_conv_id_pk { get; set; }
        public int role_id { get; set; }
        public Nullable<int> ser_req_id_fk { get; set; }
        public Nullable<int> tkt_rep_conv_id_pk { get; set; }
        public Nullable<int> ticket_id_fk { get; set; }
        public int is_file { get; set; }
        public int is_read_user { get; set; }
        public int is_read { get; set; }
        public string reply_description { get; set; }
        public string to_email { get; set; }
        public string cc_email { get; set; }

        public string filepath { get; set; }

        public string name { get; set; }
        public Nullable<int> technician_id_fk { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<int> updated_by { get; set; }
        public Nullable<DateTime> created_date { get; set; }
    }
    public class zdesk_m_service_category_tbl
    {
        public int service_cat_id_pk { get; set; }
        public string category_name { get; set; }
        public int is_active { get; set; }
        public DateTime created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public Nullable<int> updated_by { get; set; }
        public int template_count { get; set; }
    }
    public class zdesk_m_service_sub_cat_tbl
    {
        public int service_sub_cat_id_pk { get; set; }
        public int service_cat_id_fk { get; set; }
        public string category_name { get; set; }
        public string sub_cat_name { get; set; }
        public int is_active { get; set; }
        public DateTime created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public Nullable<int> updated_by { get; set; }

    }

    public partial class zdesk_m_service_request_status_update_tbl
    {
        public Nullable<int> service_request_status_id_pk { get; set; }
        public Nullable<int> service_req_id_pk { get; set; }
        public Nullable<int> ser_req_status_id_pk { get; set; }
        public Nullable<int> updated_by { get; set; }
        public string status_comments { get; set; }
        public string status_name { get; set; }
        public string updated_by_name { get; set; }
        public DateTime updated_date { get; set; }
    }
}