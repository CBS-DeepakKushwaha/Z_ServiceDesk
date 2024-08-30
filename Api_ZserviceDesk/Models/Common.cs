using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class Common
    {
    }
    public class zdesk_t_chatbot_intent_tbl
    {
        public int intent_id_pk { get; set; }
        public string intent_name { get; set; }
        public string intent_loc { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> update_date { get; set; }
        public int is_active { get; set; }
    }
    public class zdesk_chatbot_indent_cls
    {
        public int tag { get; set; }
        public string phrase { get; set; }
        public string response { get; set; }
        public string intent_name { get; set; }
    }
    public class CommonStatus
    {
        public string Description { get; set; }
        public string assign { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string status { get; set; }
        public string subject { get; set; }
        public string prefix { get; set; }
        public Nullable<int> status_id { get; set; }
        public Nullable<int> imac_id_pk { get; set; }
        public Nullable<int> req_app_id_pk { get; set; } 
        public string user_contact_no { get; set; }
        public string user_email { get; set; }  
        public Nullable<int> consumable_item_id_pk { get; set; } 
        public Nullable<int> user_id_fk { get; set; }
        public Nullable<int> preventive_id_pk { get; set; }
        public Nullable<int> admin_id_pk { get; set; }
        public Nullable<int> ticket_id_pk { get; set; }
        public Nullable<int> service_req_id_pk { get; set; }
        public Nullable<int> ser_req_status_id_pk { get; set; }
        public Nullable<int> sla_id_pk { get; set; }
        public Nullable<int> gate_pass_id_pk { get; set; }
        public Nullable<int> change_category_id_pk { get; set; }
        public string DataItem { get; set; }
        public string ServiceRequestId { get; set; }
        public Nullable<int> ticket_status_id_pk { get; set; }
        public Nullable<int> kb_approver_cat_sub_id_pk { get; set; }
        public Nullable<int> contract_id_pk { get; set; }
        public Nullable<int> suplier_doc_id_pk { get; set; }
        public string assig_to_email { get; set; }
        public string userName { get; set; }
        public string UserEmail { get; set; }
    }
    public partial class zdesk_m_stored_location_tbl
    {
        public Nullable<int> stored_location_id_pk { get; set; }
        public Nullable<int> location_id_fk { get; set; }
        public string stored_location_name { get; set; }
        public string location_name { get; set; }
        public int is_active { get; set; }
    }
    public partial class zdesk_m_location_tbl
    {
        public Nullable<int> location_id_pk { get; set; }
        public Nullable<int> business_unit_id_fk { get; set; }
        public string location_name { get; set; }
        public string business_unit { get; set; }
        public int is_active { get; set; }
        public Nullable<int> is_default { get; set; }
    }
    public partial class zdesk_m_issue_type_tbl 
    {
        public Nullable<int> issue_type_id_pk { get; set; } 
        public string issue_type { get; set; }
        public int is_active { get; set; }
        public Nullable<int> is_default { get; set; }
    }
    public partial class zdesk_m_escalation_matrix_tbl
    {
        public Nullable<int> escalation_id_pk { get; set; }
        public string escalation_time { get; set; }
        public string escalation_email { get; set; }
        public int is_active { get; set; }
        public Nullable<int> is_default { get; set; }
    }
    public partial class zdesk_m_customer_tbl
    {
        public Nullable<int> customer_id_pk { get; set; }
        public string customer_name { get; set; }
        public int is_active { get; set; }
        public Nullable<int> is_default { get; set; }
    }
    public partial class zdesk_m_section_tbl
    {
        public Nullable<int> department_id_fk { get; set; }
        public Nullable<int> section_id_pk { get; set; }
        public string section_name { get; set; }
        public string department_name { get; set; }
        public int is_active { get; set; }
        public Nullable<int> is_default { get; set; }
    }
    public partial class zdesk_m_floor_tbl
    {
        public Nullable<int> floor_id_pk { get; set; }
        public string floor_name { get; set; }
        public int is_active { get; set; }
        public Nullable<int> is_default { get; set; }
    }
    public partial class zdesk_m_sub_location_tbl
    {
        public Nullable<int> sub_location_id_pk { get; set; }
        public string sub_location { get; set; }
        public int location_Id { get; set; }
        public string location { get; set; }
        public int is_active { get; set; }
        public Nullable<int> is_default { get; set; }
    }
    public partial class zdesk_m_prefix_value_tbl
    {
        public Nullable<int> prefix_id_pk { get; set; }
        public string prefix_value { get; set; }
        public string master_value { get; set; }
        public int is_active { get; set; }
    }

    public class items
    {
        public string title { get; set; }
        public string cuntr { get; set; }

    }
    public partial class zdesk_m_contract_management_tbl
    {
        public Nullable<int> contract_id_pk { get; set; }
        public string contract_id { get; set; }
        public string title { get; set; }
        public Nullable<int> supplier_id_pk { get; set; }
        public string service_review_period { get; set; }
        public string scope_of_work { get; set; }
        public string service_discription { get; set; }
        public Nullable<DateTime> start_date { get; set; }
        public Nullable<DateTime> end_date { get; set; }
        public string attach_po_name { get; set; }
        public string attach_contract { get; set; }
        public string contract_risk_rating { get; set; }
        public Nullable<int> sup_category_id_fk { get; set; }
        public string supplier_code { get; set; }
        public string supplier_name { get; set; }
        public string compnay_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string contact_person { get; set; }
        public Nullable<int> sup_status_id_fk { get; set; }
        public string email { get; set; }
        public Nullable<decimal> total_cost { get; set; }
        public string terms_condition { get; set; }
        public string payment_terms { get; set; }
        public Nullable<int> is_h_s_supp { get; set; }
        public Nullable<int> is_ots { get; set; }
        public Nullable<int> is_ess { get; set; }
        public Nullable<int> is_dss { get; set; }
        public Nullable<int> is_h_amc { get; set; }
        public Nullable<int> is_i_s_serv { get; set; }
        public Nullable<int> is_app_supp { get; set; }
        public Nullable<int> is_s_supp { get; set; }
        public Nullable<int> is_n_supp { get; set; }
        public Nullable<int> is_db_supp { get; set; }
        public Nullable<int> is_a_v_supp { get; set; }
        public Nullable<int> is_cctv_supp { get; set; }
        public Nullable<int> is_oth_serv { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<int> contract_type { get; set; }
        public string range { get; set; }
        public string prefix { get; set; }
        public string contract { get; set; }
    }
    public partial class autosearch
    {
        public Nullable<int> autoid { get; set; }
        public string autoname { get; set; }
        public string autoText { get; set; }
        public string autocode { get; set; }
    }
    public partial class zdesk_m_email_configuration_tbl
    {
        public Nullable<int> email_config_id_pk { get; set; }
        public string email_from_address { get; set; }
        public string email_from_name { get; set; }
        public string smtp_host { get; set; }
        public string smtp_port { get; set; }
        public string smtp_user_name { get; set; }
        public string smtp_password { get; set; }
        public string smtp_security { get; set; }
        public string smtp_authentication_domain { get; set; }
        public Nullable<int> is_smtp_req_auth { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<int> updated_by { get; set; }

    }
    public partial class zdesk_m_template_tbl
    {
        public Nullable<int> id { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }
        public Nullable<int> isactive { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public string subject { get; set; }
        public Nullable<int> templete_type { get; set; }
        public string Old_Template { get; set; }
        public Nullable<DateTime> lu_date { get; set; }
    }

    public partial class Zdesk_m_smpt_tbl
    {
        public Nullable<int> Id_pk { get; set; }
        public string mailService { get; set; }
        public string ServiceProtocol { get; set; }
        public string FromAddress { get; set; }
        public Nullable<int> SmptPort { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<bool> Islts { get; set; }
        public Nullable<bool> Isssl { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        
        public Nullable<bool> IsActive { get; set; }
    }

    public class DocumentDetailsModel
    {
        public int parameter { get; set; }
        public int user_mst_fk { get; set; }
        public int proof_type { get; set; }
        public string proof_name { get; set; }
        public string file_name { get; set; }
        public int updated_by { get; set; }
        public int document_id_pk { get; set; }
        public int is_director_proof { get; set; }
        public string guid { get; set; }
        public string pan_number { get; set; }
        public string email { get; set; }
        public string contact_number { get; set; }
        public string description { get; set; }
        public string frontside { get; set; }
        public Nullable<int> file_size { get; set; }
        public string file_type { get; set; }
        public Nullable<int> director_mst_pk { get; set; }
        public string filename { get; set; }
        public int id { get; set; }
    }
    public partial class GetDocuments
    {
        public Nullable<int> proof_type { get; set; }
        public string proof_name { get; set; }
        public string frontside { get; set; }
        public string backside { get; set; }
        public string file_name { get; set; }
        public int file_size { get; set; }
        public string file_type { get; set; }
        public int document_id_pk { get; set; }
    }
    //public class Incident
    //{
    //    public string Ticket_Status { get; set; }
    //    public Nullable<int> Id { get; set; }
    //    public Nullable<int> Total { get; set; }
    //}
    //public class ServiceRequest
    //{
    //    public string Status { get; set; }
    //    public Nullable<int> Id { get; set; }
    //    public Nullable<int> Total { get; set; }
    //}
    //public class Assesst
    //{
    //    public Nullable<int> InStore { get; set; }
    //    public Nullable<int> Allocated { get; set; }
    //    public Nullable<int> InRepair { get; set; }
    //    public Nullable<int> InActive { get; set; }
    //    public string Categoty { get; set; }
    //    public string LocationName { get; set; }
    //}
    //public class IncidentSupport
    //{
    //    public Nullable<int> Assigned { get; set; }
    //    public Nullable<int> InProgress { get; set; }
    //    public Nullable<int> New { get; set; }
    //    public Nullable<int> Pending { get; set; }
    //    public Nullable<int> Reopened { get; set; }
    //    public Nullable<int> Resolved { get; set; }
    //    public string Support_departmentName { get; set; }
    //}
    public class zdesk_m_feedback_form_tbl
    {
        public string form_title { get; set; }
        public string questions { get; set; }
        public string message { get; set; }
        public Nullable<int> feedback_id_pk { get; set; }
        public Nullable<int> Total { get; set; }
    }
    public partial class zdesk_holiday
    {
        //public  DateTime? holiday_date { get; set; }
        public Nullable<DateTime> holiday_date { get; set; }
        public string sla_name { get; set; }
    }
    public partial class zdesk_m_AdDetails_tbl
    {
        public int clientid_pk { get; set; }
        public string server_id { get; set; }
        public string domain { get; set; }
        public string organizationunit { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public int is_default { get; set; }
    }

    public class zdesk_m_dropdown
    {
        public int ID { get; set; }
        public string Param1 { get; set; }
        public string Param2 { get; set; }
        public string GroupName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Section { get; set; }
        public Nullable<int> is_default { get; set; }
        public string is_default_Name { get; set; }
    }


    public class zdesk_m_page_master_tbl
    {
        /////public MenuControl();

        public int page_master_id_pk { get; set; }
        public int ParentID { get; set; }
        public int Level { get; set; }
        public int SequenceOrder { get; set; }
        public string classname { get; set; }
        public string PageDesc { get; set; }
        public string PathURL { get; set; }
        public string MenuReferID { get; set; }
        public string is_active { get; set; }
        public Nullable<bool> IsVisibleInMenu { get; set; }
        //////public List<zdesk_m_page_master_tbl> MenuColl { get; set; }
    }
}