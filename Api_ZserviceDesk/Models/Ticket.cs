using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public partial class zdesk_m_departments_tbl
    {

        public Nullable<int> user_id_pk { get; set; }
        public Nullable<int> department_id_pk { get; set; }
        public Nullable<int> business_unit_id_fk { get; set; }
        public Nullable<int> department_head { get; set; }
        public string department_name { get; set; }
        public string business_unit { get; set; }
        public string email { get; set; }
        public Nullable<int> is_active { get; set; }
    }
    public partial class zdesk_m_clients_tbl
    {
        public Nullable<int> client_id_pk { get; set; }
        public string client_name { get; set; }
        public Nullable<int> is_active { get; set; }
    }
    public partial class zdesk_m_tickets_predefine_reply_tbl
    {
        public Nullable<int> p_def_r_id_pk { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public Nullable<int> is_active { get; set; }
    }
    public partial class zdesk_t_master_tickets_mapping_tbl
    {
        public Nullable<int> master_ticket_id_pk { get; set; }
        public Nullable<int> parent_ticket_id_fk { get; set; }
        public Nullable<int> child_ticket_id_fk { get; set; }
        public Nullable<int> is_active { get; set; }
    }
    public class IncidentSlaPercentage
    {
        public string Status { get; set; }
        public Nullable<decimal> Total { get; set; }

    }

    public partial class zdesk_m_tickets_tbl_new
    {
        public string ddlMake { get; set; }
        public int ServiceId { get; set; }
        public string ddlHDD { get; set; }
        public string ddlOS { get; set; }
        public string ddlCPU { get; set; }
        public string ddlCPUcore { get; set; }
        public string ddlRAM { get; set; }
        public string pending_s { get; set; }
        public string ddlAssetToBeCollected { get; set; }
        public string completed_s { get; set; }
        public string Technician_Id { get; set; }
        public string SupportDepartment_Id { get; set; }
        public string ChangeType_Id { get; set; }
        public string ReasonForChange_Id { get; set; }
        public string TaskType_Id { get; set; }
        public string SupportGroup_Id { get; set; }
        public string ticket_id { get; set; }
        public int login_id { get; set; }
        public string workaround { get; set; }
        public string logged_by { get; set; }
        public string cust_location { get; set; }
        public string cust_sub_location { get; set; }
        public string issue_type { get; set; }
        public Nullable<int> issue_type_id_fk { get; set; }
        public Nullable<int> ticket_id_pk { get; set; }
        public Nullable<int> is_sla_applicable { get; set; }
        public string building_room_no { get; set; }
        public string gate { get; set; }
        public string sub_location { get; set; }
        public string user_sub_location { get; set; }
        public string location_name { get; set; }
        public string section_name { get; set; }
        public string floor_name { get; set; }
        public string department_name { get; set; }
        public string LOCATION { get; set; }
        public string ASSIGNED_ENGINEER { get; set; }
        public string USER_CONTACT_NUMBER { get; set; }
        public string USER_EMAIL { get; set; }
        public Nullable<int> consultant_id_fk { get; set; }
        public string consultant_name { get; set; }
        public string PRIORITY { get; set; }
        public string SUPPORT_DEPARTMENT { get; set; }
        public string SUPPORT_DEPARTMENT_GROUP { get; set; }
        public string CATEGORY { get; set; }
        public string SUB_CATEGORY { get; set; }
        public Nullable<int> support_dep_id_pk { get; set; }
        public string prefix { get; set; }
        public string subject { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string business_unit { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> logged_date { get; set; }
        public string logged_time { get; set; }
        public Nullable<int> priority_id_pk { get; set; }
        public string status { get; set; }
        public string non_negative { get; set; }
        public Nullable<DateTime> from_date { get; set; }
        public Nullable<DateTime> to_date { get; set; }
        public string location_id { get; set; }
        public string user_id { get; set; }
        public string email_id { get; set; }
        public string client_id { get; set; }
        public string incident_id { get; set; }
        public string department_id { get; set; }
        public string priority_id { get; set; }
        public string common_cat_id { get; set; }
        public string sub_category_id { get; set; }
        public string logged_via { get; set; }
        public string ticket_status { get; set; }
        public string pending_reason_id_fk_id { get; set; }
        public string resolution_sla_id { get; set; }
        public string response_sla_id { get; set; }
        public string pending_category { get; set; }
        public string asset_category { get; set; }
        public string range { get; set; }
        public string SlaStatus { get; set; }
        public int user_id_fk { get; set; }
        public string user_name { get; set; }
        public string mobile { get; set; }
        public string support_dep_name { get; set; }
        public string support_dep_group_name { get; set; }
        public string vip { get; set; }
        public Nullable<int> parent_ticket_id_fk { get; set; }
        public string asset_name { get; set; }
        public Nullable<int> asset_id_pk { get; set; }
        public string category_name { get; set; }
        public string sub_category_name { get; set; }
        public string message { get; set; }
        public Nullable<DateTime> response_date { get; set; }
        public string response_time { get; set; }
        public Nullable<DateTime> resolution_date { get; set; }
        public string resolution_time { get; set; }
        public string priority_name { get; set; }
        public Nullable<int> ticket_status_id_pk { get; set; }
        public string closer_code { get; set; }
        public Nullable<int> feedback { get; set; }
        public string call_status { get; set; }
        public string reason_for_reopen { get; set; }
        public string spare_name { get; set; }
        public string part_no { get; set; }
        public string spare_description { get; set; }
        public int time { get; set; }
        public string resolution_sla { get; set; }
        public string total_sla_minute { get; set; }
        public string extra_minute { get; set; }
        public string response_sla { get; set; }
        public string sla_applicable { get; set; }
        public string sla_name_type { get; set; }
        public string MAKE { get; set; }
        public string MODEL { get; set; }
        public string SERIAL_NO { get; set; }
        public string user_con_no { get; set; }
        public string obser_notes { get; set; }
        public string resolution_notes { get; set; }
        public string content { get; set; }
        public Nullable<int> p_def_r_id_fk { get; set; }
        public Nullable<int> new_s { get; set; }
        public Nullable<int> assigned_s { get; set; }
        public Nullable<int> in_progress_s { get; set; }
        public Nullable<int> pause_s { get; set; }
        public Nullable<int> resolved_s { get; set; }
        public Nullable<int> reopened_s { get; set; }
        public Nullable<int> closed_s { get; set; }
        public Nullable<int> cancel_s { get; set; }
        public Nullable<int> sr_to_inc { get; set; }
        public int incidents { get; set; }
        public int service_request { get; set; }
        public int total { get; set; }
        public string ColumnName { get; set; }
        public string ReportName { get; set; }
        public string ReportId { get; set; }
        public bool IsScheduler { get; set; }
        public string Report_Time { get; set; }
        public string Email_To { get; set; }
        public string Email_cc { get; set; }
        public string Email_Subject { get; set; }
        public int ReportTemplate_Id { get; set; }
        public int Report_Type { get; set; }
        public string ddlUserFltr { get; set; }
        public int ddlWarrenty { get; set; }
        public int SelectedValue { get; set; }
        public string vandor { get; set; }
        public string manufacture { get; set; }
        public Nullable<DateTime> Datepurchase { get; set; }
        public Nullable<DateTime> Datewarranty { get; set; }
        public Nullable<DateTime> Dateamcend { get; set; }
        public int assetType { get; set; }
        public int ReportType { get; set; }
        public Nullable<int> pending_category_id { get; set; }
        public Nullable<int> pending_reason_id_fk { get; set; }
        public Nullable<int> common_cat_id_pk { get; set; }
        public Nullable<int> support_group_id_fk { get; set; }
        public Nullable<int> client_id_pk { get; set; }
        public int location_id_fk { get; set; }
        public Nullable<int> sub_location_id_fk { get; set; }
        public Nullable<int> section_id_fk { get; set; }
        public Nullable<int> floor_id_fk { get; set; }
        public Nullable<int> support_type { get; set; }
        public int? is_defective { get; set; }
        public int call_type { get; set; }
        public Nullable<int> asset_category_id_fk { get; set; }
        public Nullable<int> supplier_id_fk { get; set; }
        public Nullable<int> closer_id_fk { get; set; }
        public string pending_remarks { get; set; }
        public string pending_reason_name { get; set; }
        public string sub { get; set; }
        public string consultant_contact { get; set; }
        public string consultant_email { get; set; }
        public Nullable<int> problem_id_fk { get; set; }
        public Nullable<int> asset_user_id { get; set; }
        public string client_name { get; set; }
        public string negative { get; set; }
        public string ticket_prefix_val { get; set; }
        public string created_by { get; set; }
        public string mobile_no { get; set; }
        public Nullable<int> asign_to { get; set; }
        public string asset_tag { get; set; }
        public Nullable<int> admin_id { get; set; }
        public Nullable<int> sub_category_id_pk { get; set; }
        public Nullable<int> send_ticket_notification { get; set; }
        public Nullable<int> is_active { get; set; }
        public string title { get; set; }
        public Nullable<int> logged { get; set; }
        public int department_id_fk { get; set; }
        public int urgency_id_fk { get; set; }
        public int impact_id_fk { get; set; }
        public int is_send_email { get; set; }
        public int is_send_message { get; set; }
        public int updated_by { get; set; }
        public int tecnician_id { get; set; }

        public int under_Approval_s { get; set; }
        public int approved_s { get; set; }
        public int under_Review_s { get; set; }
        public int reviewed_s { get; set; }
        public int implemented_s { get; set; }
        public int cancelled_s { get; set; }
        public int rejected_s { get; set; }
        public int postponed_s { get; set; }
        //public string CALL_TYPE_VALUE { get; set; }
        //public Nullable<DateTime> RESLOVED_DATE { get; set; }
        //public Nullable<DateTime> Call_Assigned_Date { get; set; }

        //public string Issue_Observed { get; set; }
        //public string Solution_Update { get; set; }
        //public string Reason_For_Reopen { get; set; }

        //public string Defective_Spare { get; set; }
        //public string Defective_Spare_Part_No { get; set; }
        //public string Resolved_Engineer_Contact_Number { get; set; }
        public string pass_status { get; set; }
        public string TAT { get; set; }
        public string SLA_STATUS { get; set; }
        public int ddlWeekDay { get; set; }
        public int ddlMonthdate { get; set; }
        public string custom_field_s_no { get; set; }
        public string custom_field_make { get; set; }
        public string custom_field_model { get; set; }
        public int attach_id_pk { get; set; }
        public int is_read { get; set; }
        public string to_email { get; set; }
        public string cc_email { get; set; }
        public int is_parent { get; set; }
        public int is_child { get; set; }
        public string ref_id { get; set; }
        public Nullable<int> ReportCategory { get; set; }
        public string Section { get; set; }
    }
    public partial class zdesk_m_tickets_tbl
    {
        public string Technician_Id { get; set; }
        public string ddlAssetToBeCollected { get; set; }
        public string ddlMake { get; set; }
        public string ddlHDD { get; set; }
        public string ddlOS { get; set; }
        public string ddlCPU { get; set; }
        public string ddlCPUcore { get; set; }
        public string ddlRAM { get; set; }
        public string SupportDepartment_Id { get; set; }
        public string ChangeType_Id { get; set; }
        public string ReasonForChange_Id { get; set; }
        public string TaskType_Id { get; set; }
        public string SupportGroup_Id { get; set; }
        public Nullable<int> approver_id { get; set; }
        public Nullable<int> approver_id1 { get; set; }
        public Nullable<int> approver_id2 { get; set; }
        public Nullable<int> approver_status { get; set; }
        public Nullable<int> approver_status1 { get; set; }
        public Nullable<int> approver_status2 { get; set; }
        public string logged_by { get; set; }
        public string cust_location { get; set; }
        public string cust_sub_location { get; set; }
        public Nullable<int> issue_type_id_fk { get; set; }
        public Nullable<int> support_type { get; set; }
        public int? is_defective { get; set; }
        public Nullable<int> consultant_id_fk { get; set; }
        public Nullable<int> parent_ticket_id_fk { get; set; }
        public int location_id_fk { get; set; }
        public int call_type { get; set; }
        public string range { get; set; }
        public string call_status { get; set; }
        public string user_con_no { get; set; }
        public string user_email { get; set; }
        public string SlaStatus { get; set; }
        public string spare_name { get; set; }
        public string part_no { get; set; }
        public string spare_description { get; set; }
        public string obser_notes { get; set; }
        public string reason_for_reopen { get; set; }
        public string vip { get; set; }
        public int SelectedValue { get; set; }
        public string asset_category { get; set; }
        public string pending_reason_id_fk_id { get; set; }
        public string resolution_sla_id { get; set; }
        public string response_sla_id { get; set; }
        public Nullable<int> pending_category_id { get; set; }
        public Nullable<int> asset_category_id_fk { get; set; }
        public Nullable<int> pending_reason_id_fk { get; set; }
        public Nullable<int> supplier_id_fk { get; set; }
        public Nullable<int> closer_id_fk { get; set; }
        public Nullable<int> updatedBy { get; set; }
        public string pending_remarks { get; set; }
        public string pending_reason_name { get; set; }
        public string Asset_Category { get; set; }
        public string gate { get; set; }
        public string closer_code { get; set; }
        public string cost { get; set; }
        public Nullable<int> sub_location_id_fk { get; set; }
        public Nullable<int> section_id_fk { get; set; }
        public Nullable<int> floor_id_fk { get; set; }
        public string sub { get; set; }
        public string building_room_no { get; set; }
        public string sub_location { get; set; }
        public string section_name { get; set; }
        public string consultant_name { get; set; }
        public string consultant_contact { get; set; }
        public string consultant_email { get; set; }
        public string floor_name { get; set; }
        public string pending_category { get; set; }
        public Nullable<int> ticket_id_pk { get; set; }
        public Nullable<int> p_def_r_id_fk { get; set; }
        public Nullable<int> is_sla_applicable { get; set; }
        public Nullable<int> problem_id_fk { get; set; }
        public Nullable<int> asset_user_id { get; set; }
        public Nullable<int> feedback { get; set; }
        public Nullable<int> ticket_status_id_pk { get; set; }
        public string client_name { get; set; }
        public string negative { get; set; }
        public string non_negative { get; set; }
        public string resolution_notes { get; set; }
        public string business_unit { get; set; }
        public string location_id { get; set; }
        public string user_id { get; set; }
        public string email_id { get; set; }
        public string client_id { get; set; }
        public string incident_id { get; set; }
        public string department_id { get; set; }
        public string priority_id { get; set; }
        public string common_cat_id { get; set; }
        public string sub_category_id { get; set; }
        public string prefix { get; set; }
        public string ticket_prefix_val { get; set; }
        public string subject { get; set; }
        public int incidents { get; set; }
        public int service_request { get; set; }
        public int total { get; set; }
        public string status { get; set; }
        public string ticket_status { get; set; }
        public string user_name { get; set; }
        public string created_by { get; set; }
        public Nullable<DateTime> from_date { get; set; }
        public Nullable<DateTime> to_date { get; set; }
        public string content { get; set; }
        public string email { get; set; }
        public string total_sla_minute { get; set; }
        public string extra_minute { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public string mobile_no { get; set; }
        public Nullable<int> support_dep_id_pk { get; set; }
        public Nullable<int> support_group_id_fk { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> logged_date { get; set; }
        public string logged_time { get; set; }
        public Nullable<DateTime> response_date { get; set; }
        public string response_time { get; set; }
        public Nullable<DateTime> resolution_date { get; set; }
        public string resolution_time { get; set; }
        public Nullable<int> client_id_pk { get; set; }
        public Nullable<int> asign_to { get; set; }
        public Nullable<int> asset_id_pk { get; set; }
        public string asset_tag { get; set; }
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
        public string priority_name { get; set; }
        public string logged_via { get; set; }
        public string resolution_sla { get; set; }
        public string response_sla { get; set; }
        public Nullable<int> logged { get; set; }
        public int department_id_fk { get; set; }
        public int time { get; set; }
        public int user_id_fk { get; set; }
        public int urgency_id_fk { get; set; }
        public int impact_id_fk { get; set; }

        public int is_send_email { get; set; }
        public int is_send_message { get; set; }
        public int updated_by { get; set; }
        public int tecnician_id { get; set; }
        public string ColumnName { get; set; }
        public string ReportName { get; set; }
        public string ReportId { get; set; }
        public bool IsScheduler { get; set; }
        public string Report_Time { get; set; }
        public string Email_To { get; set; }
        public string Email_cc { get; set; }
        public string Email_Subject { get; set; }
        public int Report_Type { get; set; }
        //  public int ROOM_NO { get; set; }
        public string department_name { get; set; }
        public string LOCATION { get; set; }
        //public int STATUS { get; set; } 
        public string ASSIGNED_ENGINEER { get; set; }
        public string USER_CONTACT_NUMBER { get; set; }
        public string CALL_TYPE_VALUE { get; set; }
        public string USER_EMAIL { get; set; }
        public Nullable<DateTime> RESLOVED_DATE { get; set; }
        public Nullable<DateTime> Call_Assigned_Date { get; set; }
        public string MAKE { get; set; }
        public string MODEL { get; set; }
        public string SERIAL_NO { get; set; }
        public string Issue_Observed { get; set; }
        public string Solution_Update { get; set; }
        public string Reason_For_Reopen { get; set; }
        public string PRIORITY { get; set; }
        public string Defective_Spare { get; set; }
        public string Defective_Spare_Part_No { get; set; }
        public string Resolved_Engineer_Contact_Number { get; set; }
        public string Warranty_Status { get; set; }
        public string TAT { get; set; }
        public string SLA_STATUS { get; set; }
        public string SUPPORT_DEPARTMENT { get; set; }
        public string SUPPORT_DEPARTMENT_GROUP { get; set; }
        public string CATEGORY { get; set; }
        public string SUB_CATEGORY { get; set; }
        public string sla_applicable { get; set; }
        public string ddlUserFltr { get; set; }
        public int ddlWarrenty { get; set; }
        public int ReportType { get; set; }
        public string vandor { get; set; }
        public string manufacture { get; set; }
        public Nullable<DateTime> Datepurchase { get; set; }
        public Nullable<DateTime> Datewarranty { get; set; }
        public Nullable<DateTime> Dateamcend { get; set; }
        public int assetType { get; set; }
        public int ddlWeekDay { get; set; }
        public int ddlMonthdate { get; set; }
        public string sla_name_type { get; set; }
        public string custom_field_s_no { get; set; }
        public string custom_field_make { get; set; }
        public string custom_field_model { get; set; }
        public Nullable<int> new_s { get; set; }
        public Nullable<int> assigned_s { get; set; }
        public Nullable<int> in_progress_s { get; set; }
        public Nullable<int> pause_s { get; set; }
        public Nullable<int> resolved_s { get; set; }
        public Nullable<int> reopened_s { get; set; }
        public Nullable<int> closed_s { get; set; }
        public Nullable<int> cancel_s { get; set; }
        public Nullable<int> sr_to_inc { get; set; }
        public string sub_location_id { get; set; }
        public string condition_id_fk { get; set; }
        public string asset_support_id { get; set; }
        public string po_number { get; set; }
        public string invoice_number { get; set; }
        public Nullable<int> warranty_end_id { get; set; }
        public Nullable<DateTime>  warranty_end_from { get; set; }
        public Nullable<DateTime>  warranty_end_to { get; set; }
        public Nullable<int> amc_end_id { get; set; }
        public Nullable<DateTime> amc_end_from { get; set; }
        public Nullable<DateTime> amc_end_to { get; set; }
        public string make { get; set; }
        public string model{ get; set; }
		public string serial_no{ get; set; }
		public string pass_status{ get; set; }
		public string pass_id{ get; set; }
    }
    public class zdesk_t_attach_incidents_problem_tbl
    {
        public Nullable<int> att_incident_problem_id_pk { get; set; }
        public Nullable<int> ticket_id_fk { get; set; }
        public Nullable<int> problem_id_fk { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<int> updated_by { get; set; }
        public Nullable<DateTime> created_date { get; set; }
    }
    public class Vendornotification
    {
        public string VendorName { get; set; }
        public DateTime CreateDate { get; set; }
        public string VendorEmail { get; set; }
        public string subject { get; set; }
        public string Message { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string serialno { get; set; }
        public string expressCode { get; set; }
        public string Ticket_Id_pk { get; set; }


    }
    public class zdesk_t_ticket_reply_conversation_tbl
    {
        public int tkt_rep_conv_id_pk { get; set; }
        public Nullable<int> ticket_id_fk { get; set; }
        public string reply_description { get; set; }
        public string name { get; set; }
        public string to_email{ get; set; }
        public string cc_email{ get; set; }
        public string filepath { get; set; }
        public int role_id{ get; set; }
        public Nullable<int> technician_id_fk { get; set; }
        public Nullable<int> is_read { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<int> updated_by { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public int is_file { get; set; }
    }
    public class zdesk_m_ticket_status_tbl
    {
        public Nullable<int> ticket_id_pk { get; set; }
        public Nullable<int> ticket_status_id_pk { get; set; }
        public string ticket_status { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
    }
    public class zdesk_m_ticket_closer_code_tbl
    {
        public Nullable<int> closer_id_pk { get; set; }
        public string closer_code { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
    }
    public class zdesk_m_auto_closed_tbl
    {
        public Nullable<int> auto_closed_id_pk { get; set; }
        public string auto_close_time { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
    }
    public class zdesk_m_audit_trail_tbl
    {
        public Nullable<int> audit_id_pk { get; set; }
        public Nullable<int> ticket_id_fk { get; set; }
        public Nullable<int> change_set_id { get; set; }
        public int? user_id_pk { get; set; }
        public string field_name { get; set; }
        public string table_name { get; set; }
        public string UserName { get; set; }
        public string old_value { get; set; }
        public string new_value { get; set; }
        public Nullable<DateTime> update_date { get; set; }
        public Nullable<int> user_id_fk { get; set; }
        public string Updated_by { get; set; }
        public string Comments { get; set; }

    }
    public class SendEmailData
    {
        public string Subject { get; set; }
        public int TotalSlaMinutes { get; set; }
        public int TotalBalanceMinutes { get; set; }
        public string PriorityName { get; set; }
    }
    public class EmailSender
    {
        public int Type { get; set; }
        public string EmailId { get; set; }
    }
    public class EmailSenderDetails
    {
        public List<string> To { get; set; }
        public List<string> CC { get; set; }
    }
}