using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class Project
    {
    }
    public partial class zdesk_m_project_manag_status_master_tbl
    {
        public int proj_manag_status_id_pk { get; set; }
        public string status_name { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public Nullable<System.DateTime> updated_date { get; set; }
        public Nullable<int> updated_by { get; set; }

    }
}