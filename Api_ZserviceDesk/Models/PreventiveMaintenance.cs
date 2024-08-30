using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public partial class zdesk_m_preventive_maintainance_tbl
    {
        public Nullable<int> preventive_id_pk { get; set; }
        public Nullable<int> support_dep_id_fk { get; set; }
        public Nullable<int> support_group_id_fk { get; set; }
        public Nullable<int> asset_category_id_fk { get; set; }
        public Nullable<DateTime> due_date { get; set; }
        public Nullable<int> location_id_fk { get; set; }
        public Nullable<int> assign_to_id { get; set; }
    }
    public partial class zdesk_m_preventive_maintainance_activity_tbl
    {
        public Nullable<int> support_dep_id_fk { get; set; }
        public Nullable<int> support_group_id_fk { get; set; }
        public Nullable<int> asset_category_id_fk { get; set; }
        public Nullable<DateTime> due_date { get; set; }
        public Nullable<int> is_discrepency { get; set; }
        public Nullable<int> per_prev_activity_id_pk { get; set; }
        public Nullable<int> p_m_status_id_fk { get; set; }
        public Nullable<int> p_m_activity_id_pk { get; set; }
        public Nullable<int> preventive_id_fk { get; set; }
        public Nullable<int> assign_to { get; set; }
        public string asset_id { get; set; }
        public string asset_cat_name { get; set; }
        public string asset_name { get; set; }
        public string asset_tag { get; set; }
        public string model_name { get; set; }
        public string serial_number { get; set; }
        public string location_name { get; set; }
        public string supplier_name { get; set; }
        public string status { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public string penalty { get; set; }
        public string remark_engineer { get; set; }
        public string remark_user { get; set; }
        public string remarks { get; set; }
    }

    public partial class zdesk_m_peripherals_preventive_maintainance_activity_tbl
    {
        public Nullable<int> per_prev_activity_id_pk { get; set; }
        public Nullable<int> support_dep_id_fk { get; set; }
        public Nullable<int> support_group_id_fk { get; set; }
        public Nullable<int> peripherals_id_fk { get; set; }
        public Nullable<int> preventive_id_fk { get; set; }
        public Nullable<int> assign_to { get; set; }
        public Nullable<int> p_m_status_id_fk { get; set; }
        public string category_name { get; set; }
        public string model_name { get; set; }
        public string assets_tag { get; set; }
        public string serial_number { get; set; }
        public string location_name { get; set; }
        public string supplier_name { get; set; }
        public string status { get; set; }
        public string feedback { get; set; }
        public string remark_engineer { get; set; }
        public string remark_user { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public Nullable<DateTime> maintainance_date { get; set; }
        public Nullable<DateTime> maintainance_date_comp { get; set; }
        public string penalty { get; set; }
        public string name { get; set; }
        public Nullable<int> is_discrepency { get; set; }
        public string descripency_status { get; set; }
    }
    public partial class zdesk_m_preventive_maintaintenance_check_list_tbl
    {
        public Nullable<int> check_list_id_pk { get; set; }
        public Nullable<int> p_m_activity_id_pk { get; set; }
        public Nullable<int> asset_category_id_fk { get; set; }
        public Nullable<int> asset_category_id { get; set; }
        public Nullable<int> p_m_status_id_pk { get; set; }
        public string check_list_content { get; set; }
        public string descripency_status { get; set; }
        public string model_name { get; set; }
        public string serial_number { get; set; }
        public string sub_location { get; set; }
        public string building_room_no { get; set; }
        public string section_name { get; set; }
        public string department_name { get; set; }
        public string user_con_no { get; set; }
        public string user_name { get; set; }
        public string asset_name { get; set; }
        public string prefix { get; set; }
        public string asset_cat_name { get; set; }
        public string asset_tag { get; set; }
        public string asset_id { get; set; }
        public Nullable<DateTime> due_date { get; set; }
        public string name { get; set; }
        public string location_name { get; set; }
        public Nullable<DateTime> maintainance_date { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public string status { get; set; }
        public Nullable<int> feedback { get; set; }
        public Nullable<int> assign_to_id { get; set; }
        public string remark_engineer { get; set; }
        public string remark_user { get; set; }
        public string SUPPORT_TYPE { get; set; }
        public int asset_ids { get; set; }
        public string username { get; set; }

    }
    public partial class zdesk_m_peripherals_preventive_maintaintenance_check_list_tbl
    {
        public Nullable<int> per_check_list_id_pk { get; set; }
        public Nullable<int> periph_category_id_fk { get; set; }
        public Nullable<int> asset_category_id_fk { get; set; }
        public Nullable<int> asset_category_id { get; set; }
        public Nullable<int> p_m_status_id_pk { get; set; }
        public string check_list_content { get; set; }
        public string descripency_status { get; set; }
        public string serial_number { get; set; }
        public string asset_cat_name { get; set; }
        public string asset_tag { get; set; }
        public string asset_id { get; set; }
        public Nullable<DateTime> due_date { get; set; }
        public string name { get; set; }
        public string location_name { get; set; }
        public Nullable<DateTime> maintainance_date { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public string status { get; set; }
        public Nullable<int> feedback { get; set; }
        public Nullable<int> assign_to_id { get; set; }
    }
    public partial class zdesk_m_Preventive_maintainance_status_tbl
    {

        public Nullable<int> per_prev_activity_id_pk { get; set; }
        public Nullable<int> p_m_activity_id_pk { get; set; }
        public Nullable<int> p_m_status_id_pk { get; set; }
        public string status { get; set; }
    }
}