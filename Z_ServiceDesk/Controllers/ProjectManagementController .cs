using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Z_ServiceDesk.Controllers
{
    public class ProjectManagementController : Controller
    {
        // GET:ProjectManagement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddProject() 
        {
            return View();
        }
        public ActionResult ProjectDetails() 
        {
            return View();
        }
        public ActionResult EditProjectsmanagement()
        {
            return View();
        }
    }
}