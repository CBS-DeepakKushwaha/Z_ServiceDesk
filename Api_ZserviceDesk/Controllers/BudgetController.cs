using Api_ZserviceDesk.Models;
using Newtonsoft.Json;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api_ZserviceDesk.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]


    public class BudgetController : ApiController
    {
       // private readonly EmailService _emailService = new EmailService(); // Initialize email service

        [HttpGet]
        public IEnumerable<Zdesk_m_budget_category_tbl> GetBudgetCategoryLists()
        {
            var db = new Database("Constr")
            {
                EnableAutoSelect = false
            };
            return db.Query<Zdesk_m_budget_category_tbl>("select * from Zdesk_m_budget_category_tbl");
        }

        [HttpGet]
        public IEnumerable<Zdesk_m_budget_Subcategory_tbl> GetBudgetSubCategoryLists(int id)
        {
            var db = new Database("Constr")
            {
                EnableAutoSelect = false
            };
            return db.Query<Zdesk_m_budget_Subcategory_tbl>($"select * from Zdesk_m_budget_Subcategory_tbl where category_id_fk = {id}");
        }


        [HttpGet]
        public IEnumerable<Zdesk_m_budgettype_tbl> GetBudgetTypeLists()
        {
            var db = new Database("Constr")
            {
                EnableAutoSelect = false
            };
            return db.Query<Zdesk_m_budgettype_tbl>("select * from Zdesk_m_budgettype_tbl");
        }

        [HttpGet]
        public IEnumerable<Zdesk_m_budget_onwer_tbl> GetBudgetOwner()
        {
            var db = new Database("Constr")
            {
                EnableAutoSelect = false
            };
            return db.Query<Zdesk_m_budget_onwer_tbl>("select * from Zdesk_m_budget_onwer_tbl");
        }



       

        //public bool InsertBudgetList(Zdesk_m_Budget_tbl data)
        //{
        //    return true;
        //}
        //[HttpPost]
        public Zdesk_m_Budget_tbl InsertBudgetList(Zdesk_m_Budget_tbl c)
        {
            try
            {
                c.isActive = true;
                c.updatedDate = null;
                c.updatedBy = string.Empty;
                c.createdDate = DateTime.Now;
                c.createBy = User.Identity.Name;
                var db = new Database("Constr")
                {
                    EnableAutoSelect = false
                };
                return db.SingleOrDefault<Zdesk_m_Budget_tbl>("Exec sp_Insert_budget_details @budget_type,@category,@Subcategory, @budgetOwner, @dead_line, @Description, @createBy,@createdDate, @updatedBy,@updatedDate,@approved_budget,@isActive ",

                 new
                 {
                     c.budget_type,
                     c.category,
                     c.Subcategory,
                     c.budgetOwner,
                     c.dead_line,
                     c.Description,
                     c.createBy,
                     c.createdDate,
                     c.updatedBy,
                     c.updatedDate,
                     c.approved_budget,
                     c.isActive
                 });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        public IEnumerable<Zdesk_m_Budget_tbl> GetBudgetDetails()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<Zdesk_m_Budget_tbl>("exec sp_getbudget_list");
        }

        [HttpPost]
        public IEnumerable<Zdesk_m_Budget_tbl> GetFilteredBudgetDetails(Zdesk_m_Budget_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;

            var result = db.Query<Zdesk_m_Budget_tbl>("exec sp_getbudget_list_filter @budget_category, @budget_Subcategory, @budgettype, @dead_line, @approved_budget_filter",
                new { t.budget_category, t.budget_Subcategory, t.budgettype, t.dead_line, t.approved_budget_filter });
            return db.Query<Zdesk_m_Budget_tbl>("exec sp_getbudget_list_filter @budget_category, @budget_Subcategory, @budgettype, @dead_line, @approved_budget_filter",
                new { t.budget_category, t.budget_Subcategory, t.budgettype, t.dead_line, t.approved_budget_filter });
        }



        [HttpGet]

        public IEnumerable<Zdesk_m_Budget_tbl> GetDeadlineBudgetFilter()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<Zdesk_m_Budget_tbl>("SELECT budget_id_pk,dead_line FROM Zdesk_m_Budget_tbl");
        }

        [HttpGet]
        public IEnumerable<Zdesk_m_Budget_tbl> GetAppBudgetFilter()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<Zdesk_m_Budget_tbl>("SELECT budget_id_pk, approved_budget FROM Zdesk_m_Budget_tbl");
        }





        [HttpPost]
        public BudgetDeleteStatus DeleteBudgetById(Zdesk_m_Budget_tbl s)
        {
            try
            {
                var db = new Database("Constr");
                db.EnableAutoSelect = false;
                return db.SingleOrDefault<BudgetDeleteStatus>("Exec DeleteBudgetByID @budget_id_pk", new { s.budget_id_pk });
            }
            catch (Exception ex)
            { throw ex; }
        }

        [HttpPost]
        public Zdesk_m_Budget_tbl_show GetBudgetrDetailsEdit(Zdesk_m_Budget_tbl_show c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<Zdesk_m_Budget_tbl_show>("Exec zdesk_get_Budget_detail_Edit_sp @budget_id_pk", new { c.budget_id_pk });
        }
    }
}


