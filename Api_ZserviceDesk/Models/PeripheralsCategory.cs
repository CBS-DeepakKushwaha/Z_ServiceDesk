using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class PeripheralsCategory
    {
    }
    public partial class zdesk_m_peripherals_category_tbl
    {
        public Nullable<int> p_category_id_pk { get; set; }
        public string category_name { get; set; }
        public int is_active { get; set; }
    }
}