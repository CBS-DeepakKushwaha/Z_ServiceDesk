using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public partial class zdesk_m_problems_tbl
    {
        public string tickets_id { get; set; }
        public Nullable<int> promblems_id_pk { get; set; }
        public Nullable<int> support_group_id_fk { get; set; }
        public string subject { get; set; }
        public string category_name { get; set; }
        public string submitter { get; set; }
        public string assign { get; set; }
        public Nullable<int> status_count { get; set; }
        public string status { get; set; }
        public string prefix { get; set; }
        public Nullable<int> submitted_by_id { get; set; }
        public Nullable<int> status_id_fk { get; set; }
        public Nullable<int> common_cat_id_pk { get; set; }
        public Nullable<int> sub_category_id_pk { get; set; }
        public Nullable<int> business_unit_id_pk { get; set; }
        public Nullable<int> location_id_fk { get; set; }
        public Nullable<int> impact_id_pk { get; set; }
        public Nullable<int> urgency_id_fk { get; set; }
        public Nullable<int> support_dep_id_pk { get; set; }
        public Nullable<int> assign_to { get; set; }
        public string asset_id_pk { get; set; }
        public Nullable<DateTime> due_date { get; set; }
        public string cc_recipients { get; set; }
        public string description { get; set; }
        public string notification { get; set; }
        public string file { get; set; }
        public Nullable<int> user_id_fk { get; set; }
        public Nullable<int> department_id_fk { get; set; }
        public Nullable<int> priority_id_fk { get; set; }
        public Nullable<int> is_send_email { get; set; }
        public Nullable<int> is_send_message { get; set; }
        public string location_id { get; set; }
        public string user_id { get; set; }
        public string client_id { get; set; }
        public string department_id { get; set; }
        public string priority_id { get; set; }
        public string common_cat_id { get; set; }
        public string sub_category_id { get; set; }
        public Nullable<DateTime> from_date { get; set; }
        public Nullable<DateTime> to_date { get; set; }
        public string asset { get; set; }
        public string supp_dept_id { get; set; }
        public string supp_grp_id { get; set; }
        public Nullable<DateTime> log_time { get; set; }
        public string symptoms { get; set; }
        public Nullable<int> due { get; set; }
        public string workaround { get; set; }
        public string solution { get; set; }
        public Nullable<int> login_id { get; set; }
        public string status_name { get; set; }
        public int updated_by { get; set; }
    }
    public partial class zdesk_m_problems_doc_tbl
    {
        public int problem_a_s_id_pk { get; set; }
        public int problem_id_fk { get; set; }
        public int? file_type { get; set; }
        public string description { get; set; }
        public string file_path { get; set; }
        public string file_name { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public int? is_active { get; set; }
    }
    public partial class zdesk_m_problems_attach_incident_tbl
    {
        public int attach_id_pk { get; set; }
        public int incident_id_fk { get; set; }
        public int problem_id_fk { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public string ticket_id { get; set; }
        public string attach_id { get; set; }
    }
    public partial class zdesk_m_problem_status_tbl
    {
        public int problem_status_id_pk { get; set; }
        public string status { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int updated_by { get; set; }
    }
    public partial class zdesk_m_purchase_status_tbl
    {
        public int purchase_status_id_pk { get; set; }
        public string status { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int updated_by { get; set; }
    }
    public partial class zdesk_m_known_error_db_tbl
    {
        public int kedb_id_pk { get; set; }
        public int problem_id_fk { get; set; }
        public string subject { get; set; }
        public string symptoms { get; set; }
        public string workaround { get; set; }
        public string resolution_notes { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int updated_by { get; set; }
        public int is_active { get; set; }
        public string prefix { get; set; }
        public string kebd_id { get; set; }
    }

    public partial class zdesk_m_problems_status_management_tbl
    {
        public int problems_status_management_id_pk { get; set; }
        public int problems_id_fk { get; set; }
        public int updated_by { get; set; }
        public Nullable<int> technician_id { get; set; }
        public Nullable<int> status { get; set; }
        public string comments { get; set; }
        public string status_name { get; set; }
        public string Technician { get; set; }
        public string updated_by_name { get; set; }
    }
}