
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class Software
    {
    }
    public partial class zdesk_m_publisher_tbl
    {
        public Nullable<int> publisher_id_pk { get; set; }
        public string publisher_name { get; set; }
        public int is_active { get; set; }
    }
    public partial class zdesk_m_software_category_tbl
    {
        public Nullable<int> soft_catogory_id_pk { get; set; }
        public string soft_category_name { get; set; }
        public int is_active { get; set; }
    }
    public partial class zdesk_m_software_name_tbl
    {
        public Nullable<int> soft_name_id_pk { get; set; }
        public Nullable<int> soft_catogory_id_fk { get; set; }
        public string software_name { get; set; }
        public int is_active { get; set; }
        public int publisher_id_fk { get; set; }
        public string publisher { get; set; }
        public string category { get; set; }
        public string license { get; set; }
        public Nullable<DateTime> to_date{ get; set; }
    }
    public partial class zdesk_m_software_assign_control_tbl
    {
        public Nullable<int> soft_ass_con_id_pk { get; set; }
        public Nullable<int> app_control_id { get; set; }
        public Nullable<int> soft_name_id_fk { get; set; }
        public Nullable<int> soft_catogory_id_fk { get; set; }
        public string soft_name { get; set; }
        public string App_Control_Status { get; set; }
        public int is_active { get; set; }
        public int insalled_qty { get; set; }
        public int purchased_qty { get; set; }
        public int variance { get; set; }

    }
    public partial class zdesk_m_software_tbl
    {
        public int software_id_pk { get; set; }
        public Nullable<int> location_id_fk { get; set; }
        public Nullable<int> stored_location_id_fk { get; set; }
        public Nullable<int> soft_catogory_id_fk { get; set; }
        public Nullable<int> publisher_id_fk { get; set; }
        public Nullable<int> soft_name_id_fk { get; set; }
        public string license_type { get; set; }
        public string license_no { get; set; }
        public Nullable<DateTime> from_date { get; set; }
        public Nullable<DateTime> to_date { get; set; }
        public int qty { get; set; }
        public int allocated_qty { get; set; }
        public int remaining_qty { get; set; }
        public Nullable<decimal> unit_price { get; set; }
        public string software_name { get; set; }
        public string location_name { get; set; }
        public string stored_location_name { get; set; }
        public string soft_category_name { get; set; }
        public string publisher_name { get; set; }
        //
        public int soft_uom { get; set; }
        public Nullable<decimal> total_price { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public string email { get; set; }
        public string user_name { get; set; }
        public string Section { get; set; }
        public string Location { get; set; }
        public string sub_location { get; set; }
        public string sublocation { get; set; }
        public string PONumber { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<DateTime> InvoiceDate { get; set; }
        public int supplier_id_fk { get; set; }
    }
    public partial class zdesk_m_assign_software_tbl
    {
        public Nullable<int> location_id_fk { get; set; }
        public Nullable<int> stored_location_id_fk { get; set; }
        public Nullable<int> soft_catogory_id_fk { get; set; }
        public Nullable<int> soft_name_id_fk { get; set; }
        public Nullable<int> employee_id_fk { get; set; }
        //public Nullable<int> license_no { get; set; }
        public string license_no { get; set; }
        public string asset_tag { get; set; }
        public string assign_date { get; set; }
        //
        public int assign_software_id_pk { get; set; }
        public string email { get; set; }
        public int qty { get; set; }
    }
    public partial class zdesk_software_stock_ledger_tbl
    {
        public Nullable<int> soft_store_id_pk { get; set; }
        public Nullable<int> location_id_fk { get; set; }
        public Nullable<int> item_id_fk { get; set; } 
        public Nullable<int> store_loc_id_fk { get; set; }
        public Nullable<int> soft_catogory_id_fk { get; set; }
        public Nullable<int> publisher_id_fk { get; set; }
        public Nullable<int> soft_name_id_fk { get; set; }
        public string soft_category_name { get; set; }
        public string software_name { get; set; }
        public string allocated { get; set; }
        public string serial_number { get; set; }
        public string added { get; set; }
        public string balance { get; set; }
        public string location_name { get; set; }
        public string stored_location_name { get; set; }
        public int item_in { get; set; }
        public int item_out { get; set; }
        public int ref_id { get; set; }
        //
        public string publisher_name { get; set; }
        public int detect_count { get; set; }
        public int variation { get; set; }
    }
    public partial class zdesk_t_software_map_tbl
    {
        public int soft_mapp_id_pk { get; set; }
        public int soft_name_id_fk { get; set; }
        public string soft_id_fk { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public int created_by { get; set; }
        public int is_active { get; set; }
        public int is_delete { get; set; }
    }
    public partial class zdesk_t_license_tbl
    {
        public int license_id_pk { get; set; }
        public string product_code { get; set; }
        public string license_key { get; set; }
        public string license_type { get; set; }
        public Nullable<DateTime> start_date { get; set; }
        public Nullable<DateTime> end_date { get; set; }
        public int base_platform { get; set; }
        public int admin_license { get; set; }
        public int asset_admin_license { get; set; }
        public int standard_technician_license { get; set; }
        public int enterprise_technician_license { get; set; }
        public int RemainingStandardLicense { get; set; }
        public int RemainingEnterpriseLicense { get; set; }
        public int full_suite { get; set; }
        public int lifecycle_mgmt { get; set; }
        public string support_type { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int is_active { get; set; }
    }
    public partial class zdesk_m_software_license_document_tbl
    {
        public int license_doc_id_pk { get; set; }
        public int soft_name_id_pk { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int is_active { get; set; }
    }

    public partial class zdesk_m_software_notify_rule_tbl
    {
        public int rule_id_pk { get; set; }
        public string rule_id { get; set; }
        public string rule_name { get; set; }
        public string software_name { get; set; }
        public string user1 { get; set; }
        public string user2 { get; set; }
        public string user3 { get; set; }
        public int soft_id_fk { get; set; }
        public int notify_before_1 { get; set; }
        public string notify_to1 { get; set; }
        public int notify_before_2 { get; set; }
        public string notify_to2 { get; set; }
        public int notify_before_3 { get; set; }
        public string notify_to3 { get; set; }
        public int notification1_sent { get; set; }
        public int notification2_sent { get; set; }
        public int notification3_sent { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int updated_by { get; set; }
        public int is_active { get; set; }
    }

    public partial class Zdesk_m_logo_tbl
    {
        public int Id { get; set; }
        public string logo { get; set; }
        public string background { get; set; }
        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string ApplicationAdmin { get; set; }
        public int? adminId { get; set; }

    }
}