using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class Consumable
    {

    }
    public partial class zdesk_employee_list
    {
        public Nullable<int> id { get; set; }
        public string Name { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public string mobile { get; set; }
        public string support_dep_group { get; set; }
        public Nullable<int> roleid { get; set; }
        public Nullable<int> location_id_pk { get; set; }
        public string password { get; set; }
        public string emp_email { get; set; }
        public string emp_password { get; set; }
    }

    public partial class Companylic
    {
        public string Licence { get; set; }
        public DateTime startDate { get; set; }
        public DateTime EndDate { get; set; }

    }

    public partial class zdesk_employee
    {
        public Nullable<int> id { get; set; }
        public Nullable<int> user_id_pk { get; set; }
        public string name { get; set; }
        public string user_code { get; set; }
        public string emp_code { get; set; }
        public string role_name { get; set; }
        public string location_name { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public string mobile { get; set; }
        public string support_dep_group { get; set; }
        public Nullable<int> roleid { get; set; }
        public Nullable<int> location_id_pk { get; set; }
        public string password { get; set; }
        public string emp_email { get; set; }
        public string emp_password { get; set; }
        public string display_name { get; set; }
        public string UserType { get; set; }
        public bool flag { get; set; }
    }
    public partial class zdesk_m_consumable_item_tbl
    {
        public int Created_By { get; set; }
        public string Serialno { get; set; }
        public string Component { get; set; }
        public string ExpressServiceCode { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Cost { get; set; }
        public string Asset { get; set; }
        public string TermsConditions { get; set; }
        public Nullable<DateTime> WarrentyStartDate { get; set; }
        public Nullable<DateTime> WarrentyEndDate { get; set; }
        public Nullable<int> stored_location_id_fk { get; set; }
        public int category { get; set; }
        public string file_upload { get; set; }
        public string stored_location { get; set; }
        public string SubCategory { get; set; }
        public string Vendor { get; set; }
        public string item_name { get; set; }
        public string item_details { get; set; }
        public int qty { get; set; }
        public int unit_price { get; set; }
        public int consumable_item_id_pk { get; set; }
        public int item_id_fk { get; set; }
        public Nullable<int> catogory_id_fk { get; set; }
        public string category_name { get; set; }
        public string location_name { get; set; }
        public string PONumber { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<DateTime> InvoiceDate { get; set; }
        public int supplier_id_fk { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
    }
    public partial class zdesk_m_category_tbl
    {
        public Nullable<int> catogory_id_pk { get; set; }
        public string category_name { get; set; }
        public int is_active { get; set; }
    }
    public partial class zdesk_m_item_tbl
    {
        public Nullable<int> item_id_pk { get; set; }
        public string item_name { get; set; }
        public string item_code { get; set; }
        public string category_name { get; set; }
        public Nullable<int> catogory_id_fk { get; set; }
        public Nullable<int> is_active { get; set; }
        public int updated_by { get; set; }
    }
    public partial class zdesk_m_allocate_consumable_item_tbl
    {
        public string Serialno { get; set; }
        public int allocate_con_item_id_pk { get; set; }
        public string reciever_name { get; set; }
        public string reciever_contact_no { get; set; }
        public Nullable<int> stored_location_id_fk { get; set; }
        public int category { get; set; }
        public int item_name { get; set; }
        public int employee_id_fk { get; set; }
        public DateTime allocate_date { get; set; }
        public Nullable<int> quantity { get; set; }
        public int ticket_id_fk { get; set; }
        public string doc_path { get; set; }
        public Nullable<int> is_doc { get; set; }
    }
    public partial class zdesk_stock_ledger_tbl
    {
        public string SerialNo { get; set; }
        public string file_upload { get; set; }
        public Nullable<int> peripherals_store_id_pk { get; set; }
        public Nullable<int> store_loc_id_fk { get; set; }
        public Nullable<int> category_id_fk { get; set; }
        public string category_name { get; set; }
        public string AllocatedStatus { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public Nullable<DateTime> creted_date { get; set; }
        public Nullable<int> item_id_fk { get; set; }
        public string item_name { get; set; }
        public string allocated { get; set; }
        public string added { get; set; }
        public string balance { get; set; }
        public string item_code { get; set; }
        public string stored_location_name { get; set; }
        public int item_in { get; set; }
        public int item_out { get; set; }
        public int ref_id { get; set; }
        public int quantity { get; set; }
        public string user_name { get; set; }
        public string Section { get; set; }
        public string Location { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public string location_name { get; set; }
        public string sub_location { get; set; }
        public string floor_name { get; set; }
        public string department_name { get; set; }
        public string room_no { get; set; }
        public string mobile_no { get; set; }
        public int allocate_con_item_id_pk { get; set; }
        public int is_doc { get; set; }
        public string doc_path { get; set; }
        public string reciever_name { get; set; }
        public string reciever_contact_no { get; set; }
        public string prefix { get; set; }
    }
    public partial class zdesk_t_emp_support_department_group_tbl
    {
        public Nullable<int> support_group_id_fk { get; set; }
        public Nullable<int> emp_id_fk { get; set; }
    }
    public partial class roles
    {
        public Nullable<int> id { get; set; }
        public Nullable<int> updated_by { get; set; }
        public Nullable<int> DataItem { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public string role { get; set; }
        public string role_type_name { get; set; }
        public string mobile { get; set; }
        public string location { get; set; }
        public string support_dep_group { get; set; }
        public Nullable<int> roleid { get; set; }
        public Nullable<int> location_id_pk { get; set; }
        public string password { get; set; }
        public Nullable<int> user_role_id_fk { get; set; }
        public Nullable<int> type_license { get; set; }
        public Nullable<int> map_asset_by { get; set; }
        public string asset_category { get; set; }
    }

    public partial class zdesk_m_users_filter
    {
        public DateTime? fdate { get; set; }
        public DateTime? tdate { get; set; }
        public string temail { get; set; }
        public string location { get; set; }
        public string subLocation { get; set; }
        public string department { get; set; }
        public string subDepartment { get; set; }
        public string repoManager { get; set; }
        public string depHead { get; set; }
        public string BusiHead { get; set; }
        public string Business { get; set; }
    }

    public partial class zdesk_m_users_tbl
    {
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

    public partial class EnployeeList
    {
        public Nullable<int> Id { get; set; }
        public Nullable<int> DataItem { get; set; }
        public string name { get; set; }
    }
    public class zdesk_m_LicenceKey
    {
        public string LiceneceKey { get; set; }
        public string StartDate { get; set; }
        public string ExpireDate { get; set; }

    }

    public partial class zdesk_m_users_status_history_tbl
    {
        public Nullable<int> Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeEmail { get; set; }
        public string UpdatedStatus { get; set; }
        public string update_date { get; set; }
        public string UpdatedBy { get; set; }
    }
}