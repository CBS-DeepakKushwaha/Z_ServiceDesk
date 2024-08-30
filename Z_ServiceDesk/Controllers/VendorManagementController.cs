using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Z_ServiceDesk.Controllers
{
    public class VendorManagementController : Controller
    {
        // GET: VendorManagement
        public ActionResult Index()
        {
            return View();
        }
       // [HttpPost]
        public ActionResult AddVendor() 
        {
            return View();
        }
        public ActionResult VendorDetails() 
        {
            return View();
        }
        public ActionResult EditVendorsmanagement()
        {
            return View();
        }
    }
}