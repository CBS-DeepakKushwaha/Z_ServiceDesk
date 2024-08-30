using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class ReportFilter
    {
        public string from { get; set; }
        public string end { get; set; }
        public ReportType ReportTypes { get; set; }
        public FixedReportType FixReportTypes { get; set; }
        public int SelectedValue { get; set; }
        public string UserId { get; set; }
    }
    public enum ReportTypeDefine
    {
        Incident = 1,
        ServcieRequest = 2,
        Assets = 3,
        WorkloadNotification = 4,
        Problem = 5,
        Change = 6,
        Task = 7,
        preventive = 8,
        Depreciation = 9,
        Analytics = 10,
    }
    public enum ReportTypeName
    {
        IncidentReport = 1,
        ServcieRequestReport = 2,
        AssetsReport = 3,
        WorkloadNotificationReport = 4,
        ProblemReport = 5,
        ChangeReport = 6,
        TaskReport = 7,
        PreventiveReport = 8,
        DepreciationReport = 9,
        Analytics = 10,
    }

    public enum ReportType
    {
        GetIncident = 1,
        IncidentbyPrority = 2,
        IncidentbySupport = 3,
        IncidentbyLocation = 4,
        IncidentbyCategory = 5,
        Incidance_Sla = 6,
        ServiceRequest = 7,
        Service_Request_Active = 8,
        Service_Request_By_Support = 9,
        Service_Request_ByLocation = 10,
        Service_Request_Category = 11,
        Incident_Request_Pause = 12,
        assest_amc_status = 13,
        assest_by_Location = 14,
        assets_category_status = 15,
        Assets_AMCCategory = 16,
        Assets_assets_under = 17,
        Incident_Enginner = 18
    }
    public enum FixedReportType
    {
        Incident = 1,
        AssesetUnderWarranty = 2,
        AssesetOutWarranty = 3,
        ComponentsUnderRepair = 4,
        IncidentbyCategory = 5,
        AssetEndWaranty = 6,
        PeripheralsEndWaranty = 7,
        SoftwareEndWaranty = 8,
        ServiceReport = 9

    }
    public partial class zdesk_m_email_audit_tbl
    {
        public int email_status_id_pk { get; set; }
        public string email_to { get; set; }
        public string subject { get; set; }
        public int status { get; set; }
        public string email_status { get; set; }
        public string error_message { get; set; }
        public string exception_message { get; set; }
        public string exception_type { get; set; }
        public string stack_trace { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }

    }
}