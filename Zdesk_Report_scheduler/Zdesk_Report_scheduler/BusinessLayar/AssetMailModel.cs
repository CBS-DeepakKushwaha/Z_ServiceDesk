using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdesk_Report_scheduler.BusinessLayar
{
    public class AssetMailModel
    {
        public string Client_name { get; set; }
        public string asset_cat_name { get; set; }
        public string asset_tag { get; set; }
        public string model_name { get; set; }
        public string serial_number { get; set; }
        public string email { get; set; }
        public string user_name { get; set; }
        public int asset_id_pk { get; set; }
        public int Is_acknowledgeMailCount { get; set; }
    }
    public class EmailTemplateModel
    {
        public Nullable<int> id { get; set; }
        public Nullable<int> templete_type { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }
        public string subject { get; set; }
    }

    public class HW_Audit
    {
        public int hw_audit_id_pk { get; set; }
        public string asset_tag { get; set; }
        public string serial{ get; set; }
        public string field{ get; set; }
        public string new_value{ get; set; }
        public string old_value{ get; set; }
        public string created_date{ get; set; }
        public int is_notify{ get; set; }
    }
}

