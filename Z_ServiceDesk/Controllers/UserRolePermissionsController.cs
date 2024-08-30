using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Z_ServiceDesk.Controllers
{
    public class UserRolePermissionsController : Controller
    { 
        public ActionResult SetRolePermissions()
        {
            return View();
        }

        public ActionResult UserRoles()
        {
            return View();
        }

        public ActionResult SetPagePermissions()
        {
            return View();
        }
    }
}