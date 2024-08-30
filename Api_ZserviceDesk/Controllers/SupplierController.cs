using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using PetaPoco;
using Api_ZserviceDesk.Models;
using System.Web;
using System.IO;
using System.Configuration;

namespace Api_ZserviceDesk.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SupplierController : ApiController
    {
      
        [HttpPost]
        public CommonStatus InsSupplierCategory(zdesk_m_supplier_category_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_supplier_category_sp @category_name ", new { c.category_name });
        }
        [HttpPost]
        public CommonStatus InsVendorServiceCategory(zdesk_m_supplier_category_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_vendor_service_category_sp @category_name ", new { c.category_name });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_supplier_category_tbl> GetSupplierCategoryLists()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_supplier_category_tbl>("exec zdesk_get_supplier_category_list_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_supplier_service_category_tbl> GetVendorServiceCategoryLists()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_supplier_service_category_tbl>("select * from zdesk_m_supplier_service_category_tbl where is_active=1");
        }
        [HttpPost]
        public CommonStatus InsSupplierStatus(zdesk_m_supplier_status_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_supplier_status_sp @sup_status_name ", new { c.sup_status_name });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_supplier_status_tbl> GetSupplierStatusLists()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_supplier_status_tbl>("exec zdesk_get_supplier_status_list_sp");
        }
        [HttpPost]
        public CommonStatus InsSupplierDetails(zdesk_m_supplier_details_tbl_new c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_supplier_details_sp  @supplier_code,@supplier_name,@address, @city, @contact_person, @sup_status_id_fk, @email, @sup_category_id_fk,@phone_number,@GSTNumber,@note,@services ",
                    new { c.supplier_code, c.supplier_name, c.address, c.city, c.contact_person, c.sup_status_id_fk, c.email, c.sup_category_id_fk, c.phone_number, c.GSTNumber, c.note, c.services });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_supplier_details_tbl> GetSupplierDetails()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_supplier_details_tbl>("exec zdesk_get_supplier_details_sp");
        }

        [HttpPost]
        public IEnumerable<zdesk_m_supplier_details_tbl> GetSupplierDetailsFilter(zdesk_m_supplier_details_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_supplier_details_tbl>("exec zdesk_get_supplier_details_filter_sp @category_name,@sup_status_name,@city",
                new { t.category_name, t.sup_status_name, t.city });
        }


        [HttpGet]
        public IEnumerable<zdesk_m_supplier_details_tbl> GetSupplierCode()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_supplier_details_tbl>("exec Get_Vendor_Code");
        }

        [HttpPost]
        public zdesk_m_supplier_details_tbl GetSupplierDetailsList(zdesk_m_supplier_details_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_supplier_details_tbl>("Exec zdesk_get_supplier_details_list_sp @supplier_id_pk", new { c.supplier_id_pk });
        }
        [HttpPost]
        public CommonStatus UpdateSupplierManagements(zdesk_m_supplier_details_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_upd_supplier_datails_sp @supplier_id_pk,@risk_ass_mng_result,@track_record,@refrence,@creadit_rating",
                       new { s.supplier_id_pk, s.risk_ass_mng_result, s.track_record, s.refrence, s.creadit_rating });
        }
        [HttpPost]
        public CommonStatus InsSupplierContactDetails(zdesk_m_supplier_contact_details_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_supplier_contact_details_sp  @supplier_id_fk,@name,@email,@mobile_no,@address,@designation", new { c.supplier_id_fk, c.name, c.email, c.mobile_no, c.address, c.designation });
        }
        [HttpPost]
        public IEnumerable<zdesk_m_supplier_contact_details_tbl> GetSupplierContactDetails(zdesk_m_supplier_contact_details_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Fetch<zdesk_m_supplier_contact_details_tbl>("Exec zdesk_get_supplier_contact_details_sp @supplier_id_fk", new { c.supplier_id_fk });
        }
        [HttpPost]
        public zdesk_m_supplier_details_tbl GetSupplierDetailsEdit(zdesk_m_supplier_details_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_supplier_details_tbl>("Exec zdesk_get_supplier_detail_edit_sp @supplier_id_pk", new { c.supplier_id_pk });
        }
        [HttpPost]
        public CommonStatus UpdateSupplierDetails(zdesk_m_supplier_details_tbl_new c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_update_supplier_detail_sp @supplier_id_pk,@supplier_code,@supplier_name,@address, @city, @contact_person, @sup_status_id_fk, @email, @sup_category_id_fk,@phone_number,@GSTNumber,@note,@services",
            new { c.supplier_id_pk, c.supplier_code, c.supplier_name, c.address, c.city, c.contact_person, c.sup_status_id_fk, c.email, c.sup_category_id_fk, c.phone_number, c.GSTNumber, c.note, c.services });
        }
        [HttpPost]
        public CommonStatus UpdateSupplierStatus(zdesk_m_supplier_details_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_upd_suplier_status_sp @supplier_id_pk,@sup_status_id_fk", new { c.supplier_id_pk, c.sup_status_id_fk });
        }
        [HttpPost]
        public CommonStatus DeleteSupplierByID(zdesk_m_supplier_details_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_supplier_by_id_sp  @supplier_id_pk", new { s.supplier_id_pk });
        }
        [HttpPost]
        public CommonStatus UpdateSupplierManagementsDocument(zdesk_m_supplier_doc_details_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_supplier_doc_details_sp  @supplier_id_fk,@doc_type,@doc_name,@description,@documents",
                       new { s.supplier_id_fk, s.doc_type, s.doc_name, s.description, s.documents });
        }
        [HttpPost]
        public IEnumerable<zdesk_m_supplier_doc_details_tbl> GetSupplierDocumentDetails(zdesk_m_supplier_doc_details_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Fetch<zdesk_m_supplier_doc_details_tbl>("Exec zdesk_get_supplier_doc_details_sp @supplier_id_fk", new { c.supplier_id_fk });
        }
        [HttpPost]
        public CommonStatus DeleteSupplierDocumentByID(zdesk_m_supplier_doc_details_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_supplier_document_by_id_sp  @suplier_doc_id_pk", new { s.suplier_doc_id_pk });
        }
        [HttpPost]
        public IEnumerable<zdesk_m_supplier_service_category_tbl> GetVendorServicesById(zdesk_m_supplier_details_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_supplier_service_category_tbl>("exec zdesk_get_services_for_supplier_by_id_sp @supplier_id_pk", new { t.supplier_id_pk });
        }
        [HttpPost]
        public IEnumerable<zdesk_m_consumable_item_tbl> GetConsumableForSupplier(zdesk_m_supplier_details_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            var data = db.Query<zdesk_m_consumable_item_tbl>("exec zdesk_get_consumables_list_for_supplier_sp @supplier_id_pk", new { s.supplier_id_pk });
            return data;
        }
        [HttpPost]
        public IEnumerable<zdesk_m_asset_tbl> GetAssetsForSupplier(zdesk_m_supplier_details_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_asset_tbl>("exec zdesk_get_assets_list_for_supplier_sp @supplier_id_pk", new { s.supplier_id_pk });
        }

        [HttpPost]
        public IEnumerable<zdesk_m_asset_tbl> GetAssetsSoldToSupplier(zdesk_m_supplier_details_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_asset_tbl>("exec zdesk_get_assets_list_sold_to_supplier_sp @supplier_id_pk", new { s.supplier_id_pk });
        }

        [HttpPost]
        public IEnumerable<zdesk_m_software_tbl> GetSoftwareForSupplier(zdesk_m_supplier_details_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_software_tbl>("exec zdesk_get_software_list_for_supplier_sp @supplier_id_pk", new { s.supplier_id_pk });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_supplier_service_category_tbl> GetVendorServiceList()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_supplier_service_category_tbl>("exec zdesk_get_supplier_services_list_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_supplier_details_tbl> GetSupplierVendorCode()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Fetch<zdesk_m_supplier_details_tbl>("exec zdesk_get_supplier_vendor_code_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_supplier_details_tbl> GetVendorCityList()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_supplier_details_tbl>("exec zdesk_get_vendor_city_sp");
        }
        [HttpPost]
        public IEnumerable<zdesk_t_asset_component_tbl> GetComponentsForSupplier(zdesk_m_supplier_details_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_t_asset_component_tbl>("exec zdesk_get_component_for_supplier_sp @supplier_id_pk", new { t.supplier_id_pk });
        }
    }
}


