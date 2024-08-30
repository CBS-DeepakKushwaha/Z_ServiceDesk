using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class PageMaster
    {
        public int page_master_id_pk { get; set; }
        public string PageDesc { get; set; }
        public string PathURL { get; set; }
    }

    public class zdesk_m_user_role_tbl
    {
        public int user_role_id_pk { get; set; }
        public int role_type { get; set; }
        public string role_name { get; set; }
        public string role_type_name { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public string updated_by { get; set; }
    }

    public class zdesk_m_user_role_details_tbl
    {
        public int user_role_details_id_pk { get; set; }
        public int user_role_id_fk { get; set; }
        public int page_master_id_fk { get; set; }
        public string Screen_Name { get; set; }
        public Nullable<bool> Add { get; set; }
        public Nullable<bool> Edit { get; set; }
        public Nullable<bool> Delete { get; set; }
        public Nullable<bool> View { get; set; }
    }

    public class zdesk_m_user_role_details_matrix_tbl
    {
        public int user_role_details_id_pk { get; set; }
        public int user_role_id_fk { get; set; }
        public int page_master_id_fk { get; set; }
        public string Screen_Name { get; set; }
        public Nullable<bool> Add { get; set; }
        public Nullable<bool> Edit { get; set; }
        public Nullable<bool> Delete { get; set; }
        public Nullable<bool> View { get; set; }
        public Nullable<bool> IsEnabledForEdit { get; set; }

        public string View_Name { get; set; }
        public string Add_Name { get; set; }
        public string Edit_Name { get; set; }
        public string Delete_Name { get; set; }
        public string IsEnabledForEdit_Name { get; set; }
    }

    public class Get_UserRoleOfUser_Result
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> Role_id { get; set; }
        public Nullable<int> PageID { get; set; }
        public string PartURL { get; set; }
        public Nullable<bool> Add { get; set; }
        public Nullable<bool> Edit { get; set; }
        public Nullable<bool> Delete { get; set; }
        public Nullable<bool> View { get; set; }
        public string pageNames { get; set; }
        public Nullable<bool> IsEnabledForEdit { get; set; }
    }

    public class zdesk_m_page_controls_permissions_tbl
    {
        public Nullable<int> page_controls_permissions_id_pk { get; set; }
        public Nullable<int> user_role_id_fk { get; set; }
        public string PathURL { get; set; }
        public string ControlID { get; set; }
        public string ControlName { get; set; }
        public string PageName { get; set; }
        public Nullable<int> ParentID { get; set; }
        public int IsVisible { get; set; }

        public string Visibility { get; set; }
        public string VisibilityName { get; set; }
        public string RoleName { get; set; }
        public string Section { get; set; }
    }
}