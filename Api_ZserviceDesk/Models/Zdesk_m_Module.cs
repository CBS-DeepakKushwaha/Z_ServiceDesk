using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public partial class Zdesk_m_Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
    public partial class Zdesk_m_Module_Page
    {
        public int Page_Id { get; set; }
        public Nullable<int> Module_Id { get; set; }
        public string Name { get; set; }
        public string PageName { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
    public partial class Zdesk_m_Module_Page_Fields
    {
        public int Fileds_Id { get; set; }
        public Nullable<int> Module_Id { get; set; }
        public Nullable<int> PageId { get; set; }
        public string Name { get; set; }
        public string PageName { get; set; }
        public string ModuleName { get; set; }
        public string FieldName { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsHidden { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
    public class ModelEntityFiled
    {
        public int Fileds_Id { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsHidden { get; set; }
        public string Name { get; set; }
    }
}