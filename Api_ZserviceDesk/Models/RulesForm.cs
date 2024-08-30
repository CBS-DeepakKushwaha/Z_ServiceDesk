using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public partial class zdesk_m_rules_form_tbl
    {
        public Nullable<int> rules_form_id_pk { get; set; }
        public string Rule_Name { get; set; }
        public Nullable<int> support_department_id_fk { get; set; }
        public Nullable<int> support_group_id_fk { get; set; }
        //////public Nullable<int> technician_id_fk { get; set; }
        public string technician_id_fk { get; set; }
        public Nullable<int> asset_location { get; set; }
        public Nullable<int> user_location { get; set; }
        public Nullable<int> user_is_VIP { get; set; }
        public Nullable<int> asset_category { get; set; }
        public Nullable<int> asset { get; set; }
        public Nullable<int> asset_criticality { get; set; }
        public Nullable<int> priority { get; set; }
        public Nullable<int> incident_sub_category { get; set; }
    }

    public partial class zdesk_m_service_request_rules_form_tbl
    {
        public Nullable<int> rules_form_id_pk { get; set; }
        public string Rule_Name { get; set; }
        public Nullable<int> support_department_id_fk { get; set; }
        public Nullable<int> support_group_id_fk { get; set; }
        //////public Nullable<int> technician_id_fk { get; set; }
        public string technician_id_fk { get; set; }
        public Nullable<int> asset_location { get; set; }
        public Nullable<int> user_location { get; set; }
        public Nullable<int> user_is_VIP { get; set; }
        public Nullable<int> asset_category { get; set; }
        public Nullable<int> asset { get; set; }
        public Nullable<int> asset_criticality { get; set; }
        public Nullable<int> priority { get; set; }
        public Nullable<int> incident_sub_category { get; set; }
    }
}