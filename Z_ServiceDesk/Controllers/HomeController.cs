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
using System.Net.Http;
using System.Data;
using System.IO;


namespace Z_ServiceDesk.Controllers
{
    public class HomeController : Controller
    {
        static string WebsiteUrl = ConfigurationManager.AppSettings["Web_Url"];
        static string WebAPIUrl = ConfigurationManager.AppSettings["Base_Url"];

        public ActionResult Index()
        {
            var input2 = new
            {
                i = 0,
            };
            string inputJson2 = (new JavaScriptSerializer()).Serialize(input2);

            WebClient client2 = new WebClient();
            client2.Headers["Content-type"] = "application/json";
            client2.Encoding = Encoding.UTF8;
            //string json = client2.UploadString("https://sgrl-admin.zservicedesk.com/api/api/Login/CompanyLicence", inputJson2);
            string json = client2.UploadString(WebAPIUrl + "api/Login/CompanyLicence", inputJson2);
            var result = (new JavaScriptSerializer()).Deserialize<int>(json);
            if (result == 0)
            {
                return RedirectToAction("CompanyLicence", "home");
                ;
            }
            return View();
        }

        public ActionResult CompanyLicence()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CompanyLicence(string licenceKey)
        {
            var input2 = new
            {
                license_key = licenceKey,

            };
            string inputJson2 = (new JavaScriptSerializer()).Serialize(input2);

            WebClient client2 = new WebClient();
            client2.Headers["Content-type"] = "application/json";
            client2.Encoding = Encoding.UTF8;
            //string json = client2.UploadString("https://sgrl-admin.zservicedesk.com/api/api/Login/CompanyLicenceSave", inputJson2);
            string json = client2.UploadString(WebAPIUrl + "api/Login/CompanyLicenceSave", inputJson2);
            var result = (new JavaScriptSerializer()).Deserialize<int>(json);
            if (result != 0)
            {
                return RedirectToAction("Index", "home");
            }
            ViewBag.Message = "Licence key is Invalid";
            return View();
        }


