using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public partial class clients
    {
        public Nullable<int> id { get; set; }
        public string name { get; set; }
        //public int is_active { get; set; }
    }
    public partial class SupplierDetails
    {
        public Nullable<int> ID { get; set; }
        public string SupplierName { get; set; }
    }
    public partial class zdesk_m_peripherals_tbl
    {
        public Nullable<int> support_type { get; set; }
        public Nullable<int> department_id_fk { get; set; }
        public Nullable<int> peripherals_id_pk { get; set; }
        public Nullable<int> client_id_fk { get; set; }
        public Nullable<int> p_category_id_fk { get; set; }
        public string category_name { get; set; }
        public string location_name { get; set; }
        public string status { get; set; }
        public string assets_tag { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string asset_name { get; set; }
        public Nullable<int> sub_location_id_fk { get; set; }
        public Nullable<int> section_id_fk { get; set; }
        public Nullable<int> floor_id_fk { get; set; }
        public string building_room_no { get; set; }
        public Nullable<int> supplier_id_fk { get; set; }
        public Nullable<int> location_id_fk { get; set; }
        public string business_unit { get; set; }
        public string supplier_name { get; set; }
        public string stored_location_name { get; set; }
        public string user_name { get; set; }
        public Nullable<int> stored_location_id_fk { get; set; }
        public Nullable<int> status_id_fk { get; set; }
        public string serial_number { get; set; }
        public Nullable<int> asset_admin_id { get; set; }
        public Nullable<DateTime> purchase_date { get; set; }
        public Nullable<int> asset_user_id_pk { get; set; }
        public string purchase_order_number { get; set; }
        public Nullable<DateTime> removal_date { get; set; }
        public string purchase_price { get; set; }
        public string condition { get; set; }
        public string email { get; set; }
        public string warranty { get; set; }
        public string notes { get; set; }
        public string invoice_no { get; set; }
        public Nullable<DateTime> invoice_date { get; set; }
        public Nullable<DateTime> warranty_start_date { get; set; }
        public Nullable<DateTime> warranty_end_date { get; set; }
        public Nullable<DateTime> amc_start_date { get; set; }
        public Nullable<DateTime> amc_end_date { get; set; }

    }
    public partial class zdesk_t_peripherals_component_tbl
    {
        public Nullable<int> periph_comp_id_pk { get; set; }
        public Nullable<int> peripherals_id_pk { get; set; }
        public Nullable<int> component_id_fk { get; set; }
        public Nullable<DateTime> warranty_end_date { get; set; }
        public Nullable<int> supplier_id_fk { get; set; }
        public string remarks { get; set; }
        public string component_name { get; set; }
        public string supplier_name { get; set; }
        public string serial_number { get; set; }

    }
}