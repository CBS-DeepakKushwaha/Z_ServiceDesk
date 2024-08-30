using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    ////get_cpu_monitoring_by_serialnumber_sp
    ////get_disk_monitoring_by_serialnumber_sp
    ////get_memory_monitoring_by_serialnumber_sp
    ////get_network_monitoring_by_serialnumber_sp
    ////get_system_hardware_by_serialnumber_sp

    public class CPU_Monitor
    {
        public Nullable<int> Id { get; set; }
        public string cputimes_user { get; set; }
        public string cpuutilization { get; set; }
        public string ip_address { get; set; }
        public string logical_processor { get; set; }
        public string cores { get; set; }
        public string l3_cache { get; set; }
        public string l2_cache { get; set; }
        public string cpuruntime { get; set; }
        public string serialnumber { get; set; }
        public string hostname { get; set; }
        public string process_count { get; set; }
        public string Th_count { get; set; }
        public string interput_time { get; set; }
        public string lastupdate { get; set; }
        public string sockets { get; set; }
        public string PID_process { get; set; }
        public string ctx_switch { get; set; }
        public string soft_interrupt { get; set; }
        public string sys_calls { get; set; }
    }

    public class Disk_Montoring
    {
        public Nullable<int> Id { get; set; }
        public string c_total { get; set; }
        public string Used { get; set; }
        public string Free { get; set; }
        public string Used_percent { get; set; }
        public string size { get; set; }
        public string read_count { get; set; }
        public string write_count { get; set; }
        public string read_bytes { get; set; }
        public string write_bytes { get; set; }
        public string read_time { get; set; }
        public string write_time { get; set; }
        public string last_update { get; set; }
        public string serialnumber { get; set; }
        public string ipaddress { get; set; }
        public string read_per_second { get; set; }
        public string write_per_second { get; set; }
        public string total_partitions { get; set; }
    }

    public class Memory_Monitor
    {
        public Nullable<int> Id { get; set; }
        public string v_total { get; set; }
        public string v_used { get; set; }
        public string v_free { get; set; }
        public string s_total { get; set; }
        public string s_used { get; set; }
        public string s_free { get; set; }
        public string Swap_used_per { get; set; }
        public string Swap_sin { get; set; }
        public string Swap_sout { get; set; }
        public string rss { get; set; }
        public string vms { get; set; }
        public string num_page_faults { get; set; }
        public string peak_wset { get; set; }
        public string wset { get; set; }
        public string peak_paged_pool { get; set; }
        public string paged_pool { get; set; }
        public string peak_nonpaged_pool { get; set; }
        public string nonpaged_pool { get; set; }
        public string pagefile { get; set; }
        public string peak_pagefile { get; set; }
        ////public string private { get; set; }
        public string uss { get; set; }
        public string last_update { get; set; }
        public string serialnumber { get; set; }
        public string ipaddress { get; set; }
        public string page_reads { get; set; }
        public string page_writes { get; set; }
        public string page_output { get; set; }
        public string free_memory { get; set; }
    }

    public class Network_Montoring
    {
        public Nullable<int> Id { get; set; }
        public string KB_sent { get; set; }
        public string KB_recv { get; set; }
        public string packet_sent { get; set; }
        public string packet_recv { get; set; }
        public string error_sent { get; set; }
        public string error_recv { get; set; }
        public string pct_drop_sent { get; set; }
        public string pct_drop_recv { get; set; }
        public string lastupdate { get; set; }
        public string serialnumber { get; set; }
        public string ipaddress { get; set; }
    }

    ////////public class zdesk_m_hardware_info_tbl
    ////////{
    ////////    public Nullable<int> Id { get; set; }
    ////////    public Nullable<int> asset_id_pk { get; set; }
    ////////    public string LastUpdate { get; set; }
    ////////    public string Make { get; set; }
    ////////    public string Model { get; set; }
    ////////    public string Hostname { get; set; }
    ////////    public string Noofprocessor { get; set; }
    ////////    public string systemtype { get; set; }
    ////////    public string osname { get; set; }
    ////////    public string Cpu_info { get; set; }
    ////////    public string Graphic_info { get; set; }
    ////////    public string machine { get; set; }
    ////////    public string processor { get; set; }
    ////////    public string version { get; set; }
    ////////    public string Domain { get; set; }
    ////////    public string hdd_serialno { get; set; }
    ////////    public string hdd_model { get; set; }
    ////////    public string HDD_PARTIOTNS { get; set; }
    ////////    public string HDD_SIZE { get; set; }
    ////////    public string HDD_STATUS { get; set; }
    ////////    public string details { get; set; }
    ////////    public string boottime { get; set; }
    ////////    public string physicalcore { get; set; }
    ////////    public string totalcore { get; set; }
    ////////    public string cpumaxfq { get; set; }
    ////////    public string cpuminfq { get; set; }
    ////////    public string cpufq { get; set; }
    ////////    public string core { get; set; }
    ////////    public string cpuusage { get; set; }
    ////////    public string memeorytotal { get; set; }
    ////////    public string memoryaval { get; set; }
    ////////    public string memoryused { get; set; }
    ////////    public string percen { get; set; }
    ////////    public string ram { get; set; }
    ////////    public string diskread { get; set; }
    ////////    public string diskwrite { get; set; }
    ////////    public string registry_key { get; set; }
    ////////    public string prodect_key { get; set; }
    ////////    public string drives { get; set; }
    ////////    public string ipaddress { get; set; }
    ////////    public string macaddress { get; set; }
    ////////    public int is_mapped { get; set; }
    ////////    public string os_type { get; set; }
    ////////    public string SerialNo { get; set; }
    ////////    public string group_id_fk { get; set; }

    ////////}

    public class zdesk_m_hardware_info_Index
    {
        public string Id { get; set; }
        public string serialno { get; set; }
        public string os_type { get; set; }
        public string osname { get; set; }
        public string cpuutilization { get; set; }
        public string v_free { get; set; }
        public string used_percent { get; set; }
        public string lastupdate { get; set; }
        public string PowerStatus { get; set; }
        public Nullable<int> group_master_id_fk { get; set; }

        public string cpuutilization_color { get; set; }
        public string v_free_color { get; set; }
        public string used_percent_color { get; set; }

        public string Section { get; set; }
    }

    ////////public class Charts
    ////////{
    ////////    public string NAME { get; set; }
    ////////    public string VALUE { get; set; }
    ////////}

    ////////public class Charts_Params
    ////////{
    ////////    public string Section { get; set; }
    ////////    public string serialnumber { get; set; }
    ////////    public string Param1 { get; set; }
    ////////}

    ////////public partial class zdesk_m_asset_tbl
    ////////{
    ////////    public string component_name { get; set; }
    ////////    public string con_per_name { get; set; }
    ////////    public string fault_description { get; set; }
    ////////    public string ass_agg_type { get; set; }
    ////////    public Nullable<DateTime> created_date { get; set; }
    ////////    public Nullable<int> TotalRecord { get; set; }
    ////////    public Nullable<int> PageNo { get; set; }
    ////////    public Nullable<int> PazeSize { get; set; }
    ////////    public Nullable<int> updated_by { get; set; }
    ////////    public Nullable<int> mapping_required { get; set; }
    ////////    public string parameter { get; set; }
    ////////    public string user_con_no { get; set; }
    ////////    public string support_type_id { get; set; }
    ////////    public string department_name { get; set; }
    ////////    public string section_name { get; set; }
    ////////    public string sub_location { get; set; }
    ////////    public string floor_name { get; set; }
    ////////    public string city_name { get; set; }
    ////////    public string pincode { get; set; }
    ////////    public string cpu { get; set; }
    ////////    public string ram { get; set; }
    ////////    public string hdd { get; set; }
    ////////    public Nullable<int> customer_id_fk { get; set; }
    ////////    public string condition_name { get; set; }
    ////////    public string support { get; set; }
    ////////    public Nullable<int> support_type { get; set; }
    ////////    public Nullable<int> condition_id_fk { get; set; }
    ////////    public Nullable<int> department_id_fk { get; set; }
    ////////    public Nullable<int> ticket_id_pk { get; set; }
    ////////    public Nullable<int> user_id_fk { get; set; }
    ////////    public Nullable<int> asset_id_pk { get; set; }
    ////////    public Nullable<int> client_id_fk { get; set; }
    ////////    public Nullable<int> sub_location_id_fk { get; set; }
    ////////    public Nullable<int> section_id_fk { get; set; }
    ////////    public Nullable<int> floor_id_fk { get; set; }
    ////////    public Nullable<int> asset_category_id_fk { get; set; }
    ////////    public Nullable<int> asset_category_id_pk { get; set; }
    ////////    public Nullable<int> allocated { get; set; }
    ////////    public Nullable<int> in_store { get; set; }
    ////////    public Nullable<int> in_repair { get; set; }
    ////////    public Nullable<int> in_active { get; set; }
    ////////    public Nullable<int> discard { get; set; }
    ////////    public Nullable<int> theft { get; set; }
    ////////    public Nullable<int> total { get; set; }
    ////////    public string serial_number { get; set; }
    ////////    public string user_name { get; set; }
    ////////    public string status_comments { get; set; }
    ////////    public string building_room_no { get; set; }
    ////////    public string asset_cat_name { get; set; }
    ////////    public string asset_id { get; set; }
    ////////    public string supplier_name { get; set; }
    ////////    public string asset_tag { get; set; }
    ////////    public string manufacturer_name { get; set; }
    ////////    public string model_name { get; set; }
    ////////    public string asset_name { get; set; }
    ////////    public string client_name { get; set; }
    ////////    public string location_name { get; set; }
    ////////    public string stored_location_name { get; set; }
    ////////    public string status { get; set; }
    ////////    public string asset_admin_name { get; set; }
    ////////    public string asset_user_name { get; set; }
    ////////    public Nullable<int> supplier_id_pk { get; set; }
    ////////    public Nullable<int> location_id_pk { get; set; }
    ////////    public Nullable<int> stored_location_id_pk { get; set; }
    ////////    public Nullable<int> status_id_pk { get; set; }
    ////////    public Nullable<int> asset_admin_id { get; set; }
    ////////    public Nullable<DateTime> purchase_date { get; set; }
    ////////    public Nullable<int> asset_user_id { get; set; }
    ////////    public string purchase_order { get; set; }
    ////////    public string SupplierName { get; set; }
    ////////    public string email { get; set; }
    ////////    public Nullable<DateTime> removal_date { get; set; }
    ////////    public Nullable<decimal> purchase_price { get; set; }
    ////////    public string condition { get; set; }
    ////////    public Nullable<int> warranty_months { get; set; }
    ////////    public string invoice_no { get; set; }
    ////////    public Nullable<DateTime> invoice_date { get; set; }
    ////////    public Nullable<DateTime> warranty_start_date { get; set; }
    ////////    public Nullable<DateTime> warranty_end_date { get; set; }
    ////////    public Nullable<DateTime> amc_start_date { get; set; }
    ////////    public Nullable<DateTime> amc_end_date { get; set; }
    ////////    public string Business_unit_id { get; set; }
    ////////    public string asset_cat_id { get; set; }
    ////////    public string namufacturer_id { get; set; }
    ////////    public string location_id { get; set; }
    ////////    public string vendor_id { get; set; }
    ////////    public string po_num { get; set; }
    ////////    public Nullable<DateTime> po_date { get; set; }
    ////////    //public string invoice_num { get; set; }
    ////////    public Nullable<decimal> residual_cost { get; set; }
    ////////    public Nullable<int> life { get; set; }
    ////////    public Nullable<decimal> depreciation { get; set; }
    ////////    public Nullable<int> purchase { get; set; }
    ////////    public Nullable<int> warranty { get; set; }
    ////////    public Nullable<int> amc { get; set; }
    ////////    public Nullable<DateTime> purchase_from { get; set; }
    ////////    public Nullable<DateTime> purchase_to { get; set; }
    ////////    public Nullable<decimal> current_wdv { get; set; }
    ////////    public Nullable<decimal> component_cost { get; set; }
    ////////    public Nullable<int> agent24 { get; set; }
    ////////    public Nullable<int> agent7D { get; set; }
    ////////    public Nullable<int> agent1M { get; set; }
    ////////    public Nullable<int> agent3M { get; set; }
    ////////    public Nullable<int> connect { get; set; }
    ////////    public string life_span { get; set; }
    ////////    //public Nullable<DateTime> amc_from { get; set; }
    ////////    //public Nullable<DateTime> amc_to { get; set; }

    ////////    public string Section { get; set; }
    ////////}

    ////////public partial class zdesk_m_allocate_consumable_item_tbl
    ////////{
    ////////    public string reciever_name { get; set; }
    ////////    public string reciever_contact_no { get; set; }
    ////////    public Nullable<int> stored_location_id_fk { get; set; }
    ////////    public int category { get; set; }
    ////////    public int item_name { get; set; }
    ////////    public int employee_id_fk { get; set; }
    ////////    public DateTime allocate_date { get; set; }
    ////////    public Nullable<int> quantity { get; set; }

    ////////    public string user_name { get; set; }
    ////////    public string Section { get; set; }
    ////////}

    ////////public partial class zdesk_stock_ledger_tbl
    ////////{
    ////////    public Nullable<int> peripherals_store_id_pk { get; set; }
    ////////    public Nullable<int> store_loc_id_fk { get; set; }
    ////////    public Nullable<int> category_id_fk { get; set; }
    ////////    public string category_name { get; set; }
    ////////    public string file_upload { get; set; }
    ////////    public string name { get; set; }
    ////////    public string id { get; set; }
    ////////    public Nullable<DateTime> creted_date { get; set; }
    ////////    public Nullable<int> item_id_fk { get; set; }
    ////////    public string item_name { get; set; }
    ////////    public string allocated { get; set; }
    ////////    public string added { get; set; }
    ////////    public string balance { get; set; }
    ////////    public string item_code { get; set; }
    ////////    public string stored_location_name { get; set; }
    ////////    public int item_in { get; set; }
    ////////    public int item_out { get; set; }
    ////////    public int ref_id { get; set; }
    ////////    public int quantity { get; set; }

    ////////    public string user_name { get; set; }
    ////////    public string Section { get; set; }
    ////////}

    ////////public partial class zdesk_m_software_tbl
    ////////{
    ////////    public Nullable<int> software_id_pk { get; set; }
    ////////    public Nullable<int> location_id_fk { get; set; }
    ////////    public Nullable<int> stored_location_id_fk { get; set; }
    ////////    public Nullable<int> soft_catogory_id_fk { get; set; }
    ////////    public Nullable<int> publisher_id_fk { get; set; }
    ////////    public Nullable<int> soft_name_id_fk { get; set; }
    ////////    public string license_type { get; set; }
    ////////    public string license_no { get; set; }
    ////////    public string from_date { get; set; }
    ////////    public string to_date { get; set; }
    ////////    public Nullable<int> qty { get; set; }
    ////////    public Nullable<decimal> unit_price { get; set; }
    ////////    public string software_name { get; set; }
    ////////    public string location_name { get; set; }
    ////////    public string stored_location_name { get; set; }
    ////////    public string soft_category_name { get; set; }
    ////////    public string publisher_name { get; set; }
    ////////    //
    ////////    public int soft_uom { get; set; }
    ////////    public Nullable<decimal> total_price { get; set; }
    ////////    public Nullable<DateTime> created_date { get; set; }
    ////////    public string email { get; set; }

    ////////    public string user_name { get; set; }
    ////////    public string Section { get; set; }
    ////////}

    ////////public partial class zdesk_m_users_tbl
    ////////{
    ////////    public Nullable<int> sub_location_id_fk { get; set; }
    ////////    public Nullable<int> floor_id_fk { get; set; }
    ////////    public string sub_location { get; set; }
    ////////    public string room_no { get; set; }
    ////////    public string location_name { get; set; }
    ////////    public string department_name { get; set; }
    ////////    public string ext_no { get; set; }
    ////////    public string floor_name { get; set; }
    ////////    public Nullable<int> user_id_pk { get; set; }
    ////////    public Nullable<int> is_vip { get; set; }
    ////////    public Nullable<int> updated_by { get; set; }
    ////////    public Nullable<int> role_id { get; set; }
    ////////    public Nullable<int> reporting_manager { get; set; }
    ////////    public Nullable<int> department_head { get; set; }
    ////////    public string type { get; set; }
    ////////    public string user_name { get; set; }
    ////////    public string email { get; set; }
    ////////    public string title { get; set; }
    ////////    public string role { get; set; }
    ////////    public string city { get; set; }
    ////////    public string state { get; set; }
    ////////    public string user_code { get; set; }
    ////////    public string manager_name { get; set; }
    ////////    public string mobile_no { get; set; }
    ////////    public string support_dep_group { get; set; }
    ////////    public Nullable<int> roleid { get; set; }
    ////////    public Nullable<int> location_id_fk { get; set; }
    ////////    public Nullable<int> business_unit_id_fk { get; set; }
    ////////    public Nullable<int> department_id_fk { get; set; }
    ////////    public string password { get; set; }
    ////////    public string display_name { get; set; }
    ////////    public string reporting_manager_email { get; set; }
    ////////    public string department_head_email { get; set; }
    ////////    public string business_head_email { get; set; }
    ////////    public int support_dept_id_fk { get; set; }
    ////////    public int support_group_id_fk { get; set; }

    ////////    public string Section { get; set; }
    ////////}

    ////////public partial class zdesk_m_software_info_tbl
    ////////{
    ////////    public Nullable<int> Id { get; set; }
    ////////    public Nullable<int> asset_id_pk { get; set; }
    ////////    public string Tg_No { get; set; }
    ////////    public string Hostname { get; set; }
    ////////    public string Name { get; set; }
    ////////    public Nullable<DateTime> InstallationDate { get; set; }
    ////////    public string Version { get; set; }
    ////////    public string serial_number { get; set; }
    ////////    public string Publisher { get; set; }
    ////////    public string macaddress { get; set; }
    ////////    public string Install_Location { get; set; }
    ////////    public string Modify_path { get; set; }
    ////////    public string Uninstall_String { get; set; }
    ////////    public Nullable<DateTime> Createdate { get; set; }
    ////////    public Nullable<DateTime> Install_Date { get; set; }
    ////////    //Added  By Umesh
    ////////    public int Marking { get; set; }
    ////////    public string process { get; set; }
    ////////    public int count { get; set; }
    ////////}

    ////////public partial class zdesk_m_window_patch_tbl
    ////////{
    ////////    public Nullable<int> asset_id_pk { get; set; }
    ////////    public Nullable<int> Id { get; set; }

    ////////    public string CsName { get; set; }
    ////////    public string Name { get; set; }
    ////////    public string Caption { get; set; }
    ////////    public string Description { get; set; }
    ////////    public string InstallDate { get; set; }
    ////////    public string Status { get; set; }
    ////////    public string HostfixID { get; set; }
    ////////    public string Installby { get; set; }
    ////////    public string Installon { get; set; }
    ////////    public string macaddress { get; set; }
    ////////    public Nullable<int> approve_status { get; set; }
    ////////    //Added By Umesh
    ////////    public string vendor_name { get; set; }
    ////////    public int intall_count { get; set; }
    ////////    public string os_type { get; set; }
    ////////    public string patch_type { get; set; }
    ////////    public Nullable<DateTime> release_date { get; set; }
    ////////    public Nullable<int> restart_required { get; set; }
    ////////    public string missing_patch { get; set; }
    ////////    public int install_status { get; set; }
    ////////    public int missing { get; set; }
    ////////    public string remarks { get; set; }
    ////////    public int installed { get; set; }
    ////////    public int is_uninstallable { get; set; }
    ////////}

    ////////public partial class zdesk_m_device_driver_tbl
    ////////{
    ////////    public Nullable<int> Id { get; set; }
    ////////    public Nullable<int> asset_id_pk { get; set; }
    ////////    public string Hostname { get; set; }
    ////////    public string Drivername { get; set; }
    ////////    public string Status { get; set; }
    ////////    public string macaddress { get; set; }
    ////////}

    ////////public partial class zdesk_m_system_services_tbl
    ////////{
    ////////    public Nullable<int> Id { get; set; }
    ////////    public Nullable<int> asset_id_pk { get; set; }
    ////////    public string HostName { get; set; }
    ////////    public string ServiceName { get; set; }
    ////////    public string StartName { get; set; }
    ////////    public string StartMode { get; set; }
    ////////    public string ServiceType { get; set; }
    ////////    public string Status { get; set; }
    ////////    public string State { get; set; }
    ////////    public string macaddress { get; set; }
    ////////}

    ////////public partial class zdesk_m_sound_info_tbl
    ////////{
    ////////    public Nullable<int> Id { get; set; }
    ////////    public Nullable<int> asset_id_pk { get; set; }
    ////////    public string Hostname { get; set; }
    ////////    public string Sounddevice { get; set; }
    ////////    public string Status { get; set; }
    ////////    public string macaddress { get; set; }
    ////////}

    ////////public partial class zdesk_m_printer_info_tbl
    ////////{
    ////////    public Nullable<int> Id { get; set; }
    ////////    public Nullable<int> asset_id_pk { get; set; }
    ////////    public string macaddress { get; set; }
    ////////    public string Hostname { get; set; }
    ////////    public string Printer { get; set; }
    ////////}

    public partial class zdesk_m_asset_notifications_tbl
    {
        public Nullable<int> asset_notifications_id_pk { get; set; }
        public Nullable<int> asset_id_fk { get; set; }
        public Nullable<int> severity { get; set; }
        public Nullable<int> Parameter { get; set; }
        public Nullable<int> ThresholdPer { get; set; }
        public string Notify_To { get; set; }
        public string BarColor { get; set; }

        public string serial_number { get; set; }
        public string severity_name { get; set; }
        public string Parameter_name { get; set; }
        public string BarColor_name { get; set; }
    }

    public partial class zdesk_m_alert_notifications_tbl
    {
        public Nullable<int> alert_notifications_id_pk { get; set; }
        public Nullable<int> asset_id_fk { get; set; }
        public Nullable<int> severity { get; set; }
        public Nullable<int> Parameter { get; set; }
        public Nullable<int> ThresholdPer { get; set; }
        public string Notify_To { get; set; }
        public string Comments { get; set; }
        public bool is_email_sent { get; set; }

        public string Email_Sent { get; set; }
        public string serial_number { get; set; }
        public string severity_name { get; set; }
        public string Parameter_name { get; set; }
        public string BarColor_name { get; set; }
    }

    public partial class zdesk_m_asset_group_master_tbl
    {
        public Nullable<int> group_master_id_pk { get; set; }
        public string group_name { get; set; }
    }

    public partial class zdesk_m_asset_group_taggings_tbl
    {
        public Nullable<int> asset_group_taggings_id_pk { get; set; }
        public Nullable<int> group_master_id_fk { get; set; }
        public Nullable<int> asset_id_fk { get; set; }

        public string group_name { get; set; }
        public string asset_serial_number { get; set; }
    }
    public partial class Network_interface_monitoring
    {
        public int Id { get; set; }
        public string autosense { get; set; }
        public string AdapterType { get; set; }
        public string Availability{ get; set; }
        public string Description{ get; set; }
        public string MACAddress{ get; set; }
        public string Manufacturer{ get; set; }
        public string MaxSpeed{ get; set; }
        public string ServiceName{ get; set; }
        public string Speed{ get; set; }
        public string StatusInfo{ get; set; }
        public string Status{ get; set; }
        public string ProductName{ get; set; }
        public Nullable<DateTime> lastupdate{ get; set; }
        public string serialnumber{ get; set; }
        public string name{ get; set; }
        public string ipaddress{ get; set; }
    }

    public class Zdesk_m_purchase_order_Print
    {
        public zdesk_m_purchase_order_tbl purchaseDetails { get; set; }
        public IEnumerable<zdesk_m_purchase_order_grid_tbl> GridData { get; set; }
    }
    public partial class zdesk_m_purchase_order_tbl
    {
        public int purchase_order_id_pk { get; set; }
        public int service_request_id_fk { get; set; }
        public int requested_by { get; set; }
        public int assigned_to { get; set; }
        public string PO_No { get; set; }
        public string PO_Name { get; set; }
        public string logo { get; set; }
        public string Ponumber { get; set; }
        public string Approver1 { get; set; }
        public string Approver2 { get; set; }
        public string Approver3 { get; set; }
        public string ReferanceNumber { get; set; }
        public string vendor_Name { get; set; }
        public string vendor_Address { get; set; }
        public string vendor_Contact_Name { get; set; }
        public string vendor_Contact_No { get; set; }
        public string vendor_Email { get; set; }
        public int PO_Status { get; set; }
        public string required_by { get; set; }
        public string billing_address { get; set; }
        public string shipping_address { get; set; }
        public double Sub_Total { get; set; }
        public double Discount { get; set; }
        public double Additional_Tax_Rate { get; set; }
        public double Price_Adjustment { get; set; }
        public double Additional_Cost { get; set; }
        public double Total { get; set; }
        public string TandC { get; set; }
        public string Additional_Remarks { get; set; }
        public string Signing_Authority { get; set; }
        public string Approver_L1 { get; set; }
        public string Approver_L2 { get; set; }
        public string Approver_L3 { get; set; }

        public string required_by_Name { get; set; }
        public string PO_Status_Name { get; set; }
        public string Owner_Name { get; set; }
        public string ApproverLevel { get; set; }
        public int purchase_order_status { get; set; }
        public int purchase_order_status1 { get; set; }
        public int purchase_order_status2 { get; set; }
        public string approver_id { get; set; }
        public string approver_name { get; set; }
        public string approver_comments { get; set; }
        public string approver_comments1 { get; set; }
        public string approver_comments2 { get; set; }
    }

    public partial class zdesk_m_purchase_order_grid_tbl
    {
        public int purchase_order_grid_id_pk { get; set; }
        public int purchase_order_id_fk { get; set; }
        public string Item_Name { get; set; }
        public string PartNo { get; set; }
        public int Qty { get; set; }
        public double UnitPrice { get; set; }
        public double TaxPer { get; set; }
        public double Amount { get; set; }
    }
    public partial class zdesk_m_Purchase_invoice_tbl
    {
        public int Id { get; set; }
        public int purchase_order_id_fk { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<DateTime> ReceivedDate { get; set; }
        public string ReceivedBy { get; set; }
        public Nullable<DateTime> PaymentDueDate { get; set; }
        public string Remarks { get; set; }
        public int Purchase_Id_Fk { get; set; }
    }
    public partial class zdesk_m_Purchase_Payment_tbl
    {
        public int Id { get; set; }
        public int purchase_order_id_fk { get; set; }
        public string paymentAmount { get; set; }
        public Nullable<DateTime> paidOn { get; set; }
        public string ApprovedBy { get; set; }
        public string Remarks { get; set; }
        public int Purchase_Id_Fk { get; set; }
        public string Comments { get; set; }
    }

    public class zdesk_t_purchase_order_approval_status_tbl
    {
        public Nullable<int> ser_req_approval_id_pk { get; set; }
        public Nullable<int> purchase_order_id_pk { get; set; }
        public Nullable<int> approver_id_pk { get; set; }
        public Nullable<int> ser_req_approval_status { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public string status { get; set; }
        public string email { get; set; }
        public string user_name { get; set; }
        public string title { get; set; }
        public string display_name { get; set; }
    }
}

