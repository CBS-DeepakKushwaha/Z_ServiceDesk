using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Z_ServiceDesk.Controllers
{
    public class BudgetManagementController : Controller
    {
        // GET: BudgetManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddBudget()
        {
            return View();
        }
        public ActionResult EditBudget()
        {
            return View();
        }
    }
}