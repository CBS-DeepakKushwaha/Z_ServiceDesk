using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class Change
    {
    }
    public partial class zdesk_m_reason_for_change_tbl
    {
        public Nullable<int> reason_id_pk { get; set; }
        public string reason_name { get; set; }
    }
    public partial class zdesk_m_change_type_tbl
    {
        public Nullable<int> change_type_id_pk { get; set; }
        public string change_type_name { get; set; }
    }
    public partial class zdesk_m_status_tbl
    {
        public Nullable<int> status_id_pk { get; set; }
        public string status { get; set; }
    }
    public partial class zdesk_m_common_category_tbl
    {
        public Nullable<int> service_cat_id_pk { get; set; }
        public Nullable<int> common_cat_id_pk { get; set; }
        public string category_name { get; set; }

        public Nullable<int> template_count { get; set; }
    }
    public partial class zdesk_m_non_it_asset_category_tbl
    {
        public Nullable<int> non_it_ass_cat_id_pk { get; set; }
        public string non_it_ass_cat_name { get; set; }
    }
    public partial class zdesk_m_common_sub_category_tbl
    {
        public Nullable<int> sub_category_id_pk { get; set; }
        public Nullable<int> common_cat_id_fk { get; set; }
        public string sub_category_name { get; set; }
        public string category_name { get; set; }
        public string keywords { get; set; }
    }
    public partial class zdesk_m_pending_reason_tbl
    {
        public Nullable<int> pending_reason_id_pk { get; set; }
        public string pending_reason_name { get; set; }
        public Nullable<int> is_active { get; set; }
    }
    public partial class zdesk_m_support_department_group_tbl
    {
        public Nullable<int> support_group_id_pk { get; set; }
        public Nullable<int> support_dep_id_pk { get; set; }
        public Nullable<int> support_group_head { get; set; }
        public string support_dep_group_name { get; set; }
        public string support_dep_name { get; set; }
    }
    public partial class zdesk_m_business_unit_tbl
    {
        public Nullable<int> business_unit_id_pk { get; set; }
        public Nullable<int> business_head { get; set; }
        public Nullable<int> is_default { get; set; }
        public string business_unit { get; set; }
    }
    public partial class zdesk_m_risk_tbl
    {

        public Nullable<int> risk_id_pk { get; set; }
        public string risk_name { get; set; }
    }
    public partial class zdesk_m_condition_tbl
    {
        public Nullable<int> condition_id_pk { get; set; }
        public string condition_name { get; set; }
    }
    public partial class zdesk_m_component_tbl
    {
        public Nullable<int> component_id_pk { get; set; }
        public string component_name { get; set; }
    }
    public partial class assets
    {

        public Nullable<int> id { get; set; }
        public string name { get; set; }
    }
    public partial class zdesk_m_change_management_status_tbl
    {

        public Nullable<int> chan_manage_status_id_pk { get; set; }
        public string chan_manage_status { get; set; }
    }
    public partial class zdesk_m_change_management_tbl
    {
        public Nullable<int> updated_by { get; set; }
        public Nullable<int> change_category_id_pk { get; set; }
        public Nullable<int> support_dep_id_fk { get; set; }
        public Nullable<int> support_group_id_fk { get; set; }
        public string subject { get; set; }
        public string prefix { get; set; }
        public Nullable<int> reason_id_fk { get; set; }
        public Nullable<int> change_type_id_pk { get; set; }
        public Nullable<int> change_requester_id { get; set; }
        public Nullable<int> status_id_pk { get; set; }
        public Nullable<int> common_cat_id_pk { get; set; }
        public Nullable<int> sub_category_id_pk { get; set; }
        public Nullable<int> business_unit_id_pk { get; set; }
        public Nullable<int> location_id_pk { get; set; }
        public Nullable<int> change_owner_id { get; set; }
        public Nullable<int> change_manager_id { get; set; }
        public Nullable<int> impact_id_pk { get; set; }
        public Nullable<int> priority_id_pk { get; set; }
        public Nullable<int> risk_id_pk { get; set; }
        public Nullable<int> assets_id_pk { get; set; }
        public Nullable<DateTime> due_date { get; set; }
        public Nullable<DateTime> planned_start_date { get; set; }
        public Nullable<DateTime> planned_end_date { get; set; }
        public Nullable<int> estimated_cost { get; set; }
        public Nullable<int> assign_to_id { get; set; }
        public string reviewer_id { get; set; }
        public string change_approver_id { get; set; }
        public string tester_id { get; set; }
        public string implementer_id { get; set; }
        public Nullable<int> communication_plan { get; set; }
        public string description_plan { get; set; }
        public string file { get; set; }
        public string change_url { get; set; }
        public string category_name { get; set; }
        public string submitter { get; set; }
        public string assign_to { get; set; }
        public string change_type_name { get; set; }
        public string status { get; set; }
        public string reason { get; set; }
        public string requester { get; set; }
        public string owner { get; set; }
        public string manager { get; set; }
        public string reviewer { get; set; }
        public string approver { get; set; }
        public Nullable<int> department_id_fk { get; set; }
        public Nullable<int> user_id_fk { get; set; }
        public Nullable<int> urgency_id_fk { get; set; }
        public Nullable<int> impact_id_fk { get; set; }
        public Nullable<int> is_send_email { get; set; }
        public Nullable<int> is_send_message { get; set; }
        public string message { get; set; }
        public string location_id { get; set; }
        public string user_id { get; set; }
        public string client_id { get; set; }
        public string department_id { get; set; }
        public string group_id { get; set; }
        public string priority_id { get; set; }
        public string impact_id { get; set; }
        public string urgency_id { get; set; }
        public string common_cat_id { get; set; }
        public string sub_category_id { get; set; }
        public Nullable<int> due { get; set; }
        public Nullable<DateTime> from_date { get; set; }
        public Nullable<DateTime> to_date { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<int> login_id { get; set; }
        public Nullable<int> change_approval_details_id_fk { get; set; }
        public Nullable<int> change_stage { get; set; }
        public string sub_category_name { get; set; }
        public string change_stage_name { get; set; }
        public string change_stage_status { get; set; }
        public Nullable<int> change_stage_status_id { get; set; }
        public string impacted_assets { get; set; }
        public string change_reason_name { get; set; }
        public string cab_members { get; set; }
        public string risk_name { get; set; }
        public string ImpactedAssets { get; set; }
        public string ChangeRequester { get; set; }
        public string ChangeManager { get; set; }
        public string ChangeApprover { get; set; }
        public string ChangeTester { get; set; }
        public string ChangeImplementer { get; set; }
        public string ChangeReviewer { get; set; }
        public string CABName { get; set; }
    }

    public partial class zdesk_m_change_approval_details_approver_tbl
    {
        public Nullable<int> change_approval_details_approver_id_pk { get; set; }
        public Nullable<int> change_category_id_pk { get; set; }
        public Nullable<int> approver_id { get; set; }

        public int IsDel { get; set; }

        public Nullable<int> approver_status { get; set; }
        public Nullable<int> change_stage { get; set; }
        public string approver_status_name { get; set; }

        public Nullable<int> sub_location_id_fk { get; set; }
        public Nullable<int> floor_id_fk { get; set; }
        public Nullable<int> grade_id_fk { get; set; }
        public Nullable<int> cc_id_fk { get; set; }
        public Nullable<int> sub_dept_id_fk { get; set; }
        public string sub_location { get; set; }
        public string room_no { get; set; }
        public string location_name { get; set; }
        public string department_name { get; set; }
        public string ext_no { get; set; }
        public string business_unit { get; set; }
        public string floor_name { get; set; }
        public Nullable<int> user_id_pk { get; set; }
        public Nullable<int> is_vip { get; set; }
        public Nullable<int> updated_by { get; set; }
        public Nullable<int> role_id { get; set; }
        public Nullable<int> reporting_manager { get; set; }
        public Nullable<int> department_head { get; set; }
        public string type { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public string role { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string user_code { get; set; }
        public string emp_code { get; set; }
        public string manager_name { get; set; }
        public string mobile_no { get; set; }
        public string support_dep_group { get; set; }
        public Nullable<DateTime> resign_date { get; set; }
        public Nullable<int> roleid { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> location_id_fk { get; set; }
        public Nullable<int> business_unit_id_fk { get; set; }
        public Nullable<int> department_id_fk { get; set; }
        public string password { get; set; }
        public string sub_dept_name { get; set; }
        public string display_name { get; set; }
        public string grade_name { get; set; }
        public string cc_name { get; set; }
        public string reporting_manager_email { get; set; }
        public string department_head_email { get; set; }
        public string business_head_email { get; set; }
        public int support_dept_id_fk { get; set; }
        public int support_group_id_fk { get; set; }
        public string usser_status { get; set; }
        public int IsLocationChange { get; set; }
        public int IsSubLocationChange { get; set; }
    }

    public class zdesk_m_generate
    {

        public int Id { get; set; }

    }
    public class zdesk_m_columnname
    {
        public string Column_Value { get; set; }
        public string Column_Name { get; set; }
        public int Id { get; set; }
        public IEnumerable<object> Data { get; set; }
    }
    public partial class zdesk_m_ReportTemplate
    {
        public string ReportCategory { get; set; }
        public string ddlMake { get; set; }
        public string ddlHDD { get; set; }
        public string ddlOS { get; set; }
        public string ddlCPU { get; set; }
        public string ddlCPUcore { get; set; }
        public string ddlRAM { get; set; }
        public string Technician_Id { get; set; }
        public string ddlAssetToBeCollected { get; set; }
        public string SupportDepartment_Id { get; set; }
        public string ChangeType_Id { get; set; }
        public string ReasonForChange_Id { get; set; }
        public string TaskType_Id { get; set; }
        public string SupportGroup_Id { get; set; }
        public string SlaStatus { get; set; }
        public string email_cc { get; set; }
        public string email_to { get; set; }
        public string sub { get; set; }
        public string time_dur { get; set; }

        public string ReportTypeIsScheduler { get; set; }

        public string resolution_sla { get; set; }
        public string response_sla { get; set; }
        public Nullable<DateTime> from_date { get; set; }
        public Nullable<DateTime> to_date { get; set; }
        public string logged_via { get; set; }
        public string ddlUserFltr { get; set; }
        public string ReportTemplate_Id { get; set; }
        public string ReportName { get; set; }
        public int UserId { get; set; }
        public int ReportId { get; set; }
        public string ColumnName { get; set; }
        public string location_id_fk { get; set; }
        public string ticket_status_id_pk { get; set; }
        public string ser_req_status_id_pk { get; set; }

        public string pending_reason_id_fk { get; set; }
        public string pending_category_id { get; set; }
        public string asset_category_id_pk { get; set; }
        public string client_id_pk { get; set; }
        public string Asset_Category { get; set; }
        public string support_dep_id_pk { get; set; }
        public string priority_id_pk { get; set; }
        public string common_cat_id_pk { get; set; }
        public string sub_category_id { get; set; }
        public string ddlWarrenty { get; set; }
        public int ReportType { get; set; }
        public string vandor { get; set; }
        public string manufacture { get; set; }
        public Nullable<DateTime> Datepurchase { get; set; }
        public Nullable<DateTime> Datewarranty { get; set; }
        public Nullable<DateTime> Dateamcend { get; set; }
        public int assetType { get; set; }
        public string logged_by { get; set; }
        public string sub_location_id { get; set; }
        public string condition_id_fk { get; set; }
        public string asset_support_id { get; set; }
        public string po_number { get; set; }
        public string invoice_number { get; set; }
        public Nullable<int> warranty_end_id { get; set; }
        public Nullable<DateTime> warranty_end_from { get; set; }
        public Nullable<DateTime> warranty_end_to { get; set; }
        public Nullable<int> amc_end_id { get; set; }
        public Nullable<DateTime> amc_end_from { get; set; }
        public Nullable<DateTime> amc_end_to { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string serial_no { get; set; }
        public int section { get; set; }
        public Nullable<int> Range { get; set; }
        public string pass_status { get; set; }
        public string pass_id { get; set; }
        public string cost { get; set; }
    }
    public partial class zdesk_m_other_report_schedule_tbl
    {
        public int report_id_pk { get; set; }
        public string report_name { get; set; }
        public string procedure_name { get; set; }
        public int is_schedule { get; set; }
        public int schedulerTypeId { get; set; }
        public string Time { get; set; }
        public string EmailTo { get; set; }
        public string EmailCC { get; set; }
        public string Subject { get; set; }
        public Nullable<DateTime> NextJobRun { get; set; }
        public int MONTHDATE { get; set; }
        public int ddlWeekDay { get; set; }
        public int ddlMonthdate { get; set; }
        public int WEEKDAY { get; set; }
        public int Report_Type { get; set; }
        public Nullable<DateTime> created_date { get; set; }

    }
    public partial class zdesk_m_consultant_tbl
    {
        public Nullable<int> consultant_id_pk { get; set; }
        public Nullable<int> department_id_fk { get; set; }
        public string department_name { get; set; }
        public string consultant_name { get; set; }
        public string consultant_email { get; set; }
        public string consultant_contact_no { get; set; }
        public int updated_by { get; set; }
    }
    public partial class zdesk_m_change_management_template_tbl
    {
        public int template_id_pk { get; set; }
        public string subject { get; set; }
        public int category_id_fk { get; set; }
        public int sub_cat_id_fk { get; set; }
        public int reason_id_fk { get; set; }
        public int change_type_id_fk { get; set; }
        public string description { get; set; }
        public int request_id_fk { get; set; }
        public int owner_id_fk { get; set; }
        public int urgency_id_fk { get; set; }
        public int impact_id_fk { get; set; }
        public int priority_id_fk { get; set; }
        public int risk_id_fk { get; set; }
        public string reviewer_id_fk { get; set; }
        public string approver_id_fk { get; set; }
        public int plan_type { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public string sub_cat_name { get; set; }
        public string tester_id { get; set; }
        public string implementer_id { get; set; }
        public string change_manager_id { get; set; }
        public string change_approval_details_id_fk { get; set; }
        public string impacted_assets { get; set; }
        public string reviewer_id { get; set; }
    }
    public partial class zdesk_m_change_management_risk_planning_tbl
    {
        public int risk_planning_id_pk { get; set; }
        public int change_id_fk { get; set; }
        public Nullable<DateTime> plan_start_date { get; set; }
        public Nullable<DateTime> plan_end_date { get; set; }
        public string business_impact { get; set; }
        public string roll_out_requirements { get; set; }
        public string back_out_requirements { get; set; }
        public string skill_requirements { get; set; }
        public string sw_hw_requirements { get; set; }
        public string financial_benefits { get; set; }
        public string financial_requirements { get; set; }
        public string business_requirements { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> update_date { get; set; }
        public int updated_by { get; set; }
        public int is_active { get; set; }

    }

    public partial class zdesk_m_change_management_test_tbl
    {
        public int test_id_pk { get; set; }
        public int change_id_fk { get; set; }
        public string test_name { get; set; }
        public Nullable<DateTime> test_plan_date { get; set; }
        public Nullable<DateTime> plan_start_date { get; set; }
        public string test_result { get; set; }
        public string file_loc { get; set; }
        public int support_dep_id_fk { get; set; }
        public int support_group_id_fk { get; set; }
        public int owner_id_fk { get; set; }
        public string description { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int updated_by { get; set; }
    }
    public partial class zdesk_m_change_management_release_tbl
    {
        public int release_id_pk { get; set; }
        public int change_id_fk { get; set; }
        public Nullable<DateTime> plan_start_date { get; set; }
        public Nullable<DateTime> plan_end_date { get; set; }
        public Nullable<DateTime> actual_start_date { get; set; }
        public Nullable<DateTime> actual_end_date { get; set; }
        public int support_dept_id_fk { get; set; }
        public int support_group_id_fk { get; set; }
        public int owner_id_fk { get; set; }
        public string file_loc { get; set; }
        public string Tab5Configuration { get; set; }
        public string Tab5Release { get; set; }
        public string comments { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int updated_by { get; set; }

    }
    public partial class zdesk_m_change_management_review_tbl
    {
        public int review_id_pk { get; set; }
        public int change_id_fk { get; set; }
        public string txt_issue { get; set; }
        public string txt_review { get; set; }
        public string txt_ae_logs { get; set; }
        public string txt_config_logs { get; set; }
        public string txt_cm_logs { get; set; }
        public string txt_cab_logs { get; set; }
        public string txt_cc_logs { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int updated_by { get; set; }
        public int is_active { get; set; }
        public string file_loc { get; set; }
    }

    public partial class zdesk_m_change_approval_details_tbl
    {
        public Nullable<int> change_approval_details_id_pk { get; set; }
        public string CAB_Name { get; set; }
        public int change_type { get; set; }
        public int severity { get; set; }
        public string change_type_name { get; set; }
        public string severity_name { get; set; }
        public string cab_members { get; set; }
    }
    public class zdesk_m_Purchase_Status_Log_tbl
    {
        public Nullable<int> Purchase_Status_Log_Id { get; set; }
        public Nullable<int> Purchase_Id_Pk { get; set; }
        public Nullable<int> NewStatusId { get; set; }
        public Nullable<int> OldStatusId { get; set; }
        public Nullable<int> update_By { get; set; }
        public string Comments { get; set; }
    }

    public partial class zdesk_m_change_management_stages_tbl
    {
        public Nullable<int> change_management_stages_id_pk { get; set; }
        public Nullable<int> change_category_id_pk { get; set; }
        public Nullable<int> change_stage { get; set; }
        //public Nullable<int> updated_by { get; set; }
        public string updated_by { get; set; }
        public string stage_name { get; set; }
        public string stage_status { get; set; }
        public string review_comments { get; set; }
        public string updated_by_name { get; set; }
        public DateTime updated_date { get; set; }
    }
}