        public ActionResult NoPermission()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(zdesk_employee e)
        {
            string url = string.Empty;
            zdesk_employee emp = new zdesk_employee();
            if (ModelState.IsValid)
            {
                e.password = EncryptDecrypt.EncryptUrl(e.password);
                var v = EncryptDecrypt.DecryptUrl("cVjGepZHGM32oZJ24O9HUQG2O/5gObm5qZvlw1mGmjE-76");
                emp = validLogin(e.email, e.password, true);
                if (emp.id == 0 && emp.location_id_pk == 0)
                {
                    ////ViewBag.Message = "Technician Not Found : Please Enter valid User Credentilal";
                    ////return View(e);

                    url = "Technician Not Found : Please Enter valid User Credentilal!";
                    return new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new Dictionary<string, string>() { { "err1", url } }
                    };
                }
                //else if (emp.user_code != null)  
                //{
                //    zdesk_employee ei = new zdesk_employee();
                //    ei.id = emp.id;
                //    ei.user_code = emp.user_code;
                //    ei.name = emp.name;
                //    ei.location_id_pk = emp.location_id_pk;
                //    Session["EmployeeInfo"] = ei;
                //    return RedirectToAction("Index", "UserDashBoard");
                //}
                //else if (emp.id == 2)
                //{
                //    ViewBag.Message = "Technician Already Logged In";
                //    return View(e);
                //}
                else if (emp.id > 0 && emp.location_id_pk > 0)
                {
                    zdesk_employee ei = new zdesk_employee();
                    ei.id = emp.id;
                    ei.name = emp.name;
                    ei.location_id_pk = emp.location_id_pk;
                    ei.roleid = emp.roleid;
                    ei.UserType = emp.UserType;
                    ei.email = emp.email;
                    ei.flag = true;
                    this.Session["EmployeeInfo"] = (object)ei;
                    ////Session["EmployeeInfo"] = ei;
                    ////return RedirectToAction("Asset", "Home");

                    url = Url.Action("Asset", "Home");
                    //return (ActionResult)this.RedirectToAction(nameof(DashBoard), "Home");
                    return new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new Dictionary<string, string>() { { "url", url } }
                    };
                }
                else
                {
                    url = emp.id.ToString();

                    return new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new Dictionary<string, string>() { { "err1", url } }
                    };
                }
            }
            else
            {
                url = "Data input error!";
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new Dictionary<string, string>() { { "err1", url } }
                };
            }
            ////return View(emp);
        }
        [NonAction]
        public zdesk_employee validLogin(string emp_email, string emp_password, bool flag)
        {
            emp_password = EncryptDecrypt.DecryptUrl(emp_password);
            var input2 = new
            {
                email = emp_email,
                password = emp_password,
                flag = flag
            };
            string inputJson2 = (new JavaScriptSerializer()).Serialize(input2);
            WebClient client2 = new WebClient();
            client2.Headers["Content-type"] = "application/json";
            client2.Encoding = Encoding.UTF8;
            //string json = client2.UploadString("https://sgrl-admin.zservicedesk.com/api/api/Login/ValidateTechnician", inputJson2);
            string json = client2.UploadString(WebAPIUrl + "api/Login/ValidateTechnician", inputJson2);
            zdesk_employee emp = (new JavaScriptSerializer()).Deserialize<zdesk_employee>(json);
            return emp;
        }
        public ActionResult DashBoard()
        {
            zdesk_employee empsession = (zdesk_employee)Session["EmployeeInfo"];
            return View(empsession);
        }
        public ActionResult Incident()
        {
            zdesk_employee empsession = (zdesk_employee)Session["EmployeeInfo"];
            return View(empsession);
        }
        public ActionResult Asset()
        {
            zdesk_employee empsession = (zdesk_employee)Session["EmployeeInfo"];
            if (empsession.id > 0)
            {
                return View(empsession);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Change()
        {
            zdesk_employee empsession = (zdesk_employee)Session["EmployeeInfo"];
            return View(empsession);
        }
        public ActionResult Knowledgebase()
        {
            zdesk_employee empsession = (zdesk_employee)Session["EmployeeInfo"];
            return View(empsession);
        }
        public ActionResult Requests()
        {
            zdesk_employee empsession = (zdesk_employee)Session["EmployeeInfo"];
            return View(empsession);
        }
        public ActionResult Software()
        {
            zdesk_employee empsession = (zdesk_employee)Session["EmployeeInfo"];
            return View(empsession);
        }
        public ActionResult Task()
        {
            zdesk_employee empsession = (zdesk_employee)Session["EmployeeInfo"];
            return View(empsession);
        }
        public ActionResult Problem()
        {
            zdesk_employee empsession = (zdesk_employee)Session["EmployeeInfo"];
            return View(empsession);
        }
        public ActionResult Vendor()
        {
            zdesk_employee empsession = (zdesk_employee)Session["EmployeeInfo"];
            return View(empsession);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Analytics()
        {
            zdesk_employee empsession = (zdesk_employee)Session["EmployeeInfo"];
            return View(empsession);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ActiveDirectory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ExcelGetIncident(string from, string end, string SelectedValue, int type)
        {

            string h = "";
            string reportname = "";
            ReportFilter obj = new ReportFilter
            {
                end = end,
                from = from,
                ReportTypes = GetReportType(type),
                SelectedValue = Convert.ToInt32(SelectedValue)
            };
            reportname = GetReportType(type).ToString();
            ; using (var client = new HttpClient())
            {

                //client.BaseAddress = new Uri("https://sgrl-admin.zservicedesk.com/api/api/");
                client.BaseAddress = new Uri(WebAPIUrl + "api/");
                //  client.BaseAddress = new Uri("https://sgrl-admin.zservicedesk.com/api/api/");
                var response = client.PostAsJsonAsync("DashBoardChart/ExcelReportList", obj).Result;
                if (response.IsSuccessStatusCode)
                {
                    var Data = response.Content.ReadAsAsync<List<dynamic>>().Result;

                    var Dt = GetDataTableFromObject(Data.ToList());
                    h = ExportData(Dt, reportname);

                }
                else
                    Console.Write("Error");
            }
            // byte[] fileBytes = System.IO.File.ReadAllBytes(h);
            // string fileName = Guid.NewGuid().ToString() + ".csv";
            // return File(h, "application/vnd.ms-excel", "incidence");
            return Json(h, JsonRequestBehavior.AllowGet);
            ///return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }

        public static DataTable GetDataTableFromObject(List<dynamic> allRecords)
        {
            DataTable dt = new DataTable();
            foreach (dynamic record in allRecords)
            {
                DataRow dr = dt.NewRow();
                foreach (dynamic item in record)
                {
                    //var prop = (IDictionary<String, Object>)item;
                    var Column = ((Newtonsoft.Json.Linq.JProperty)item).Name;
                    if (!dt.Columns.Contains(Column.ToString())) //Column_Name = Property name
                    {
                        dt.Columns.Add(new DataColumn(Column.ToString()));
                    }

                    dr[Column.ToString()] = ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JProperty)item).Value).Value;  //Data = value
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }
        public string ExportData(DataTable dt, string aTitle)
        {
            var guid = Guid.NewGuid();
            var FileName = $"{aTitle}-{guid}.csv";
            try
            {
                var path = Server.MapPath("~/CSVFile/");
                if (!Directory.Exists(path))
                    throw new DirectoryNotFoundException($"Directory not found: {path}");


                string filePath = Path.Combine(path, FileName);
                string delimiter = ",";
                StringBuilder sb = new StringBuilder();
                List<string> CsvRow = new List<string>();
                foreach (DataColumn c in dt.Columns)
                {
                    CsvRow.Add(c.ColumnName);
                }
                sb.AppendLine(string.Join(delimiter, CsvRow));
                foreach (DataRow r in dt.Rows)
                {
                    CsvRow.Clear();
                    foreach (DataColumn c in dt.Columns)
                    {
                        CsvRow.Add(r[c].ToString());
                    }
                    sb.AppendLine(string.Join(delimiter, CsvRow));
                }

                System.IO.File.WriteAllText(filePath, sb.ToString());
            }
            catch (Exception ex)
            {

            }

            return FileName;
        }
        [HttpGet]
        //[DeleteFileAttribute] //Action Filter, it will auto delete the file after download,                               //I will explain it later
        public ActionResult Download(string file)
        {
            //get the temp folder and file path in server
            string fullPath = Path.Combine(Server.MapPath("~/CSVFile/"), file);

            //return the file for download, this is an Excel 
            //so I set the file content type to "application/vnd.ms-excel"
            return File(fullPath, "application/vnd.ms-excel", file);
        }
        public ReportType GetReportType(int Type)
        {
            switch (Type)
            {
                case 1:
                    return ReportType.GetIncident;
                    break;
                case 2:
                    return ReportType.IncidentbyPrority;
                    break;
                case 3:
                    return ReportType.IncidentbySupport;
                    break;
                case 4:
                    return ReportType.IncidentbyLocation;
                    break;
                case 5:
                    return ReportType.IncidentbyCategory;
                    break;
                case 6:
                    return ReportType.Incidance_Sla;
                case 7:
                    return ReportType.ServiceRequest;
                case 8:
                    return ReportType.Service_Request_Active;
                case 9:
                    return ReportType.Service_Request_By_Support;
                case 10:
                    return ReportType.Service_Request_ByLocation;
                case 11:
                    return ReportType.Service_Request_Category;
                case 12:
                    return ReportType.Incident_Request_Pause;
                case 13:
                    return ReportType.assest_amc_status;
                case 14:
                    return ReportType.assest_by_Location;
                case 15:
                    return ReportType.assets_category_status;
                case 16:
                    return ReportType.Assets_AMCCategory;
                case 17:
                    return ReportType.Assets_assets_under;
                    break;
                case 18:
                    return ReportType.Incident_Enginner;
                default:
                    return 0;
            }

        }

        ////[HttpGet]
        ////public ActionResult GetSessionDetails()
        ////{
        ////    return Json(new[] { Session["EmployeeInfo"] });
        ////}

        [HttpGet]
        public ActionResult GetUserSessionDetails()
        {
            var UserSessionDetails = Session["EmployeeInfo"];

            return Json(UserSessionDetails, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GoogleIndex()
        {
            return View();
        }

        public JsonResult GoogleLogin(string email, string name, string gender, string lastname, string location)
        {
            string url = string.Empty;
            zdesk_employee zdeskEmployee1 = this.validLogin(email, string.Empty, false);

            if (zdeskEmployee1.id != null)
            {
                //  this.logs("User logged from in database");
                zdesk_employee zdeskEmployee2 = new zdesk_employee();
                zdeskEmployee2.id = (zdeskEmployee1.id);
                //zdeskEmployee2.user_code = (zdeskEmployee1.user_code);
                zdeskEmployee2.name = (zdeskEmployee1.name);
                zdeskEmployee2.roleid = zdeskEmployee1.roleid;
                zdeskEmployee2.UserType = zdeskEmployee1.UserType;
                zdeskEmployee2.flag = false;
                this.Session["EmployeeInfo"] = (object)zdeskEmployee2;
                url = Url.Action("Asset", "Home");
                //return (ActionResult)this.RedirectToAction(nameof(DashBoard), "Home");
                //
                url = "/Home/Asset";
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new Dictionary<string, string>() { { "url", url } }
                };
            }
            else
            {
                url = "User not found in the application database! Login failed.";
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new Dictionary<string, string>() { { "err1", url } }
                };
            }

        }

        public JsonResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new Dictionary<string, bool>() { { "url", true } }
            };
        }

        public ActionResult PatchManagementDashBoard()
        {
            return View();
        }
    }
}