using Api_ZserviceDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Configuration;

namespace Z_ServiceDesk.Models
{
    public static class ValidationClassCommon
    {
        static string WebsiteUrl = ConfigurationManager.AppSettings["Web_Url"];
        static string WebAPIUrl = ConfigurationManager.AppSettings["Base_Url"];

        public static List<ModelEntityFiled> modelEntityFileds(string Name)
        {
            List<ModelEntityFiled> data = new List<ModelEntityFiled>();

            Zdesk_m_Module_Page obj = new Zdesk_m_Module_Page { Name = Name, IsActive = true, Module_Id = 1, PageName = "", Page_Id = 0 };

            string inputJson2 = (new JavaScriptSerializer()).Serialize(obj);

            WebClient client2 = new WebClient();
            client2.Headers["Content-type"] = "application/json";
            client2.Encoding = Encoding.UTF8;
            string json = client2.UploadString(WebAPIUrl + "api/FieldManagement/GetFiledByPageName", inputJson2);
            //string json = client2.UploadString("https://sgrl-admin.zservicedesk.com/api/api/Login/CompanyLicence", inputJson2);  
            var result = (new JavaScriptSerializer()).Deserialize<List<ModelEntityFiled>>(json);

            return result;
        }
    }
}