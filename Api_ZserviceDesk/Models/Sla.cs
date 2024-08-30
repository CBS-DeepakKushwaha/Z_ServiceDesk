using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class Sla
    {
    }
    public partial class zdesk_m_sla_name_tbl
    {
        public Nullable<int> sla_id_pk { get; set; }
        public string sla_name { get; set; }
        public string status { get; set; }
        public string hol_cal_location_name { get; set; }
        public Nullable<int> hol_cal_location_id_fk { get; set; }
        public Nullable<int> time_zone_id_fk { get; set; }
        public Nullable<int> is_default { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<int> is_service_window { get; set; }
        public Nullable<int> sla_id_fk { get; set; }
        public Nullable<int> is_select { get; set; }
        public string day { get; set; }
        public string from_time { get; set; }
        public string to_time { get; set; }
    }
    public partial class zdesk_m_sla_shedule_tbl
    {
        public Nullable<int> shedule_id_pk { get; set; }
        public Nullable<int> sla_id_fk { get; set; }
        public Nullable<int> is_select { get; set; }
        public string day { get; set; }
        public string from_time { get; set; }
        public string to_time { get; set; }
        public int IsActive { get; set; }
    }
    public partial class zdesk_m_holiday_cal_location_tbl
    {

        public Nullable<int> holiday_id_pk { get; set; }
        public Nullable<int> hol_cal_loc_id_pk { get; set; }
        public string hol_cal_location_name { get; set; }
        public Nullable<DateTime> holiday_date { get; set; }
        public string remarks { get; set; }
    }
    public partial class zdesk_m_holiday_calender_tbl
    {
        public Nullable<DateTime> holiday_date { get; set; }
        public Nullable<int> hol_cal_loc_id_fk { get; set; }
        public string remarks { get; set; }
    }
    public partial class zdesk_m_sla_mapping_tbl
    {
        public Nullable<int> sla_mapping_id_pk { get; set; }
        public Nullable<int> support_dep_id_fk { get; set; }
        public Nullable<int> sla_id_fk { get; set; }
        public string support_dep_name { get; set; }
        public string sla_name { get; set; }
    }
    public partial class zdesk_m_support_department_tbl
    {
        public Nullable<int> support_dep_id_pk { get; set; }
        public Nullable<int> support_dep_head { get; set; }
        public string support_dep_name { get; set; }
    }
    public partial class zdesk_m_priority_matrix_tbl
    {
        public Nullable<int> priority_matrix_id_pk { get; set; }
        public Nullable<decimal> penality_amount { get; set; }
        public string priority_name { get; set; }
        public Nullable<int> priority_id_fk { get; set; }
        public string display_name { get; set; }
        public string color { get; set; }
        public string description { get; set; }
        public string response_sla { get; set; }
        public string resolution_sla { get; set; }
        public Nullable<int> is_default { get; set; }
        public Nullable<int> is_active { get; set; }
    }
    public partial class zdesk_m_priority_tbl
    {
        public Nullable<int> mapping_priority_id_pk { get; set; }
        public Nullable<int> impact_id_fk { get; set; }
        public Nullable<int> priority_id_pk { get; set; }
        public string priority_name { get; set; }
    }
    public partial class zdesk_m_penality_tbl
    {
        public Nullable<int> serial_number { get; set; }
        public Nullable<int> ticket_id_pk { get; set; }
        public Nullable<int> service_req_id_pk { get; set; }
        public int time { get; set; }
        public string prefix { get; set; }
        public string resolution_sla { get; set; }
        public string resolutions_sla { get; set; }
        public string total_sla_minute { get; set; }
        public string extra_minute { get; set; }
        public string non_negative { get; set; }
        public string serverty { get; set; }
        public string penality_per_hour { get; set; }
        public string total_penality { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public Nullable<DateTime> created_date { get; set; }
    }
    public partial class zdesk_m_urgency_tbl
    {

        public Nullable<int> urgency_id_pk { get; set; }
        public string urgency_name { get; set; }
    }
    public partial class zdesk_m_impact_tbl
    {
        public Nullable<int> mapping_priority_id_pk { get; set; }
        public Nullable<int> impact_id_pk { get; set; }
        public Nullable<int> impact_id_fk { get; set; }
        public string impact_name { get; set; }
        public Nullable<int> urgency_id_fk { get; set; }
    }
    public partial class zdesk_m_priority_matrix_mapping_tbl
    {
        public Nullable<int> mapping_priority_id_pk { get; set; }
        public Nullable<int> urgency_id_fk { get; set; }
        public Nullable<int> priority_id_fk { get; set; }
        public Nullable<int> impact_id_fk { get; set; }
        public Nullable<int> is_active { get; set; }
        public Nullable<int> is_delete { get; set; }
        public string impact_name { get; set; }
        public string urgency_name { get; set; }
        public string priority_name { get; set; }
        public string Active_Status { get; set; }
    }
    public class ReportSchedulerModel
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public int schedulerTypeId { get; set; }
        public TimeSpan Time { get; set; }
        public string EmailTo { get; set; }
        public string EmailCC { get; set; }
        public string Subject { get; set; }
    }
    
    public class zdesk_m_sub_department_tbl
    {
        public int sub_dept_id_pk { get; set; }
        public int dept_id_fk { get; set; }
        public string dept_name { get; set; }
        public string sub_dept_name { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int updated_by { get; set; }
    }

    public class zdesk_m_cost_centre_tbl
    {
        public int cc_id_pk { get; set; }
        public string cc_name { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int updated_by { get; set; }
    }
    public class zdesk_m_grade_tbl
    {
        public int grade_id_pk { get; set; }
        public string grade_name { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int updated_by { get; set; }
    }
}