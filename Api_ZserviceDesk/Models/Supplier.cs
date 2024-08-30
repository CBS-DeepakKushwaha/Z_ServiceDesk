using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class Supplier
    {
    }
    public partial class zdesk_m_supplier_category_tbl
    {
        public Nullable<int> sup_category_id_pk { get; set; }
        public string category_name { get; set; }
        public int is_active { get; set; }
    }
    public partial class zdesk_m_supplier_contact_details_tbl
    {
        public Nullable<int> supp_con_det_id_pk { get; set; }
        public Nullable<int> supplier_id_pk { get; set; }
        public Nullable<int> supplier_id_fk { get; set; }
        public string name { get; set; }
        public string contact_person { get; set; }
        public string address { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string designation { get; set; }
        public string mobile_no { get; set; }
        public int is_active { get; set; }
    }
    public partial class zdesk_m_supplier_status_tbl
    {
        public Nullable<int> sup_status_id_pk { get; set; }
        public string sup_status_name { get; set; }
        public int is_active { get; set; }
    }
    public class zdesk_m_supplier_details_tbl
    {
        public int supplier_id_pk { get; set; }
        public string sup_status_name { get; set; }
        public string risk_ass_mng_result { get; set; }
        public string track_record { get; set; }
        public string refrence { get; set; }
        public Nullable<int> creadit_rating { get; set; }
        public string category_name { get; set; }
        public string supplier_code { get; set; }
        public string supplier_name { get; set; }
        public string compnay_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string contact_person { get; set; }
        public Nullable<int> sup_status_id_fk { get; set; }
        public string email { get; set; }
        public Nullable<int> sup_category_id_fk { get; set; }
        public string phone_number { get; set; }
        public string GSTNumber { get; set; }
        public string note { get; set; }
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
        public string services { get; set; }
    }
    public partial class zdesk_m_supplier_doc_details_tbl
    {
        public Nullable<int> suplier_doc_id_pk { get; set; }
        public int supplier_id_fk { get; set; }
        public string doc_type { get; set; }
        public string doc_name { get; set; }
        public string description { get; set; }
        public string documents { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
    }
    public partial class zdesk_m_supplier_service_category_tbl
    {
        public int service_cat_id_pk { get; set; }
        public string category_id { get; set; }
        public string category_name { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }

    }
    public partial class zdesk_m_supplier_details_tbl_new
    {
        public int supplier_id_pk { get; set; }
        public string sup_status_name { get; set; }
        public string risk_ass_mng_result { get; set; }
        public string track_record { get; set; }
        public string refrence { get; set; }
        public Nullable<int> creadit_rating { get; set; }
        public string category_name { get; set; }
        public string supplier_code { get; set; }
        public string supplier_name { get; set; }
        public string compnay_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string contact_person { get; set; }
        public Nullable<int> sup_status_id_fk { get; set; }
        public string email { get; set; }
        public int sup_category_id_fk { get; set; }
        public string phone_number { get; set; }
        public string GSTNumber { get; set; }
        public string note { get; set; }
        public int is_active { get; set; }
        public string services { get; set; }
    }
}