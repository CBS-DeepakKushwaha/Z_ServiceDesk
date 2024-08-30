using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class RelationShip
    {
        public zdesk_m_asset_tbl ParentData { get; set; }
        public List<zdesk_m_asset_tbl> ChileData { get; set; }
    }
    public class RelationShipDropDown
    {
        public List<zdesk_m_asset_category_tbl> ParentCategory { get; set; }
        public List<RelationShipType> RelationShip { get; set; }
    }
    public partial class RelationShipType
    {
        public int Id { get; set; }
        public string RelationshipType1 { get; set; }
        public string InverseRelationshipType { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}