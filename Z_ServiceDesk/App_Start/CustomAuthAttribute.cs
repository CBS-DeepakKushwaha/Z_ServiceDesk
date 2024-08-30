using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Routing;

namespace Z_ServiceDesk.App_Start
{
    public class CustomAuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int? Id = SessionHelper.Id; 
            //string empcode1 = HttpContext.Current.Session["Emp_Code"].ToString();

            if (HttpContext.Current.Session["EmployeeInfo"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Index", controller = "Login" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}