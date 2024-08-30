using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Configuration;
using Api_ZserviceDesk.Models;
using System.Text;
using Newtonsoft.Json;
//using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Z_ServiceDesk.Controllers
{
    public class AdminController : Controller
    {
        static string WebsiteUrl = ConfigurationManager.AppSettings["Web_Url"];
        static string WebAPIUrl = ConfigurationManager.AppSettings["Base_Url"];

        //[OutputCache(Duration = 30)]
        public PartialViewResult Menu()
        {
            //////IEnumerable<zdesk_m_page_master_tbl> menus = (new AAMROHRMS.RepositoryEntity.AdminQuery()).GetMenu(appid: 3, userName: Session["EmployeeID"].ToString());
            //////Session["MenuControl"] = menus;
            string emp_email = ""; string emp_password = "";
            int? role_id = 0;

            if (Session["EmployeeInfo"] != null)
            {
                zdesk_employee objData = (zdesk_employee)Session["EmployeeInfo"];
                role_id = objData.roleid;
            }

            var input2 = new
            {
                roleid = role_id
            };

            ////var input2 = new
            ////{
            ////    email = emp_email,
            ////    password = emp_password,
            ////};

            string inputJson2 = (new JavaScriptSerializer()).Serialize(input2);

            WebClient client2 = new WebClient();
            client2.Headers["Content-type"] = "application/json";
            client2.Encoding = Encoding.UTF8;

            string json = client2.UploadString(WebAPIUrl + "api/Login/GetMenuDetails", inputJson2);
            //////string json = client2.UploadString("http://localhost:49708/api/Login/GetMenuDetails", inputJson2);
            ////string json = client2.UploadString("http://grclocalhost:49708/api/Login/GetMenuDetails", inputJson2);

            //////LogWrite(json, inputJson2);

            //var emp = (new JavaScriptSerializer()).Deserialize<zdesk_m_page_master_tbl>(json);

            var emp = JsonConvert.DeserializeObject<List<zdesk_m_page_master_tbl>>(json);
            Session["MenuControl"] = emp;
            return PartialView("MenuControl", Session["MenuControl"]);
        }

        public void LogWrite(string logMessage, string InputString)
        {
            try
            {
                using (StreamWriter w = System.IO.File.AppendText("D:\\" + "log.txt"))
                {
                    Log(logMessage, w, InputString);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Log(string logMessage, TextWriter txtWriter, string InputString)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("Input String: " + InputString);
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
    }
}