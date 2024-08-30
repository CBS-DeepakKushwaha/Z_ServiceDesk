using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using PetaPoco;
using System.Configuration;
using System.IO;
using Api_ZserviceDesk.Models;
using System.Web;
using System.Web.Http.Results;

namespace Api_ZserviceDesk.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CommonapiController : ApiController
    {
        [HttpPost]
        public int InsException(ExceptionTracking t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Execute("exec zdesk_ins_exception_sp @status,@message,@exception_message,@exception_type,@StackTrace", new { t.status, t.message, t.exception_message, t.exception_type, t.StackTrace });
        }
        [HttpPost]
        public IEnumerable<EnployeeList> GetEmployeeListSGD(EnployeeList c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Fetch<EnployeeList>("Exec zdesk_get_employee_list_by_sgd_sp @DataItem", new { c.DataItem });
        }
        [HttpPost]
        public int InsPopulationTesting(TestingPopulation t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            // t.Country = "India";
            //MastersController mc = new MastersController
            //{

            //};

            return db.Execute("exec zdesk_ins_testing_sp @Male,@Female,@Others,@Country", new { t.Male, t.Female, t.Others, t.Country });
        }
        [HttpPost]
        public CommonStatus InsPrefix(zdesk_m_prefix_value_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_prefix_value_sp  @prefix_value,@master_value", new { s.prefix_value, s.master_value });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_prefix_value_tbl> GetPrefix()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_prefix_value_tbl>("exec zdesk_get_prefix_list_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_auto_closed_tbl> GetAutoClosedTimeList()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_auto_closed_tbl>("exec zdesk_get_auto_close_time_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_prefix_value_tbl> GetTaskPrefix()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_prefix_value_tbl>("exec zdesk_get_task_prefix_list_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_prefix_value_tbl> GetProblemPrefix()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_prefix_value_tbl>("exec zdesk_get_problem_prefix_list_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_prefix_value_tbl> GetChangePrefix()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_prefix_value_tbl>("exec zdesk_get_change_prefix_list_sp");
        }
        
        [HttpPost]
        public IEnumerable<zdesk_m_location_tbl> GetLocationAccToBusinessUnitList(zdesk_m_location_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Fetch<zdesk_m_location_tbl>("Exec zdesk_m_location_acc_to_business_unit_tbl_sp @business_unit_id_fk", new { c.business_unit_id_fk });
        }
        [HttpPost]
        public IEnumerable<zdesk_m_departments_tbl> GetDepartmentAccToBusinessUnitList(zdesk_m_departments_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Fetch<zdesk_m_departments_tbl>("Exec zdesk_m_department_acc_to_business_unit_tbl_sp @business_unit_id_fk", new { c.business_unit_id_fk });
        }
        [HttpPost]
        public IEnumerable<zdesk_m_departments_tbl> GetDepartmentAccToUserList(zdesk_m_departments_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Fetch<zdesk_m_departments_tbl>("Exec zdesk_m_department_acc_to_user_tbl_sp @user_id_pk", new { c.user_id_pk });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_tickets_tbl_new> GetViewWorkloadList()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_tickets_tbl_new>("exec zdesk_get_view_workload_list_sp");
        }
        [HttpPost]
        public zdesk_employee GetAdminDetailsById(zdesk_employee c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            var data = db.SingleOrDefault<zdesk_employee>("Exec zdesk_get_login_engineer_details_sp @id", new { c.id });
            var pass = EncryptDecrypt.DecryptUrl(data.password);
            data.password = pass;
            return data;
        }
        [HttpPost]
        public zdesk_m_users_tbl GetUserDetailsById(zdesk_m_users_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_users_tbl>("Exec zdesk_get_login_user_details_sp @user_id_pk", new { c.user_id_pk });
        }
        [HttpPost]
        public IEnumerable<zdesk_m_dropdown> GetDropDownData(zdesk_m_dropdown d)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_dropdown>("exec zdesk_m_dropdown_sp @ID,@Param1,@Param2,@Section", new { d.ID, d.Param1,d.Param2, d.Section });
        }

        [HttpPost]
        public CommonStatus InsUpdMasterData(zdesk_m_dropdown s)
        {
            CommonStatus cs = new CommonStatus();
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            cs = db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_upd_masterdata_sp @ID,@Param1,@Name, @Section,@is_default", new { s.ID, s.Param1, s.Name, s.Section, s.is_default });
            return cs;
        }

        [HttpPost]
        public CommonStatus DelMasterData(zdesk_m_dropdown s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_masterdata_sp @ID, @Section", new { s.ID, s.Section });
        }

        [HttpPost]
        public DocumentDetailsModel fnInsDocumentsnew(DocumentDetailsModel f)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Single<DocumentDetailsModel>("exec efp_ins_documents_sp @id,@is_director_proof,@proof_type,@proof_name,@description,@frontside,@file_name,@guid,@file_size,@file_type,@updated_by", new { f.id, f.is_director_proof, f.proof_type, f.proof_name, f.description, f.frontside, f.file_name, f.guid, f.file_size, f.file_type, f.updated_by });
        }

        [HttpGet]
        public IEnumerable<zdesk_m_notification_tbl> GetConsumableNotification()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_notification_tbl>("exec zdesk_get_consumable_notification_all_sp");
        }

        [HttpPost]
        public int InsConsumableNotification(zdesk_m_notification_tbl t)  
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Execute("exec zdesk_ins_consumable_notification_sp  @category_id_fk,@min_qty,@other_tech_email,@tech_email,@sub_category_id_fk", new { t.category_id_fk, t.min_qty, t.other_tech_email, t.tech_email,t.sub_category_id_fk });
        }

        [HttpPost]
        public CommonStatus DeleteConsumableNotification(zdesk_m_notification_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_consumable_notification_sp  @notif_id_pk", new { s.notif_id_pk });
        }

        [HttpPost]
        public void UploadOrgFile()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded file from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedFile"];
                string DocFolderName = HttpContext.Current.Request.Form["UniqueID"].ToString();
                string DocCategory = HttpContext.Current.Request.Form["DocFolderPath"].ToString();
                //string DocSubCategory = HttpContext.Current.Request.Form["Category"].ToString();

                if (httpPostedFile != null)
                {
                    ////HttpContext.Current.Session["ProposalID"] = 1;
                    ////var ProposalID = Convert.ToInt32(HttpContext.Current.Session["ProposalID"]);
                    var TempFolderPath = "~/DocFolder/" + DocCategory;
                    var DocFolderPath = TempFolderPath + "/" + DocFolderName;
                    //// var CategoryFolderPath = DocFolderPath + "/" + DocSubCategory;

                    if (!(Directory.Exists(HttpContext.Current.Server.MapPath(TempFolderPath))))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(TempFolderPath));
                    }

                    if (!(Directory.Exists(HttpContext.Current.Server.MapPath(DocFolderPath))))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(DocFolderPath));
                    }

                    //////if (!(Directory.Exists(HttpContext.Current.Server.MapPath(CategoryFolderPath))))
                    //////{
                    //////    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(CategoryFolderPath));
                    //////}

                    //ClearFolder(HttpContext.Current.Server.MapPath(DocFolderPath));

                    ////ClearFolder(HttpContext.Current.Server.MapPath(TempFolderPath));

                    var fileSave = HttpContext.Current.Server.MapPath(DocFolderPath);
                    var fileSavePath = Path.Combine(fileSave, httpPostedFile.FileName);
                    httpPostedFile.SaveAs(fileSavePath);
                }
            }
        }

        public JsonResult<CommonStatus> UploadOrgFile1()
        {
            CommonStatus cm = new CommonStatus();
            try
            {
                var data = HttpContext.Current.Request.Files.AllKeys.Any();
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    // Get the uploaded file from the Files collection
                    var httpPostedFile = HttpContext.Current.Request.Files["UploadedFile"];
                    string DocFolderName = HttpContext.Current.Request.Form["PathName"].ToString();
                    string DocCategory = HttpContext.Current.Request.Form["DocCategoryID"].ToString();
                    string DocSubCategory = HttpContext.Current.Request.Form["DocSubCategoryID"].ToString();

                    if (httpPostedFile != null)
                    {
                        ////HttpContext.Current.Session["ProposalID"] = 1;
                        ////var ProposalID = Convert.ToInt32(HttpContext.Current.Session["ProposalID"]);
                        var TempFolderPath = "~/DocFolder/" + DocFolderName;
                        var DocFolderPath = TempFolderPath + "/" + DocCategory;
                        var DocSubFolderPath = DocFolderPath + "/" + DocSubCategory;

                        if (!(Directory.Exists(HttpContext.Current.Server.MapPath(TempFolderPath))))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(TempFolderPath));
                        }

                        if (!(Directory.Exists(HttpContext.Current.Server.MapPath(DocFolderPath))))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(DocFolderPath));
                        }

                        if (!(Directory.Exists(HttpContext.Current.Server.MapPath(DocSubFolderPath))))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(DocSubFolderPath));
                        }

                        //ClearFolder(HttpContext.Current.Server.MapPath(DocSubFolderPath));

                        ////ClearFolder(HttpContext.Current.Server.MapPath(TempFolderPath));

                        var fileSave = HttpContext.Current.Server.MapPath(DocSubFolderPath);
                        var fileSavePath = Path.Combine(fileSave, httpPostedFile.FileName);
                        httpPostedFile.SaveAs(fileSavePath);
                        cm.status = "Upload Success";
                        cm.status_id = 1;
                        return Json(cm);
                    }
                    cm.status_id = 2;
                    cm.status = "No file found!";
                    return Json(cm);
                }
                cm.status_id = 3;
                cm.status = "Some unknown error found!";
                return Json(cm);
            }
            catch(Exception e)
            {
                cm.status_id = 0;
                cm.status = "Error :- " + e.Message;
                return Json(cm);
            }
        }

        public void ClearFolder(string FolderName)
        {
            if (Directory.Exists(FolderName))
            {
                DirectoryInfo dir = new DirectoryInfo(FolderName);

                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                foreach (DirectoryInfo di in dir.GetDirectories())
                {
                    ClearFolder(di.FullName);
                    di.Delete();
                }
            }
            else
            {
                Directory.CreateDirectory(FolderName);
            }
        }
        [HttpPost]
        public IEnumerable<DocumentDetailsModel> UploadFilesNew()
        {
            // Checking no of files injected in Request object  
            List<DocumentDetailsModel> DocID = new List<DocumentDetailsModel>();
            if (System.Web.HttpContext.Current.Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                    DocumentDetailsModel f = new DocumentDetailsModel();
                    f.proof_type = Convert.ToInt32(System.Web.HttpContext.Current.Request.Form.Get("proof_type").ToString());
                    f.proof_name = System.Web.HttpContext.Current.Request.Form.Get("proof_name").ToString();
                    f.updated_by = Convert.ToInt32(System.Web.HttpContext.Current.Request.Form.Get("updated_by").ToString());
                    f.id = Convert.ToInt32(System.Web.HttpContext.Current.Request.Form.Get("director_mst_pk").ToString());
                    f.is_director_proof = Convert.ToInt32(System.Web.HttpContext.Current.Request.Form.Get("is_director_proof").ToString());
                    for (int i = 0; i < files.Count; i++)
                    {
                        System.Web.HttpPostedFile file = files[i];
                        string filename;
                        // Checking for Internet Explorer  
                        if (System.Web.HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE" || System.Web.HttpContext.Current.Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            filename = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            int index = file.FileName.LastIndexOf(".");
                            filename = file.FileName.Substring(index + 1);
                        }
                        if (filename == "PDF" || filename == "Pdf")
                        {
                            filename = "pdf";
                        }
                        f.guid = Guid.NewGuid().ToString();
                        f.file_name = file.FileName;
                        filename = f.user_mst_fk + "_" + f.guid + "." + filename;
                        f.frontside = filename;
                        f.file_size = file.ContentLength;
                        f.file_type = file.ContentType;
                        string FilePath = ConfigurationManager.AppSettings["FileUpload"].ToString();
                        if (file.ContentLength > 0)
                        {
                            if (!File.Exists(FilePath + Path.GetFileName(filename)))
                            {
                                file.SaveAs(FilePath + Path.GetFileName(filename));
                                var d = fnInsDocumentsnew(f);
                                DocID.Add(new DocumentDetailsModel { document_id_pk = d.document_id_pk, file_name = f.file_name, guid = f.guid });
                            }
                        }

                    }
                    return DocID;
                }
                catch (Exception ex)
                {
                    ExceptionTracking et = new ExceptionTracking();
                    et.status = ((System.Net.WebException)ex.InnerException) != null ? ((System.Net.WebException)ex.InnerException).Status.ToString() : null;
                    et.message = ex.Message;
                    et.exception_message = ex.InnerException != null ? ex.InnerException.Message : null;
                    et.exception_type = ex.Message;
                    et.StackTrace = ex.StackTrace;
                    InsException(et);
                    return DocID;
                }
            }
            else
            {
                return DocID;
            }

        }

        //Edit By Ankur Pandey////
        [HttpPost]
        public CommonStatus EncryptString(CommonStatus cs1)
        {
            CommonStatus cs = new CommonStatus();
            string EncryptedData = EncryptDecrypt.EncryptUrl(cs1.status_id.ToString());
            cs.status = EncryptedData;

            return cs;
        }

        [HttpPost]
        public CommonStatus DecryptString(CommonStatus cs1)
        {
            CommonStatus cs = new CommonStatus();
            string EncryptedData = EncryptDecrypt.DecryptUrl(cs1.status.ToString());
            cs.status_id = Convert.ToInt32(EncryptedData);

            return cs;
        }

        [HttpPost]
        public CommonStatus EncryptStringName(CommonStatus cs1)
        {
            CommonStatus cs = new CommonStatus();
            string EncryptedData = EncryptDecrypt.EncryptUrl(cs1.subject.ToString());
            cs.status = EncryptedData;

            return cs;
        }

        [HttpPost]
        public CommonStatus DecryptStringName(CommonStatus cs1)
        {
            CommonStatus cs = new CommonStatus();
            string EncryptedData = EncryptDecrypt.DecryptUrl(cs1.status.ToString());
            cs.status = EncryptedData;

            return cs;
        }

        //
        // For documents controller (By Umesh)
        //

        [HttpPost]
        public IEnumerable<zdesk_m_org_documents_tbl> GetDocumentData(zdesk_m_org_documents_tbl d)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_org_documents_tbl>("exec zdesk_get_org_documents_sp @org_documents_id_pk,@document_category_id_fk", new { d.org_documents_id_pk, d.document_category_id_fk });
        }

        [HttpPost]
        public CommonStatus InsDocumentData(zdesk_m_org_documents_tbl s)
        {
            var FolderPath = "/DocFolder/OrgDocuments" + "/" + s.document_category_id_fk + "/" + s.document_sub_category_id_fk + "/";
            s.document_docPath = FolderPath + s.document_FileName;

            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_org_documents_sp @document_name,@document_description,@document_docPath,@document_category_id_fk,@document_sub_category_id_fk,@keywords"
                , new { s.document_name, s.document_description, s.document_docPath, s.document_category_id_fk, s.document_sub_category_id_fk,s.keywords });
        }

        [HttpPost]
        public CommonStatus UpdDocumentData(zdesk_m_org_documents_tbl s)
        {
            var FolderPath = "/DocFolder/OrgDocuments" + "/" + s.document_category_id_fk + "/" + s.document_sub_category_id_fk + "/";
            s.document_docPath = FolderPath + s.document_FileName;

            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_upd_org_documents_sp @org_documents_id_pk,@document_name,@document_description,@document_docPath,@document_category_id_fk,@document_sub_category_id_fk"
            , new { s.org_documents_id_pk, s.document_name, s.document_description, s.document_docPath, s.document_category_id_fk, s.document_sub_category_id_fk });
        }

        [HttpPost]
        public CommonStatus DelDocumentData(zdesk_m_org_documents_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_org_documents_sp @org_documents_id_pk", new { s.org_documents_id_pk });
        }

        [HttpPost]
        public CommonStatus DeleteUploadFile(zdesk_m_asset_document_tbl t)
        {
            CommonStatus cs = new CommonStatus();
            var path = t.path;
            var full_path = HttpContext.Current.Server.MapPath("~/DocFolder" + path);
            if (File.Exists(full_path))
            {
                File.Delete(full_path);
                cs.status_id = 1;
                return cs;
            }
            else
            {
                cs.status_id = 2;
                return cs;
            }
        }
        [HttpPost]
        public CommonStatus UpdateProfile(zdesk_employee t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            t.password = EncryptDecrypt.EncryptUrl(t.password);
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_profile_password @id,@password", new { t.id, t.password });
        }

        [HttpPost]
        public zdesk_m_users_tbl GetUserDetails(zdesk_m_users_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_users_tbl>("exec zdesk_get_user_details_by_id_sp @user_id_pk", new { t.user_id_pk });
        }
    }
}
