using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class Budget
    {
    }

    public class Zdesk_m_Budget_tbl
    {
        public int budget_id_pk { get; set; }
        public string budget_type { get; set; }
        public string category { get; set; }
        public string Subcategory { get; set; }
        public string budgetOwner { get; set; }
        public Nullable<DateTime> dead_line { get; set; }
        public string Description { get; set; }
        public string createBy { get; set; }
        public Nullable<DateTime> createdDate { get; set; }
        public string updatedBy { get; set; }
        public Nullable<DateTime> updatedDate { get; set; }
        public int approved_budget { get; set; }
        public string approved_budget_filter { get; set; }

        public string Email { get; set; }
        public bool isActive { get; set; } = true;
        public string budget_category { get; set; }
        public string budget_Subcategory { get; set; }
        public string budgettype { get; set; }



    }

    public partial class Zdesk_m_budget_category_tbl
    {
        public int b_category_pk { get; set; }
        public string budget_category { get; set; }
    }

    public partial class Zdesk_m_budget_Subcategory_tbl
    {
        public int b_Subcategory_pk { get; set; }
        public string budget_Subcategory { get; set; }

        public int b_category_pk { get; set; }



    }
    public partial class Zdesk_m_budgettype_tbl
    {
        public int budgettype_id_pk { get; set; }
        public string budgettype { get; set; }
    }
    public partial class Zdesk_m_budget_onwer_tbl
    {
        public int Onwer_id_pk { get; set; }
        public string Onwer_name { get; set; }
    }



    public class Zdesk_m_Budget_tbl_show
    {
        public int budget_id_pk { get; set; }
        public string budgettype { get; set; }
        public string budget_category { get; set; }
        public string budget_Subcategory { get; set; }
        public string Onwer_name { get; set; }
        public DateTime dead_line { get; set; }
        public string Description { get; set; }
        public int approved_budget { get; set; }
    }

    public class BudgetDeleteStatus
    {
        public int ID { get; set; }
        public string BUDGETSTATUS { get; set; }
    }
    public class BudgetFilterDetail_tbl
    {
        public int budget_id_pk { get; set; }
        public string budgettype { get; set; }
        public string budget_category { get; set; }
        public string budget_Subcategory { get; }
        public Nullable<DateTime> dead_line { get; }
        public string approved_budget { get; set; }
        public string Onwer_name { get; set; }

        public string Description { get; set; }

    }

    public class zdesk_m_Budget_details_tbl_Edit
    {
        public int budget_id_pk { get; set; }
        public string budget_type { get; set; }
        public string category { get; set; }
        public string Subcategory { get; set; }
        public string budgetOwner { get; set; }
        public Nullable<DateTime> dead_line { get; set; }
        public string Description { get; set; }
        public int approved_budget { get; set; }
        public string Email { get; set; }


    }

   
}