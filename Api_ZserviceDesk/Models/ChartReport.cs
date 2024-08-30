using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class ChartReport
    {
    }
    public class tickets
    {
        public Nullable<int> id { get; set; }
        public Nullable<int> ticket1 { get; set; }
        public string status { get; set; }
    }
    public class EngineerRequest
    {
        public string name { get; set; }
        public Nullable<int> TotalTickets { get; set; }
        public Nullable<int> Total { get; set; }
    }
    public class Daterange
    {
        public Nullable<DateTime> fromdate { get; set; }
        public Nullable<DateTime> enddate { get; set; }
    }
    public class IncidentPause
    {
        public Nullable<int> Total { get; set; }
        public string Category { get; set; }
    }
    public class Incident
    {
        public string Ticket_Status { get; set; }
        public Nullable<int> Id { get; set; }
        public Nullable<int> Total { get; set; }
    }
    public class IncidentSla
    {
        public string response_sla { get; set; }
        public Nullable<int> Id { get; set; }
        public Nullable<int> Total { get; set; }
        public string SLAKEY { get; set; }
        public string color { get; set; }
    }
    public partial class ServiceRequest
    {
        public string Status { get; set; }
        public Nullable<int> Id { get; set; }
        public Nullable<int> Total { get; set; }
    }
    public partial class Assesst
    {
        public Nullable<int> InStore { get; set; }
        public Nullable<int> Discard { get; set; }
        public Nullable<int> Theft { get; set; }
        public Nullable<int> Allocated { get; set; }
        public Nullable<int> InRepair { get; set; }
        public Nullable<int> InActive { get; set; }
        public string Categoty { get; set; }
        public string LocationName { get; set; }
    }
    public partial class Assesst_Pie
    {
        public Nullable<int> Warranty { get; set; }
        public Nullable<int> Amc { get; set; }
        public Nullable<int> OutSupport { get; set; }
    }
    public partial class Assesst_Bar
    {
        public Nullable<int> warrenty { get; set; }
        public Nullable<int> Amc { get; set; }
        public Nullable<int> OutSupport { get; set; }
        public string Asset_cat_name { get; set; }
    }
    public class Incidents_Priority
    {

        public Nullable<int> Total { get; set; }
        public string Priority_name { get; set; }
        public string Category_Name { get; set; }
        public string City { get; set; }
    }
    public class ChangeManagement_ChangeType
    {

        public Nullable<int> Total { get; set; }
        public string ChangeName { get; set; }
    }
    public partial class ChangeManagement_Category
    {
        public Nullable<int> Assigned { get; set; }
        public Nullable<int> InProgress { get; set; }
        public Nullable<int> New { get; set; }
        public Nullable<int> Pending { get; set; }
        public Nullable<int> Reopened { get; set; }
        public Nullable<int> Resolved { get; set; }
        public string category_Name { get; set; }
    }
    public partial class TaskMangement_TaskType
    {
        public Nullable<int> Total { get; set; }
        public string TaskName { get; set; }
    }
    public partial class IncidentSupport
    {
        public Nullable<int> Assigned { get; set; }
        public Nullable<int> InProgress { get; set; }
        public Nullable<int> New { get; set; }
        public Nullable<int> Pending { get; set; }
        public Nullable<int> Reopened { get; set; }
        public Nullable<int> Resolved { get; set; }
        public string Support_departmentName { get; set; }
    }
    public partial class SRSupportLocation
    {
        public Nullable<int> Assigned { get; set; }
        public Nullable<int> InProgress { get; set; }
        public Nullable<int> New { get; set; }
        public Nullable<int> Pending { get; set; }
        public Nullable<int> Reopened { get; set; }
        public Nullable<int> Resolved { get; set; }
        public string Support_departmentName { get; set; }
        public string LocationName { get; set; }
        public string Category_name { get; set; }
    }
    public partial class ADUsers
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Jobtitle { get; set; }
        public string Department { get; set; }
        public string Manager { get; set; }
        public string DisplayName { get; set; }

    }
    public partial class MailServerDetails
    {
        public string server_name { get; set; }
        public string user_name { get; set; }
        public string Password { get; set; }
    }
    public partial class ADServerDetails
    {
        public int clientid_pk { get; set; }
        public string server_id { get; set; }
        public string domain { get; set; }
        public string organizationunit { get; set; }
        public string user_name { get; set; }
        public string Password { get; set; }

    }
    public class Charts
    {
        public string NAME { get; set; }
        public string VALUE { get; set; }
        public string color { get; set; }
        public int? OFF { get; set; }
        public int? ON { get; set; }
        public int? Seq { get; set; }
    }

    public class Charts_Params
    {
        public string name { get; set; }
        public string Section { get; set; }
        public string serialnumber { get; set; }
        public string Param1 { get; set; }
        public Nullable<int> sel_val { get; set; }
        public Nullable<DateTime> from { get; set; }
        public Nullable<DateTime> to { get; set; }
    }
}