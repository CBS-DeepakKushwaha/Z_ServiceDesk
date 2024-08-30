using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class zdesk_m_configuration_menu_tbl
    {
        public Nullable<int> configuration_menu_id_pk { get; set; }
        public string name { get; set; }
        public string parent { get; set; }
        public string description { get; set; }
        public string file_path { get; set; }
        public decimal depreciation { get; set; }
        public Nullable<int> parent_ci { get; set; }
        public Nullable<int> ID { get; set; } 
        public Nullable<int> is_active { get; set; }
        public Nullable<int> life { get; set; }

        public string Section { get; set; }
        public string ParentName { get; set; }
        public Nullable<int> Level { get; set; }

        public Nullable<int> AssetCount { get; set; }

        public Nullable<int> IsAvailabilityMonitoring { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> MenuFlag { get; set; }
    }

    public class zdesk_m_configuration_menu_additional_tbl
    {
        public Nullable<int> configuration_menu_additional_id_pk { get; set; }
        public Nullable<int> configuration_menu_id_fk { get; set; }
        //////public string field_name { get; set; }
        //////public string field_html { get; set; }
        //////public string output_html { get; set; }
        public string configuration_question_data { get; set; }
        public string configuration_data { get; set; }
    }
}