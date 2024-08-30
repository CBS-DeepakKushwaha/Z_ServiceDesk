using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class AssetCategory
    {
    }
    public partial class zdesk_m_asset_category_tbl
    {
        public Nullable<int> asset_category_id_pk { get; set; }
        public int mapping_required { get; set; }   
        public string asset_cat_name { get; set; }
        public int is_active { get; set; }
    }
    public partial class zdesk_m_getpass_address_tbl
    {
        public Nullable<int> get_pass_add_id_pk { get; set; }
        public string address { get; set; }
        public int is_active { get; set; }
    }
    public partial class zdesk_m_gate_pass_tbl
    {
        public Nullable<int> gate_pass_id_pk { get; set; }
        public string logo { get; set; }
        public Nullable<int> id  { get; set; } 
        public Nullable<int> asset_id_pk { get; set; }
        public Nullable<int> gate_pass_status { get; set; }
        public Nullable<int> gate_pass_status1 { get; set; }
        public Nullable<int> gate_pass_status2 { get; set; } 
        public Nullable<int> close_status { get; set; }
        public string gate_pass_number { get; set; }
        public string file_upload { get; set; }
        public string serial_number { get; set; }
        public string moment_type { get; set; }
        public string asset_cat_name { get; set; }
        public string model_name { get; set; }
        public string Approval_status { get; set; } 
        public string to_address { get; set; }
        public string address { get; set; }
        public string DataItem { get; set; }
        public string name { get; set; }
        public Nullable<int> is_approval_req { get; set; }
        public string approver_id { get; set; }
        public string approver_id1 { get; set; }
        public string approver_id2 { get; set; }
        public string approver_name { get; set; }
        public string approver_name1 { get; set; }
        public string approver_name2 { get; set; }
        public string business_unit { get; set; }
        public string asset_name { get; set; }
        public string status { get; set; }
        public string prefix { get; set; }
        public string gate_pass_type { get; set; }
        public Nullable<DateTime> expected_date { get; set; }
        public Nullable<int> business_unit_id_fk { get; set; }
        public Nullable<int> get_pass_add_id_fk { get; set; }
        public string asset_id_fk { get; set; }
        public Nullable<int> change_asset_status { get; set; }
        public Nullable<int> asset_status_id_fk { get; set; }
        public string reason_for_gate_pass { get; set; }
        public Nullable<DateTime> gate_pass_validity { get; set; }
        public int is_active { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string serial_no { get; set; }
        public string description { get; set; }
        public Nullable<int> asset_type { get; set; }
        public string remarks { get; set; }
        public string receiver_name { get; set; }
        public string receiver_number { get; set; }
        public string user_name { get; set; }
        public int is_recieved { get; set; }
        public Nullable<DateTime> recieved_date { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> actual_ret_date { get; set; }
        public string recieved_from { get; set; }
        public string recieved_from_cont { get; set; }
        public string return_remarks { get; set; }
        public string reason { get; set; }
        public string other_asset_name { get; set; }
        public string other_details { get; set; }
        public int other_qty { get; set; }
        public string asset_id { get; set; }
        public string ApproverLevel { get; set; }
        public Nullable<int> Created_By { get; set; }
        public string Created_By_Email { get; set; }
        public string Created_By_Name { get; set; }
        public string recieved_date_name { get; set; }
        public string asset_component_id { get; set; }
        public string consumable_id { get; set; }
        public string approver_comments { get; set; }
        public string approver_comments1 { get; set; }
        public string approver_comments2 { get; set; }
    }

    public partial class zdesk_m_gate_pass_asset_components_tbl
    {
        public Nullable<int> gate_pass_asset_components_id_pk { get; set; }
        public Nullable<int> gate_pass_id_fk { get; set; }
        public string ticket_number { get; set; }
        public string asset_type { get; set; }
        public string part_no { get; set; }
        public string serial_no { get; set; }
        public Nullable<int> Qty { get; set; }
        public string remarks { get; set; }
        public string asset_tag { get; set; }
        public string component_name { get; set; }
        public string parent_serial_number { get; set; }
    }

    public partial class zdesk_m_gate_pass_consumables_tbl
    {
        public Nullable<int> gate_pass_consumables_id_pk { get; set; }
        public Nullable<int> gate_pass_id_fk { get; set; }
        public Nullable<int> item_id_fk { get; set; }
        public Nullable<int> Qty { get; set; }
        public string category { get; set; }
        public string Item_name { get; set; }
        public string Item_details { get; set; }
        public string serial_no { get; set; }
    }
    public partial class  zdesk_m_imac_software_tbl
    {
        public int imac_soft_id_pk { get; set; }
        public string soft_name { get; set; } 
    }
    public partial class zdesk_m_imac_tbl 
    {
        public Nullable<int> imac_id_pk { get; set; } 
        public Nullable<int> asset_id_fk { get; set; } 
        public string imac_no { get; set; }
        public string category { get; set; } 
        public string asset_type { get; set; }
        public Nullable<int> user_id_fk { get; set; }
        public string add_soft_req { get; set; } 
        public string other_specify { get; set; } 
        public string data_transfer { get; set; } 
        public string remarks { get; set; }
        public string title { get; set; } 
        public string room_no { get; set; }
        public string department_name { get; set; }
        public string ext_no { get; set; }
        public string location_name { get; set; }
        public string sub_location { get; set; }
        public string floor_name { get; set; }
        public string email { get; set; }
        public string user_name { get; set; }
        public string soft_name { get; set; } 
        public string soft_id_fk { get; set; }  
        public string cc_name { get; set; }   
        public Nullable<DateTime> created_date { get; set; } 
    }

    public partial class zdesk_other_items_imac_tbl
    {
        public Nullable<int> other_item_id_pk { get; set; }
        public Nullable<int> imac_id_fk { get; set; } 
        public string other_Item { get; set; }
        public string description { get; set; }
        public Nullable<DateTime> created_date { get; set; }
    }
    public partial class zdesk_t_imac_asset_details_tbl
    {
        public Nullable<int> imac_id_fk { get; set; }
        public Nullable<int> imac_tran_id_pk { get; set; }
        public Nullable<int> asset_id_fk { get; set; }
        public string asset_cat { get; set; }
        public string serial_no { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string remarks { get; set; }
       
        

    }
}