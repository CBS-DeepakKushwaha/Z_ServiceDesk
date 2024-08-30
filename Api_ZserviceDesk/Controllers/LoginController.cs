using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web;
using PetaPoco;
using Api_ZserviceDesk.Models;

namespace Api_ZserviceDesk.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        [HttpPost]
        public zdesk_employee ValidateUser(zdesk_employee e)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;

           
            zdesk_employee emp = db.SingleOrDefault<zdesk_employee>("Exec zdesk_user_login_sp @email,@password", new { e.email, e.password });
            if (emp.id == 0 && emp.location_id_pk == 0)
            {
                return emp;
            }
            else
            {
                return emp;
            }
        }
        [HttpPost]
        public int CompanyLicence(int i=0)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;

            int result = db.SingleOrDefault<int>("Select top 1 1 from zdesk_t_license_tbl where Convert(Date,end_date)>=convert(date, getdate())");
            return result;
        }
        [HttpPost]
        public int CompanyLicenceSave(zdesk_t_license_tbl t)
        {
            var dblic = new Database("ConstrLic");
            dblic.EnableAutoSelect = false;

            zdesk_t_license_tbl result = dblic.SingleOrDefault<zdesk_t_license_tbl>("Select product_code,license_key,license_type,start_date,end_date,base_platform,admin_license,asset_admin_license,technician_license,full_suite,lifecycle_mgmt,support_type from zdesk_t_license_tbl where license_key = @license_key", new { t.license_key });
           if(result==null)
            {
                return 0;
            }

            var db = new Database("Constr");
            db.EnableAutoSelect = false;

            int result1 = db.SingleOrDefault<int>("Exec SaveCompanylic @product_code,@license_key,@license_type,@start_date,@end_date,@base_platform,@admin_license,@asset_admin_license,@technician_license,@full_suite,@lifecycle_mgmt,@support_type", new {
                result.product_code,
                result.license_key,
                result.license_type,
                result.start_date,
                result.end_date,
                result.base_platform,
                result.admin_license,
                result.asset_admin_license,
                result.standard_technician_license,
                result.full_suite,
                result.lifecycle_mgmt,
                result.support_type
            });
            return result1;
        }
        
        [HttpPost]
        public zdesk_employee ValidateTechnician(zdesk_employee e)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;

            e.password = EncryptDecrypt.EncryptUrl(e.password);
            zdesk_employee emp = db.SingleOrDefault<zdesk_employee>("Exec zdesk_technician_login_sp @email,@password,@flag", new { e.email, e.password,e.flag });
            if (emp.id == 0 && emp.location_id_pk == 0)
            {
                return emp;
            }
            else
            {
                return emp;
            }
        }
        [HttpPost]
        public CommonStatus UpdateTechnicianSessionId(zdesk_employee s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_upd_login_session_id_sp @id", new { s.id });
        }

        public List<zdesk_m_LicenceKey> GetLicence()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            List<zdesk_m_LicenceKey> emp = db.Query<zdesk_m_LicenceKey>("select * from [dbo].[Zdeks_m_Licence]").ToList();
            return emp;
        }
        [HttpPost]
        public int SaveLicence(List<zdesk_m_LicenceKey> e)
        {

            foreach (var v in e)
            {
                var db = new Database("Constr");
                db.EnableAutoSelect = false;
                zdesk_employee emp = db.SingleOrDefault<zdesk_employee>("Exec zdesk_Licence_Save_sp @LiceneceKey,@StartDate,@ExpireDate", new { v.LiceneceKey, v.StartDate, v.ExpireDate });

            }
            return 1;
        }

        [HttpPost]
        public IHttpActionResult GetMenuDetails(zdesk_employee e)
        {
            ////var db = new Database("Constr");
            ////db.EnableAutoSelect = false;
            ////zdesk_m_page_master_tbl emp = db.SingleOrDefault<zdesk_m_page_master_tbl>("Exec mMenuControl_Getrow");

            IEnumerable<zdesk_m_page_master_tbl> emp;
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            emp = db.Query<zdesk_m_page_master_tbl>("exec mMenuControl_Getrow @roleid", new { e.roleid });

            ////emp = db.Query<zdesk_m_page_master_tbl>("exec mMenuControl_Getrow");

            //var EmpJson= Json(emp);

            //return EmpJson;
            return Json(emp);

            ////var db = new Database("Constr");
            ////db.EnableAutoSelect = false;
            ////List<zdesk_m_page_master_tbl> emp = db.Query<zdesk_m_page_master_tbl>("exec mMenuControl_Getrow").ToList();
            ////return emp;
        }
    }
}
