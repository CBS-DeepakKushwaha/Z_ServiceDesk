using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class zdesk_m_ip_status_tbl
    {
        public int Id { get; set; }
        public string ip { get; set; }
        public string msg { get; set; }
        public string flag { get; set; }
        public string status { get; set; }
        public string asset_catg { get; set; }
        public string Name { get; set; }
        public string ip_status_Description { get; set; }
        public string lastupdate { get; set; }
        public string asset_category_name { get; set; }
        public string last_update_time { get; set; }
        public string status_name { get; set; }
        public string NotifyTo { get; set; }
    }
}

