using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class ReasonForChange
    {
    }
    public partial class zdesk_m_reason_for_change_tbl
    {
        public Nullable<int> asset_category_id_pk { get; set; }
        public string asset_cat_name { get; set; }
        public int is_active { get; set; }
    }
}