using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class DocumentTitle
    {
        public string Value { get; set; }
    }

    public class DocumentType
    {
        public string Value { get; set; }
    }

    public class ContactDetails
    {
        public string Value { get; set; }
    }

    public class IssuingAuthority
    {
        public string Value { get; set; }
    }

    public class DocumentPublisher
    {
        public ContactDetails ContactDetails { get; set; }
        public IssuingAuthority IssuingAuthority { get; set; }
        public int Type { get; set; }
    }

    public class ID
    {
        public string Value { get; set; }
    }

    public class Alias
    {
        public string Value { get; set; }
    }

    public class Identification
    {
        public ID ID { get; set; }
        public Alias Alias { get; set; }
    }

    public class Description
    {
        public string Value { get; set; }
    }

    public class RevisionHistory
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public Description Description { get; set; }
    }

    public class DocumentTracking
    {
        public Identification Identification { get; set; }
        public int Status { get; set; }
        public string Version { get; set; }
        public List<RevisionHistory> RevisionHistory { get; set; }
        public DateTime InitialReleaseDate { get; set; }
        public DateTime CurrentReleaseDate { get; set; }
    }

    public class DocumentNote
    {
        public string Title { get; set; }
        public string Audience { get; set; }
        public int Type { get; set; }
        public string Ordinal { get; set; }
        public string Value { get; set; }
    }

    public class Item
    {
        public string ProductID { get; set; }
        public string Value { get; set; }
        public List<Item2> Items { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
    }

    public class Item2
    {
        public string ProductID { get; set; }
        public string Value { get; set; }
        ////public List<Item> Items { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
    }

    public class Branch
    {
        public List<Item> Items { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
    }

    public class FullProductName
    {
        public string ProductID { get; set; }
        public string Value { get; set; }
    }

    public class ProductTree
    {
        public List<Branch> Branch { get; set; }
        public List<FullProductName> FullProductName { get; set; }
    }

    public class Title
    {
        public string Value { get; set; }
    }

    public class Note
    {
        public string Title { get; set; }
        public int Type { get; set; }
        public string Ordinal { get; set; }
        public string Value { get; set; }
    }

    public class ProductStatus
    {
        public List<string> ProductID { get; set; }
        public int Type { get; set; }
    }

    public class Threat
    {
        public Description Description { get; set; }
        public List<string> ProductID { get; set; }
        public int Type { get; set; }
        public bool DateSpecified { get; set; }
    }

    public class CVSSScoreSet
    {
        public double BaseScore { get; set; }
        public double TemporalScore { get; set; }
        public string Vector { get; set; }
        public List<string> ProductID { get; set; }
    }

    public class RestartRequired
    {
        public string Value { get; set; }
    }

    public class Remediation
    {
        public Description Description { get; set; }
        public string URL { get; set; }
        public string Supercedence { get; set; }
        public List<string> ProductID { get; set; }
        public int Type { get; set; }
        public bool DateSpecified { get; set; }
        public List<object> AffectedFiles { get; set; }
        public RestartRequired RestartRequired { get; set; }
        public string SubType { get; set; }
        public string FixedBuild { get; set; }
    }

    public class Name
    {
        public string Value { get; set; }
    }

    public class Acknowledgment
    {
        public List<Name> Name { get; set; }
        public List<string> URL { get; set; }
    }

    public class Vulnerability
    {
        public Title Title { get; set; }
        public List<Note> Notes { get; set; }
        public bool DiscoveryDateSpecified { get; set; }
        public bool ReleaseDateSpecified { get; set; }
        public string CVE { get; set; }
        public List<ProductStatus> ProductStatuses { get; set; }
        public List<Threat> Threats { get; set; }
        public List<CVSSScoreSet> CVSSScoreSets { get; set; }
        public List<Remediation> Remediations { get; set; }
        public List<Acknowledgment> Acknowledgments { get; set; }
        public string Ordinal { get; set; }
        public List<RevisionHistory> RevisionHistory { get; set; }
    }

    public class Root
    {
        public DocumentTitle DocumentTitle { get; set; }
        public DocumentType DocumentType { get; set; }
        public DocumentPublisher DocumentPublisher { get; set; }
        public DocumentTracking DocumentTracking { get; set; }
        public List<DocumentNote> DocumentNotes { get; set; }
        public ProductTree ProductTree { get; set; }
        public List<Vulnerability> Vulnerability { get; set; }
    }
    public class zdesk_m_agent_rescan_system_tbl
    {
        public int id { get; set; }
        public string hostname { get; set; }
        public string serialnumber { get; set; }
        public string macaddress { get; set; }
        public string ipaddress { get; set; }
        public int status { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public string system_id { get; set; }
    }
    public class zdesk_m_cab_file_tbl
    {
        public int id { get; set; }
        public string serial_no { get; set; }
        public string mac_address { get; set; }
        public string ip_address { get; set; }
        public int status { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public int is_active{get;set;}

    }

    public class zdesk_m_cab_details_tbl
    {
        public Nullable<int> cab_details_id_pk { get; set; }
        public string serial_no { get; set; }
        public string description { get; set; }
        public string download_from { get; set; }
        public string destination_url { get; set; }
        public int download_type { get; set; }
        public Nullable<int> update_frequency { get; set; }
        public string source_url { get; set; }
        public string UpdateFrequencyTime { get; set; }
        public string UpdateFrequencyWeekName { get; set; }
        public string UpdateFrequencyDate { get; set; }
    }

    public class zdesk_m_patch_configuration_tbl
    {
        public Nullable<int> patch_configuration_id_pk { get; set; }
        public string KBID { get; set; }
        public string Title { get; set; }
        public string download_link { get; set; }
        public Nullable<int> classification { get; set; }
        public Nullable<int> restart_required { get; set; }
        public string products { get; set; }
        public string size { get; set; }
        public string restart_required_name { get; set; }
        public string classification_name { get; set; }
    }
}