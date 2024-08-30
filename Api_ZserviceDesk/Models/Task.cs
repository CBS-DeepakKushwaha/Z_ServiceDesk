using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class zdesk_m_task_type_tbl
    {
        public Nullable<int> task_type_id_pk { get; set; }
        public string task_type_name { get; set; }
        public Nullable<int> is_active { get; set; }
    }
    public class zdesk_m_task_tbl
    {
        public Nullable<int> task_id_pk { get; set; }
        public string title { get; set; }
        public string cat_id { get; set; }
        public string sub_cat_id { get; set; }
        public int status { get; set; }
        public string status_id { get; set; }
        public string asset_tag { get; set; }
        public string Voilated { get; set; }
        public string support_dep_name { get; set; }
        public string support_dep_group_name { get; set; }
        public string asset_name { get; set; }
        public string priority_name { get; set; }
        public string message { get; set; }
        public string prefix { get; set; }
        public string task_type_name { get; set; }
        public string name { get; set; }
        public string business_unit { get; set; }
        public int module_type { get; set; }
        public string module { get; set; }
        public string module_type_id { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<int> task_type_id_fk { get; set; }
        public string task_id { get; set; }
        public Nullable<int> business_unit_id_fk { get; set; }
        public Nullable<int> support_dep_id_fk { get; set; }
        public Nullable<int> support_group_id_fk { get; set; }
        public string asset_id_fk { get; set; }
        //public Nullable<int> asset_id_fk { get; set; }
        public int asset_id { get; set; }
        public Nullable<int> assign_to { get; set; }
        public Nullable<int> priority_id_fk { get; set; }
        public Nullable<DateTime> due_date { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<int> common_cat_id_fk { get; set; }
        public Nullable<int> sub_category_id_fk { get; set; }
        public string Business_unit_id { get; set; }
        public string task_type_id { get; set; }
        public string support_org_id { get; set; }
        public string support_group_id { get; set; }
        public string priority_id { get; set; }
        public string assign_to_id { get; set; }
        public int incident_id_fk { get; set; }
        public int request_id_fk { get; set; }
        public int problem_id_fk { get; set; }
        public int change_id_fk { get; set; }
        public Nullable<int> due { get; set; }
        public Nullable<DateTime> to_date { get; set; }
        public Nullable<DateTime> from_date { get; set; }
    }
    public class zdesk_m_task_templete_tbl
    {
        public Nullable<int> task_templete_id_pk { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string Voilated { get; set; }
        public string support_dep_name { get; set; }
        public string support_dep_group_name { get; set; }
        public string asset_name { get; set; }
        public string priority_name { get; set; }
        public string message { get; set; }
        public string prefix { get; set; }
        public string task_type_name { get; set; }
        public string name { get; set; }
        public string business_unit { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<int> task_type_id_fk { get; set; }
        public Nullable<int> business_unit_id_fk { get; set; }
        public Nullable<int> support_dep_id_fk { get; set; }
        public Nullable<int> support_group_id_fk { get; set; }
        public Nullable<int> asset_id_fk { get; set; }
        public Nullable<int> assign_to { get; set; }
        public Nullable<int> priority_id_fk { get; set; }
        public Nullable<DateTime> due_date { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<int> common_cat_id_fk { get; set; }
        public Nullable<int> sub_category_id_fk { get; set; }
        public string category_name { get; set; }
        public string sub_category_name { get; set; }
    }
}