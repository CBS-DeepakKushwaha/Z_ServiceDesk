using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class AssetListTVP
    {
        public List<AssetList> AssetTVP { get; set; }
    }

    public class AssetList
    {
        public string BusinessUnit { get; set; }
        public string AssetTag { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string SerialNo { get; set; }
        public string Location { get; set; }
        public string Sublocation { get; set; }
        public string Department { get; set; }
        public string Vendor { get; set; }
        public string SupportType { get; set; }
        public string Condition { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string AssetCost { get; set; }
        public string User { get; set; }
        public string CostCenter { get; set; }
        public string Floor { get; set; }
        public string RoomNo { get; set; }
        public string WarrantyStartdate { get; set; }
        public string WarrantyEnddate { get; set; }
        public string Created_By { get; set; }
        public string OS { get; set; }
        public string PONo { get; set; }
        public string PODate { get; set; }
        public string WarrantyType { get; set; }
        public string ExpressServiceCode { get; set; }
    }

    public class UserListTVP
    {
        public List<UserList> UserTVP { get; set; }
    }

    public class UserList
    {
        public string Company { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string EmpCode { get; set; }
        public string CostCentre { get; set; }
        public string ReportingManager { get; set; }
        public string ReportingManagerEmail { get; set; }
        public string Location { get; set; }
        public string SubLocation { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public string Department { get; set; }
        public string SubDepartment { get; set; }
        public string IsVip { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
    }
}