using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public partial class Autocomplete
    {
        public string asset_tag { get; set; }
        public string serial_number { get; set; }
        public string Message { get; set; }
        public string parameter { get; set; }
        public Nullable<int> searchflag { get; set; }
        public Nullable<int> director_mst_pk { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string contact_number { get; set; }
        public string pan_number { get; set; }
        public string din_number { get; set; }
        public string adhar_number { get; set; }
        public Nullable<int> company_mst_pk { get; set; }
        public string company_name { get; set; }
        public string pan { get; set; }
        public string tan { get; set; }
        public string tin { get; set; }
        public string cin { get; set; }
        public string password { get; set; }
    }

    public partial class zdesk_m_asset_index_tbl
    {
        public Nullable<int> asset_id_pk { get; set; }
        public Nullable<int> gps { get; set; }
        public Nullable<int> mapping_required { get; set; }
        public string os_type { get; set; }
        public Nullable<int> Serialmatch { get; set; }
        public Nullable<int> modelmatch { get; set; }
        public Nullable<int> makematch { get; set; }
        public Nullable<int> windowPatch { get; set; }
        public string asset_tag { get; set; }
        public string email { get; set; }
        public string model_name { get; set; }
        public string serial_number { get; set; }
        public string location_name { get; set; }
        public string status { get; set; }
        public string acnknowledge { get; set; }
        public string asset_cat_name { get; set; }
    }
    public partial class zdesk_m_antivirus_info_tbl
    {
        public Nullable<int> Id { get; set; }
        public string display_name { get; set; }
        public string upto_date_status { get; set; }
        public string antivirus_enabled { get; set; }
        public Nullable<DateTime> lastupdate { get; set; }

    }
    public partial class zdesk_m_asset_tbl
    {
        public string updatedBy { get; set; }
        public string SelectedPatchStatus { get; set; }
        public string ExpressServiceCode { get; set; }
        public Nullable<int> Sold_Vendor_Id { get; set; }
        public Nullable<int> VendorRepair_Id { get; set; }
        public Nullable<decimal> SoldAmount { get; set; }
        public Nullable<decimal> asset_loss_reversal { get; set; }
        public Nullable<int> sold_to_type { get; set; }
        public Nullable<int> warranty_type { get; set; }
        public string warrantytype { get; set; }
        public Nullable<int> windowPatch { get; set; }
        public Nullable<int> Serialmatch { get; set; }
        public Nullable<int> modelmatch { get; set; }
        public Nullable<int> makematch { get; set; }
        public Nullable<int> is_acknowledge { get; set; }
        public Nullable<int> TotalRecord { get; set; }
        public Nullable<int> PageNo { get; set; }
        public Nullable<int> PazeSize { get; set; }
        public Nullable<int> updated_by { get; set; }
        public Nullable<int> mapping_required { get; set; }
        public Nullable<int> customer_id_fk { get; set; }
        public Nullable<int> support_type { get; set; }
        public Nullable<int> pass_status { get; set; }
        public Nullable<int> condition_id_fk { get; set; }
        public Nullable<int> department_id_fk { get; set; }
        public Nullable<int> ticket_id_pk { get; set; }
        public Nullable<int> user_id_fk { get; set; }
        public Nullable<int> asset_id_pk { get; set; }
        public Nullable<int> os { get; set; }
        public string os_type { get; set; }
        public Nullable<int> client_id_fk { get; set; }
        public Nullable<int> sub_location_id_fk { get; set; }
        public Nullable<int> section_id_fk { get; set; }
        public Nullable<int> floor_id_fk { get; set; }
        public Nullable<int> asset_category_id_fk { get; set; }
        public Nullable<int> asset_category_id_pk { get; set; }
        public Nullable<int> allocated { get; set; }
        public Nullable<int> in_store { get; set; }
        public Nullable<int> in_repair { get; set; }
        public Nullable<int> in_active { get; set; }
        public Nullable<int> discard { get; set; }
        public Nullable<int> theft { get; set; }
        public Nullable<int> total { get; set; }
        public Nullable<int> transit { get; set; }
        public Nullable<int> handover { get; set; }
        public Nullable<int> Scrapped { get; set; }
        public Nullable<int> Sold { get; set; }
        public Nullable<int> supplier_id_pk { get; set; }
        public Nullable<int> location_id_pk { get; set; }
        public Nullable<int> stored_location_id_pk { get; set; }
        public Nullable<int> status_id_pk { get; set; }
        public Nullable<int> asset_admin_id { get; set; }
        public Nullable<int> asset_user_id { get; set; }
        public Nullable<int> warranty_months { get; set; }
        public Nullable<int> life { get; set; }
        public Nullable<int> purchase { get; set; }
        public Nullable<int> warranty { get; set; }
        public Nullable<int> amc { get; set; }
        public Nullable<int> agent24 { get; set; }
        public Nullable<int> agent7D { get; set; }
        public Nullable<int> agent1M { get; set; }
        public Nullable<int> agent3M { get; set; }
        public Nullable<int> connect { get; set; }
        public Nullable<int> seven { get; set; }
        public Nullable<int> fifteen { get; set; }
        public Nullable<int> thirty { get; set; }
        public Nullable<int> gps { get; set; }
        public Nullable<int> sixty { get; set; }
        public Nullable<int> ninty { get; set; }
        public Nullable<int> cc_id_fk { get; set; }
        public Nullable<int> criticality { get; set; }
        public Nullable<int> user_type { get; set; }
        public Nullable<int> prev_main_period { get; set; }
        public Nullable<int> prev_main_schedule { get; set; }
        public Nullable<int> allocated_by { get; set; }

        public Nullable<decimal> purchase_price { get; set; }
        public Nullable<decimal> residual_cost { get; set; }
        public Nullable<decimal> current_cost { get; set; }
        public Nullable<decimal> depreciation { get; set; }
        public Nullable<decimal> current_wdv { get; set; }
        public Nullable<decimal> component_cost { get; set; }

        public Nullable<DateTime> po_date { get; set; } //Earlier Datetime
        public Nullable<DateTime> invoice_date { get; set; }
        public Nullable<DateTime> warranty_start_date { get; set; }
        public Nullable<DateTime> warranty_end_date { get; set; }
        public Nullable<DateTime> amc_start_date { get; set; }
        public Nullable<DateTime> amc_end_date { get; set; }
        public Nullable<DateTime> removal_date { get; set; }
        public Nullable<DateTime> allocated_date { get; set; }
        public Nullable<DateTime> purchase_date { get; set; }
        public Nullable<DateTime> purchase_from { get; set; }
        public Nullable<DateTime> purchase_to { get; set; }
        public Nullable<DateTime> actual_pm_date { get; set; }
        public Nullable<DateTime> edd { get; set; }

        //////public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public string acnknowledge { get; set; }
        public string old_value { get; set; }
        public string new_value { get; set; }
        public string component_name { get; set; }
        public string con_per_name { get; set; }
        public string fault_description { get; set; }
        public string ass_agg_type { get; set; }
        public string parameter { get; set; }
        public string user_con_no { get; set; }
        public string support_type_id { get; set; }
        public string department_name { get; set; }
        public string section_name { get; set; }
        public string sub_location { get; set; }
        public string floor_name { get; set; }
        public string city_name { get; set; }
        public string pincode { get; set; }
        public string cpu { get; set; }
        public string ram { get; set; }
        public string hdd { get; set; }
        public string condition_name { get; set; }
        public string support { get; set; }
        public string serial_number { get; set; }
        public string user_name { get; set; }
        public string status_comments { get; set; }
        public string building_room_no { get; set; }
        public string asset_cat_name { get; set; }
        public string asset_id { get; set; }
        public string supplier_name { get; set; }
        public string asset_tag { get; set; }
        public string manufacturer_name { get; set; }
        public string model_name { get; set; }
        public string asset_name { get; set; }
        public string client_name { get; set; }
        public string location_name { get; set; }
        public string stored_location_name { get; set; }
        public string status { get; set; }
        public string asset_admin_name { get; set; }
        public string asset_user_name { get; set; }
        public string purchase_order { get; set; }
        public string SupplierName { get; set; }
        public string email { get; set; }

        public string condition { get; set; }
        public string invoice_no { get; set; }
        public string Business_unit_id { get; set; }
        public string asset_cat_id { get; set; }
        public string namufacturer_id { get; set; }
        public string location_id { get; set; }
        public string vendor_id { get; set; }
        public string po_num { get; set; }

        //public string invoice_num { get; set; }

        public string life_span { get; set; }
        //public Nullable<DateTime> amc_from { get; set; }
        //public Nullable<DateTime> amc_to { get; set; }
        public string Section { get; set; }
        public string sublocation { get; set; }
        public string Location { get; set; }
        public string hsn_code { get; set; }
        public string item_code { get; set; }
        public string gate_pass_id { get; set; }
        public string pod { get; set; }

        public string cost_centre { get; set; }
        //////public Nullable<int> Created_By { get; set; }
        public string Created_By { get; set; }
        public string createdby { get; set; }

        public string asset_life_expiry { get; set; }

        public string invoice_date_year { get; set; }
        public string AssetImagePath { get; set; }
        public string in_transit_remarks { get; set; }
        public string in_transit_images { get; set; }
    }

    ////public partial class zdesk_m_asset_tbl
    ////{
    ////    public string acnknowledge { get; set; }
    ////    public string old_value { get; set; }
    ////    public string new_value { get; set; }
    ////    public string allocated_date { get; set; }
    ////    public string is_acknowledge { get; set; }
    ////    public string component_name { get; set; }
    ////    public string con_per_name { get; set; }
    ////    public string fault_description { get; set; }
    ////    public string ass_agg_type { get; set; }
    ////    public string created_date { get; set; }
    ////    public string TotalRecord { get; set; }
    ////    public string PageNo { get; set; }
    ////    public string PazeSize { get; set; }
    ////    public string updated_by { get; set; }
    ////    public string mapping_required { get; set; }
    ////    public string parameter { get; set; }
    ////    public string user_con_no { get; set; }
    ////    public string support_type_id { get; set; }
    ////    public string department_name { get; set; }
    ////    public string section_name { get; set; }
    ////    public string sub_location { get; set; }
    ////    public string floor_name { get; set; }
    ////    public string city_name { get; set; }
    ////    public string pincode { get; set; }
    ////    public string cpu { get; set; }
    ////    public string ram { get; set; }
    ////    public string hdd { get; set; }
    ////    public string customer_id_fk { get; set; }
    ////    public string condition_name { get; set; }
    ////    public string support { get; set; }
    ////    public string support_type { get; set; }
    ////    public string pass_status { get; set; }
    ////    public string condition_id_fk { get; set; }
    ////    public string department_id_fk { get; set; }
    ////    public string ticket_id_pk { get; set; }
    ////    public string user_id_fk { get; set; }
    ////    public string asset_id_pk { get; set; }
    ////    public string client_id_fk { get; set; }
    ////    public string sub_location_id_fk { get; set; }
    ////    public string section_id_fk { get; set; }
    ////    public string floor_id_fk { get; set; }
    ////    public string asset_category_id_fk { get; set; }
    ////    public string asset_category_id_pk { get; set; }
    ////    public string allocated { get; set; }
    ////    public string in_store { get; set; }
    ////    public string in_repair { get; set; }
    ////    public string in_active { get; set; }
    ////    public string discard { get; set; }
    ////    public string theft { get; set; }
    ////    public string total { get; set; }
    ////    public string transit { get; set; }
    ////    public string handover { get; set; }
    ////    public string serial_number { get; set; }
    ////    public string user_name { get; set; }
    ////    public string status_comments { get; set; }
    ////    public string building_room_no { get; set; }
    ////    public string asset_cat_name { get; set; }
    ////    public string asset_id { get; set; }
    ////    public string supplier_name { get; set; }
    ////    public string asset_tag { get; set; }
    ////    public string manufacturer_name { get; set; }
    ////    public string model_name { get; set; }
    ////    public string asset_name { get; set; }
    ////    public string client_name { get; set; }
    ////    public string location_name { get; set; }
    ////    public string stored_location_name { get; set; }
    ////    public string status { get; set; }
    ////    public string asset_admin_name { get; set; }
    ////    public string asset_user_name { get; set; }
    ////    public string supplier_id_pk { get; set; }
    ////    public string location_id_pk { get; set; }
    ////    public string stored_location_id_pk { get; set; }
    ////    public string status_id_pk { get; set; }
    ////    public string asset_admin_id { get; set; }
    ////    public string purchase_date { get; set; }
    ////    public string asset_user_id { get; set; }
    ////    public string purchase_order { get; set; }
    ////    public string SupplierName { get; set; }
    ////    public string email { get; set; }
    ////    public string removal_date { get; set; }
    ////    public string purchase_price { get; set; }
    ////    public string condition { get; set; }
    ////    public string warranty_months { get; set; }
    ////    public string invoice_no { get; set; }
    ////    public string invoice_date { get; set; }
    ////    public string warranty_start_date { get; set; }
    ////    public string warranty_end_date { get; set; }
    ////    public string  amc_start_date { get; set; }
    ////    public string amc_end_date { get; set; }
    ////    public string Business_unit_id { get; set; }
    ////    public string asset_cat_id { get; set; }
    ////    public string namufacturer_id { get; set; }
    ////    public string location_id { get; set; }
    ////    public string vendor_id { get; set; }
    ////    public string po_num { get; set; }
    ////    public string po_date { get; set; }
    ////    //public string invoice_num { get; set; }
    ////    public string residual_cost { get; set; }
    ////    public string current_cost { get; set; }
    ////    public string life { get; set; }
    ////    public string depreciation { get; set; }
    ////    public string purchase { get; set; }
    ////    public string warranty { get; set; }
    ////    public string amc { get; set; }
    ////    public string purchase_from { get; set; }
    ////    public string purchase_to { get; set; }
    ////    public string current_wdv { get; set; }
    ////    public string component_cost { get; set; }
    ////    public string agent24 { get; set; }
    ////    public string agent7D { get; set; }
    ////    public string agent1M { get; set; }
    ////    public string agent3M { get; set; }
    ////    public string connect { get; set; }
    ////    public string life_span { get; set; }
    ////    //public Nullable<DateTime> amc_from { get; set; }
    ////    //public Nullable<DateTime> amc_to { get; set; }
    ////    public string Section { get; set; }
    ////    public string thirty { get; set; }
    ////    public string gps { get; set; }
    ////    public string sixty { get; set; }
    ////    public string ninty { get; set; }
    ////    public string hsn_code { get; set; }
    ////    public string item_code { get; set; }
    ////    public string gate_pass_id { get; set; }
    ////    public string criticality { get; set; }
    ////    public string user_type { get; set; }
    ////    public string prev_main_period { get; set; }
    ////    public string prev_main_schedule { get; set; }
    ////    public string actual_pm_date { get; set; }
    ////    public string edd { get; set; }
    ////    public string pod { get; set; }
    ////    public string cc_id_fk { get; set; }
    ////    public string cost_centre { get; set; }
    ////    public string Created_By { get; set; }
    ////    public string createdby { get; set; }
    ////    public string os_type { get; set; }
    ////}

    public partial class zdesk_m_send_to_repair_tbl
    {
        public Nullable<int> component_id_fk { get; set; }
        public Nullable<int> send_to_rep_id_pk { get; set; }
        public string fault_description { get; set; }
        public Nullable<int> asset_id_fk { get; set; }
        public Nullable<int> peripherals_id_fk { get; set; }
        public Nullable<int> non_it_asset_id_pk { get; set; }
        public Nullable<int> supplier_id_fk { get; set; }
        public string con_per_name { get; set; }
        public string supplier_name { get; set; }
        public string contact_no { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public Nullable<DateTime> exp_ret_date { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<int> approver_id_fk { get; set; }
        public string file { get; set; }
        public string ass_agg_type { get; set; }
        public string expected_agreement { get; set; }
        public string attach_budgetary_quote { get; set; }
        public string additional_remark { get; set; }
    }
    public class zdesk_m_fixed_assets_mapping_tbl
    {
        public Nullable<int> asset_id_pk { get; set; }
        public Nullable<int> cpu_sys_hd_id_pk { get; set; }
        public string serial_no { get; set; }
        public string host_name { get; set; }
        public Nullable<int> id { get; set; }
        public Nullable<int> updated_by { get; set; }

    }
    public class zdesk_m_add_asset_tbl
    {
        public Nullable<int> new_asset_id_pk { get; set; }
        public string asset_tag { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string serial_no { get; set; }
        public string Appname { get; set; }
        public string Version { get; set; }
    }
    public partial class zdesk_m_hardware_info_tbl
    {
        public string last_boot_duration { get; set; }
        public string osStatus { get; set; }
        public string log_on_duration { get; set; }
        public string LoggedinUser { get; set; }
        public string user_account_type { get; set; }
        public string c_free { get; set; }

        public string graphic_ram { get; set; }
        public string information { get; set; }
        public string tag { get; set; }
        public string location { get; set; }

        public string ram_speed { get; set; }
        public string ram_type { get; set; }
        public string graphic_id { get; set; }
        public Nullable<int> asset_id_pk { get; set; }
        public Nullable<int> Id { get; set; }
        public string asset_name { get; set; }
        public string LastUpdate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Hostname { get; set; }
        public string Noofprocessor { get; set; }
        public string systemtype { get; set; }
        public string osname { get; set; }
        public string Cpu_info { get; set; }
        public string Graphic_info { get; set; }
        public string machine { get; set; }
        public string processor { get; set; }
        public string version { get; set; }
        public string Domain { get; set; }
        public string hdd_serialno { get; set; }
        public string SerialNo { get; set; }
        public string hdd_model { get; set; }
        public string HDD_PARTIOTNS { get; set; }
        public string HDD_SIZE { get; set; }
        public string HDD_STATUS { get; set; }
        public string details { get; set; }
        public string boottime { get; set; }
        public string physicalcore { get; set; }
        public string totalcore { get; set; }
        public string cpumaxfq { get; set; }
        public string cpuminfq { get; set; }
        public string cpufq { get; set; }
        public string core { get; set; }
        public string cpuusage { get; set; }
        public string memeorytotal { get; set; }
        public string memoryaval { get; set; }
        public string memoryused { get; set; }
        public string percen { get; set; }
        public string ram { get; set; }
        public string diskread { get; set; }
        public string diskwrite { get; set; }
        public string drives { get; set; }
        public string ipaddress { get; set; }
        public string macaddress { get; set; }
        //Added By Umesh
        public string group_id_fk { get; set; }
        public string h_id { get; set; }
        public string missing_patch { get; set; }
        public Nullable<int> is_mapped { get; set; }
        public string registry_key { get; set; }
        public string prodect_key { get; set; }
        public int soft_count { get; set; }
        public int ins_count { get; set; }
        public int mis_count { get; set; }
        public int usb { get; set; }
        public int user_count { get; set; }
        public int folder_count { get; set; }
        public Nullable<DateTime> boot_time { get; set; }
        public string recyle_bin_size { get; set; }
        public string temp_size { get; set; }
        public string os_type { get; set; }
        public string asset_tag { get; set; }
        public string Section { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<int> status { get; set; }
        public string graphis_id { get; set; }

        public string Asset_Make { get; set; }
        public string Asset_Model { get; set; }
        public string Asset_SerialNo { get; set; }
        public Nullable<int> cab_details_id_fk { get; set; }
        public string ParentAgent { get; set; }
        public string agent_version { get; set; }
    }
    public partial class zdesk_m_system_scanner_tbl
    {
        public Nullable<int> Id { get; set; }
        public Nullable<int> asset_id_pk { get; set; }
        public string IP_Address { get; set; }
        public string Mac_Address { get; set; }
        public string Hostname { get; set; }
        public string Vendor_Name { get; set; }
        public string Status { get; set; }
        public Nullable<DateTime> updated_time { get; set; }
    }
    public partial class zdesk_m_software_info_tbl
    {
        public Nullable<int> Id { get; set; }
        public Nullable<int> asset_id_pk { get; set; }
        public string Tg_No { get; set; }
        public string Hostname { get; set; }
        public string Name { get; set; }
        public Nullable<DateTime> InstallationDate { get; set; }
        public string Version { get; set; }
        public string serial_number { get; set; }
        public string Publisher { get; set; }
        public string macaddress { get; set; }
        public string Install_Location { get; set; }
        public string Modify_path { get; set; }
        public string Uninstall_String { get; set; }
        public Nullable<DateTime> Createdate { get; set; }
        ////public Nullable<DateTime> Install_Date { get; set; }
        //////Added  By Umesh
        public string Install_Date { get; set; }
        //Added  By Umesh
        public int Marking { get; set; }
        public string process { get; set; }
        public int count { get; set; }
        public int DetectedCount { get; set; }
        public int app_type { get; set; }
        public string soft_name { get; set; }
    }
    public partial class zdesk_m_window_patch_tbl
    {
        public Nullable<int> asset_id_pk { get; set; }
        public Nullable<int> Id { get; set; }
        public string CsName { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string InstallDate { get; set; }
        public string Status { get; set; }
        public string HostfixID { get; set; }
        public string Installby { get; set; }
        public string Installon { get; set; }
        public string macaddress { get; set; }
        public Nullable<int> approve_status { get; set; }
        public string vendor_name { get; set; }
        public int intall_count { get; set; }
        public string os_type { get; set; }
        public string patch_type { get; set; }
        public Nullable<DateTime> release_date { get; set; }
        public Nullable<int> restart_required { get; set; }
        public string missing_patch { get; set; }
        public int install_status { get; set; }
        public int missing { get; set; }
        public string remarks { get; set; }
        public int installed { get; set; }
        public int is_uninstallable { get; set; }
        public string serial_number { get; set; }
        public string agent_download_link { get; set; }
        public string Classification { get; set; }
        public string Products { get; set; }
        public string Size { get; set; }
        public string uninstallation_notes { get; set; }
        public string uninstallation_steps { get; set; }
        public int download_status { get; set; }
    }
    public class zdesk_m_software_process_tbl
    {
        public int Id { get; set; }
        public string cpu_usage { get; set; }

        public string memory_usage { get; set; }
        public string ProcessId { get; set; }
        public string Name { get; set; }
        public string timestamp { get; set; }
        public string memory { get; set; }
        public string ExecutablePath { get; set; }
        public string InstallDate { get; set; }

        public string OSName { get; set; }
        public string Status { get; set; }
        public string WindowsVersion { get; set; }
        public string SerialNo { get; set; }
    }
    public partial class zdesk_m_device_driver_tbl
    {
        public Nullable<int> Id { get; set; }
        public Nullable<int> asset_id_pk { get; set; }
        public string Hostname { get; set; }
        public string Drivername { get; set; }
        public string Status { get; set; }
        public string macaddress { get; set; }
        public string serial_number { get; set; }
    }
    public partial class zdesk_m_system_services_tbl
    {
        public Nullable<int> Id { get; set; }
        public Nullable<int> asset_id_pk { get; set; }
        public string HostName { get; set; }
        public string ServiceName { get; set; }
        public string StartName { get; set; }
        public string StartMode { get; set; }
        public string ServiceType { get; set; }
        public string Status { get; set; }
        public string State { get; set; }
        public string macaddress { get; set; }
        public string serial_number { get; set; }
    }
    public partial class zdesk_m_sound_info_tbl
    {
        public Nullable<int> Id { get; set; }
        public Nullable<int> asset_id_pk { get; set; }
        public string Hostname { get; set; }
        public string Sounddevice { get; set; }
        public string Status { get; set; }
        public string macaddress { get; set; }
        public string serial_number { get; set; }
    }
    public partial class zdesk_m_printer_info_tbl
    {
        public Nullable<int> Id { get; set; }
        public Nullable<int> asset_id_pk { get; set; }
        public string macaddress { get; set; }
        public string Hostname { get; set; }
        public string Printer { get; set; }
        public string serial_number { get; set; }

    }
    public partial class ZdeskCpuDetails
    {
        public Nullable<int> ram_uses { get; set; }
        public Nullable<int> asset_id_pk { get; set; }
        public Nullable<int> cpu_uses { get; set; }
    }
    public partial class zdesk_m_asset_status_tbl
    {
        public Nullable<int> asset_id_pk { get; set; }
        public Nullable<int> peripherals_id_pk { get; set; }
        public Nullable<int> status_id_pk { get; set; }
        public string status { get; set; }
    }
    public partial class zdesk_m_non_it_asset_tbl
    {
        public Nullable<int> non_it_ass_id_pk { get; set; }
        public Nullable<int> client_id_fk { get; set; }
        public Nullable<int> non_it_ass_cat_id_pk { get; set; }
        public string non_it_ass_cat_name { get; set; }
        public string location_name { get; set; }
        public string status { get; set; }
        public string assets_tag { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string asset_name { get; set; }
        public Nullable<int> supplier_id_fk { get; set; }
        public string supplier_name { get; set; }
        public Nullable<int> location_id_fk { get; set; }
        public Nullable<int> stored_location_id_fk { get; set; }
        public Nullable<int> status_id_fk { get; set; }
        public string serial_number { get; set; }
        public Nullable<int> asset_admin_id { get; set; }
        public DateTime purchase_date { get; set; }
        public Nullable<int> asset_user_id_pk { get; set; }
        public string purchase_order_number { get; set; }
        public DateTime removal_date { get; set; }
        public string purchase_price { get; set; }
        public string condition { get; set; }
        public string warranty { get; set; }
        public string notes { get; set; }
        public Nullable<int> allocated { get; set; }
        public Nullable<int> in_store { get; set; }
        public Nullable<int> in_repair { get; set; }
        public Nullable<int> in_active { get; set; }
        public string manufacturer_name { get; set; }
        public string model_name { get; set; }
        public string client_name { get; set; }
        public string stored_location_name { get; set; }
        public string asset_admin_name { get; set; }
        public string asset_user_name { get; set; }
        public Nullable<int> supplier_id_pk { get; set; }
        public Nullable<int> location_id_pk { get; set; }
        public Nullable<int> stored_location_id_pk { get; set; }
        public Nullable<int> status_id_pk { get; set; }
        public Nullable<int> asset_user_id { get; set; }
        public string purchase_order { get; set; }
        public Nullable<int> warranty_months { get; set; }
        public string invoice_no { get; set; }
        public string created_on_date { get; set; }
        public Nullable<DateTime> invoice_date { get; set; }
        public Nullable<DateTime> warranty_start_date { get; set; }
        public Nullable<DateTime> warranty_end_date { get; set; }
        public Nullable<DateTime> amc_start_date { get; set; }
        public Nullable<DateTime> amc_end_date { get; set; }
    }
    public partial class zdesk_m_Battery_info_tbl
    {
        public Nullable<int> asset_id_fk { get; set; }
        public string Caption { get; set; }
        public string Name { get; set; }
        public string TimeToFullCharge { get; set; }
        public string Status { get; set; }
        public string DeviceID { get; set; }
        public string Serialno { get; set; }
    }

    public partial class zdesk_t_asset_component_tbl
    {
        public string comp_id_pk { get; set; }
        public string ExpressServiceCode { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string serial_number { get; set; }
        public Nullable<int> asset_comp_id_pk { get; set; }
        public Nullable<int> asset_id_fk { get; set; }
        public Nullable<int> component_id_fk { get; set; }
        public Nullable<DateTime> warranty_start_date { get; set; }
        public Nullable<DateTime> warranty_end_date { get; set; }
        public Nullable<int> supplier_id_fk { get; set; }
        public string remarks { get; set; }
        public string component_name { get; set; }
        public string user_name { get; set; }
        public string supplier_name { get; set; }
        
        public decimal component_cost { get; set; }
        public string c_cost { get; set; }
        public string po_number { get; set; }
        public Nullable<DateTime> po_date { get; set; }
        public string invoice_number { get; set; }
        public Nullable<DateTime> invoice_date { get; set; }
        public string serial_no { get; set; }
        public string status_id { get; set; }
        public string status_name { get; set; }
        public string asset_tag { get; set; }
        public string created_on_date { get; set; }
        public string parent_serial_number { get; set; }
    }
    //Added By Umesh 26-05-2021
    public class zdesk_upload_patch_tbl
    {
        public string patch_id { get; set; }
        public int patch_id_pk { get; set; }
        public string vendor_name { get; set; }
        public string bulletin_id { get; set; }
        public string patch_desc { get; set; }
        public int missing { get; set; }
        public int installed { get; set; }
        public Nullable<DateTime> download_date { get; set; }
        public Nullable<DateTime> upload_date { get; set; }
        public int status { get; set; }
        public string patch_location { get; set; }
        public int download_status { get; set; }
        public int install_status { get; set; }
        public string stat { get; set; }
        public string patch_type { get; set; }
        public int severity { get; set; }
        public string os_type { get; set; }
        public Nullable<DateTime> release_date { get; set; }
        public Nullable<int> restart_required { get; set; }
        public Nullable<int> uninstall_support { get; set; }
        public string description { get; set; }
        public string HostfixID { get; set; }
        public string download_link { get; set; }
        public string agent_download_link { get; set; }
        public int count { get; set; }
    }

    public class zdesk_metering_cls
    {
        public int id { get; set; }
        public string sw_name { get; set; }
        public int detect_count { get; set; }
        public int marking { get; set; }
    }

    public class zdesk_m_group_name_tbl
    {
        public int group_id_pk { get; set; }
        public string group_name { get; set; }
        public string dept_name { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public int is_active { get; set; }
    }
    public class zdesk_t_software_list_tbl
    {
        public int soft_id_pk { get; set; }
        public string soft_name { get; set; }
        public string process_name { get; set; }
        public int is_active { get; set; }
        public int status { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public string sf_status { get; set; }
        public string serial_no { get; set; }
        public int app_type { get; set; }
    }
    public class zdesk_t_soft_blacklisted_list_tbl
    {
        public int soft_mng_id_pk { get; set; }
        public string id { get; set; }
        public string serial_no { get; set; }
        public string mac_address { get; set; }
        public string host_name { get; set; }
        public string app_name { get; set; }
        public string exe_name { get; set; }
        public int is_reject { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int updated_by { get; set; }
    }
    public class zdesk_t_group_mapping_tbl
    {
        public int group_map_id_pk { get; set; }
        public string serial_no { get; set; }
        public string mac_address { get; set; }
        public string host_name { get; set; }
        public int group_id_fk { get; set; }
        public string group_id { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public string hardware_id { get; set; }

    }
    public class zdesk_t_deployment_config_tbl
    {
        public int deploy_id_pk { get; set; }
        public int InstalType { get; set; }
        public string InstalTypename { get; set; }
        public int OsType { get; set; }
        public string deploy_name { get; set; }
        public string DeployType { get; set; }
        public string AutomationType { get; set; }
        public string Dep_no { get; set; }
        public string deploy_desc { get; set; }
        public Nullable<DateTime> schedule { get; set; }
        public string patches { get; set; }
        public string deploy_system { get; set; }
        public int is_notification { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public int is_active { get; set; }
        public string created_by { get; set; }
        public int status { get; set; }
        public int complete_count { get; set; }
        public int failed_count { get; set; }
        public int pending_count { get; set; }
        public int deploy_type { get; set; }
        public string ip_address { get; set; }
        public string download_path { get; set; }
        public string message { get; set; }
        public int deployment_time { get; set; }
        public Nullable<int> policy_id_fk { get; set; }
        public string name { get; set; }
        public int automation_type { get; set; }
        public int script_value { get; set; }

    }
    public class zdesk_m_software_process_info
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string CommandLine { get; set; }
        public string CreationDate { get; set; }
        public string Description { get; set; }
        public string ExecutablePath { get; set; }
        public string InstallDate { get; set; }
        public string Name { get; set; }
        public string OSName { get; set; }
        public string ProcessId { get; set; }
        public string Status { get; set; }
        public string WindowsVersion { get; set; }
        public string SerialNo { get; set; }
    }
    public class zdesk_m_asset_document_tbl
    {
        public int asset_doc_id_pk { get; set; }
        public int asset_id_pk { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int is_active { get; set; }
    }
    public class zdesk_m_patch_uninstall_tbl
    {
        public int Id { get; set; }
        public string IP_Address { get; set; }
        public string HostfixId { get; set; }
        public int Status { get; set; }
        public string Serialno { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int uninstall_type { get; set; }
        public int deployment_time { get; set; }
        public int policy { get; set; }
        public Nullable<DateTime> schedule { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int created_by { get; set; }
        public string message { get; set; }
        public int endpoints { get; set; }
        public string creator { get; set; }
        public string patch_desc { get; set; }
        public int notify { get; set; }
        public int patch { get; set; }
    }
    public class get_date
    {
        public string month { get; set; }
        public int year { get; set; }
    }
    public class zdesk_m_update_all_tbl
    {
        public int update_id_pk { get; set; }
        public string host_name { get; set; }
        public string serial_no { get; set; }
        public string ip_address { get; set; }
        public int status { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public int created_by { get; set; }
        public int is_active { get; set; }
    }
    public class zdesk_m_port_disable_tbl
    {
        public int id { get; set; }
        public string hostname { get; set; }
        public string macaddress { get; set; }
        public int status { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public int is_active { get; set; }
        public int state { get; set; }
        public string system_id { get; set; }
    }
    public class DynamicDataHolder
    {
        public string data1 { get; set; }
        public string data2 { get; set; }
        public int[] data3 { get; set; }
        public int total { get; set; }
    }

    public class zdesk_m_shared_folder_tbl
    {
        public int shared_id_pk { get; set; }
        public string folder_name { get; set; }
        public string folder_path { get; set; }
        public string hostname { get; set; }
        public string mac_address { get; set; }
        public string serial_number { get; set; }
        public Nullable<DateTime> created_date { get; set; }
    }
    public class zdesk_m_admin_tbl
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Name { get; set; }
        public int AccountType { get; set; }
        public string Description { get; set; }
        public string LocalAccount { get; set; }
        public string Status { get; set; }
        public string IP_Address { get; set; }
        public string Serialno { get; set; }
        public string hostname { get; set; }
    }
    public class zdesk_m_startup_services_tbl
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string command { get; set; }
        public string userid { get; set; }
        public string location { get; set; }
        public string Serailno { get; set; }
        public string hostname { get; set; }
        public Nullable<DateTime> lastupdate { get; set; }
    }
    public class zdesk_m_usb_port_status_tbl
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string location { get; set; }
        public string serailno { get; set; }
        public string Hostname { get; set; }
        public string ipaddress { get; set; }
        public Nullable<DateTime> lastupdate { get; set; }
    }
    public class zdesk_m_software_install_tbl
    {
        public int Id { get; set; }
        public int deploy_id_fk { get; set; }
        public string hostname { get; set; }
        public string Ip_address { get; set; }
        public string serial_no { get; set; }
        public string macaddress { get; set; }
        public string download_exe { get; set; }
        public string destination_path { get; set; }
        public string exe_path { get; set; }
        public Nullable<DateTime> execution_time { get; set; }
        public Nullable<DateTime> datetime { get; set; }
        public Nullable<int> Status { get; set; }
    }
    public class zdesk_asset_detail_dashboard
    {
        public string AgentSerial { get; set; }
        public string serial { get; set; }
        public string AgentModel { get; set; }
        public string AgentMake { get; set; }
        public string make { get; set; }
        public string hostname { get; set; }
        public string asset_model { get; set; }
        public string business_unit { get; set; }
        public string location { get; set; }
        public string user { get; set; }
        public string group { get; set; }
        public Nullable<DateTime> agent_last { get; set; }
        public string os { get; set; }
        public string hdd { get; set; }
        public string c_part { get; set; }
        public string ram { get; set; }
        public string update { get; set; }
        public string patch_file { get; set; }
        public int install_patch { get; set; }
        public int missing_patch { get; set; }
        public string bin_size { get; set; }
        public int busi_app { get; set; }
        public int ser_running { get; set; }
        public int device_drivers { get; set; }
        public int startup { get; set; }
        public string temp_size { get; set; }
        public int accounts { get; set; }
        public int shared { get; set; }
        public int printer { get; set; }
        public int docs { get; set; }
        public int incidents { get; set; }
        public int task { get; set; }
        public Nullable<DateTime> PM { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public string createdby { get; set; }
        public string life { get; set; }
        public int components { get; set; }
        public int mapped { get; set; }
        public string status { get; set; }
        public string pass_status { get; set; }
        public string supplier { get; set; }
        public string os_type { get; set; }

    }
    public class zdesk_m_asset_status_audit_tbl
    {
        public int asset_audit_id_pk { get; set; }
        public int asset_id_fk { get; set; }
        public int asset_status_id_fk { get; set; }
        public int user_id_fk { get; set; }
        public DateTime updated_date { get; set; }
        public int is_active { get; set; }
        public string user_name { get; set; }
        public string status { get; set; }
    }

    public class zdesk_m_asset_tag_prefix_tbl
    {
        public int asset_tag_prefix_id_pk { get; set; }
        public int business_unit_id_fk { get; set; }
        public int asset_category { get; set; }
        public string asset_tag_prefix { get; set; }
        public string asset_category_name { get; set; }
        public string business_unit_name { get; set; }
    }
    public class zdesk_m_asset_insurance_tbl
    {
        public int insurance_id_pk { get; set; }
        public int asset_id_pk { get; set; }
        public string vendor_name { get; set; }
        public int vendor_id_pk { get; set; }
        public decimal coverage_amt { get; set; }
        public decimal premium { get; set; }
        public Nullable<DateTime> start_date { get; set; }
        public Nullable<DateTime> end_date { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int updated_by { get; set; }
        public string asset_tag { get; set; }

    }

    public class zdesk_m_window_firewall_update_status_tbl
    {
        public int asset_id_pk { get; set; }
        public int Id { get; set; }
        public string hostname { get; set; }
        public string macaddress { get; set; }
        public string serial_no { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public Nullable<DateTime> lastupdate { get; set; }
    }

    public class counter_class
    {
        public int firewall { get; set; }
        public int battery { get; set; }
        public int hdd { get; set; }
        public int network { get; set; }
        public int installed_soft { get; set; }
        public int installed_patch { get; set; }
        public int missing_patch { get; set; }
        public int users { get; set; }
        public int startup { get; set; }
        public int usb { get; set; }
        public int shared { get; set; }
        public int driver { get; set; }
        public int process { get; set; }
        public int sound { get; set; }
        public int printer { get; set; }
        public int license { get; set; }
        public int preventive { get; set; }
        public int task { get; set; }
        public int incident { get; set; }
        public int docs { get; set; }
        public int history { get; set; }
        public int components { get; set; }
        public int status { get; set; }
        public int audit { get; set; }
        public int insurance { get; set; }
    }
    public class zdesk_m_hardware_audit_tbl
    {
        public int hw_audit_id_pk { get; set; }
        public string serial { get; set; }
        public string asset_tag { get; set; }
        public int asset_id_fk { get; set; }
        public string field { get; set; }
        public string new_value { get; set; }
        public string old_value { get; set; }
        public Nullable<DateTime> created_date { get; set; }
    }
    public class zdesk_m_hardisk_details_tbl
    {
        public int Id { get; set; }
        public string drives { get; set; }
        public string drives_size { get; set; }
        public string drives_free { get; set; }
        public string hostname { get; set; }
        public string volumes_serialno { get; set; }
        public string Description { get; set; }
        public string serialno { get; set; }
    }
}