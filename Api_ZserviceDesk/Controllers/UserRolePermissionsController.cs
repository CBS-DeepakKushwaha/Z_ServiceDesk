using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using PetaPoco;
using Api_ZserviceDesk.Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace Api_ZserviceDesk.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserRolePermissionsController : ApiController
    {
        [HttpPost]
        public IEnumerable<zdesk_m_user_role_details_matrix_tbl> GetRolePermissonsLists(zdesk_m_user_role_details_matrix_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_user_role_details_matrix_tbl>("exec zdesk_get_user_role_details_sp @user_role_id_fk", new { s.user_role_id_fk });
        }

        [HttpPost]
        public CommonStatus InsUpdRolePermissons(zdesk_m_user_role_details_matrix_tbl s)
        {
            var db = new Database("Constr");

            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_upd_user_role_details_sp @user_role_details_id_pk,@user_role_id_fk, @page_master_id_fk, @Add, @Edit,@Delete,@View",
                        new
                        {
                            s.user_role_details_id_pk,
                            s.user_role_id_fk,
                            s.page_master_id_fk,
                            s.Add,
                            s.Edit,
                            s.Delete,
                            s.View
                        });
        }

        [HttpPost]
        public IHttpActionResult SetUserRolePermissonsDetails(Get_UserRoleOfUser_Result s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            IList<Get_UserRoleOfUser_Result> objRoleDetails;
            objRoleDetails = db.Query<Get_UserRoleOfUser_Result>("exec zdesk_get_user_role_information_sp @ID", new { s.ID }).ToList();

            if (objRoleDetails != null)
            {
                var json = JsonConvert.SerializeObject(objRoleDetails);
                return Json(json);
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<zdesk_m_user_role_tbl> GetUserRoleList()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_user_role_tbl>("exec zdesk_get_user_role_list_sp");
        }
        [HttpPost]
        public CommonStatus UpdateUserRole(zdesk_m_user_role_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_user_role_sp @user_role_id_pk,@role_name,@role_type,@is_active",
                new { t.user_role_id_pk, t.role_name,t.role_type, t.is_active });
        }
        [HttpPost]
        public zdesk_m_user_role_tbl GetRoleById(zdesk_m_user_role_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_user_role_tbl>("exec zdesk_get_user_role_by_id_sp @user_role_id_pk", new { t.user_role_id_pk });
        }
        [HttpPost]
        public CommonStatus InsNewRole(zdesk_m_user_role_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_ins_user_role_sp @role_name,@role_type", new { t.role_name,t.role_type });
        }

        [HttpPost]
        public CommonStatus DeleteRoleById(zdesk_m_user_role_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_del_user_role_sp @user_role_id_pk", new { t.user_role_id_pk });
        }

        [HttpPost]
        public IEnumerable<zdesk_m_page_controls_permissions_tbl> GetPageControlPermissonsLists(zdesk_m_page_controls_permissions_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_page_controls_permissions_tbl>("exec zdesk_get_page_controls_permissions_sp @user_role_id_fk,@PathURL,@Section", new { s.user_role_id_fk, s.PathURL,s.Section });
        }

        [HttpPost]
        public CommonStatus UpdPageControlPermissons(zdesk_m_page_controls_permissions_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_page_controls_permissions_sp @page_controls_permissions_id_pk,@IsVisible", new { t.page_controls_permissions_id_pk, t.IsVisible });
        }
    }
}
