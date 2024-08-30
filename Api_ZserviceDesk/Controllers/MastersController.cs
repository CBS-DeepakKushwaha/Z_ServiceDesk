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
    public class MastersController : ApiController
    {
        [HttpPost]
        public CommonStatus InsIssueType(zdesk_m_issue_type_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_issue_type_sp  @issue_type", new { s.issue_type });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_issue_type_tbl> GetIssueType()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_issue_type_tbl>("exec zdesk_get_issue_type_sp");
        }
        [HttpPost]
        public CommonStatus InsEscalationMatrix(zdesk_m_escalation_matrix_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_esclation_matrix_sp  @escalation_time,@escalation_email", new { s.escalation_time, s.escalation_email });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_escalation_matrix_tbl> GetEscalationMatrix()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_escalation_matrix_tbl>("exec zdesk_get_escalation_matrix_list_sp");
        }
        [HttpPost]
        public CommonStatus InsLocation(zdesk_m_location_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_locationn_sp  @business_unit_id_fk,@location_name", new { s.business_unit_id_fk, s.location_name });
        }
        [HttpPost]
        public CommonStatus InsStoreLocation(zdesk_m_stored_location_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_store_locationn_sp   @location_id_fk,@stored_location_name", new { s.location_id_fk, s.stored_location_name });
        }
        [HttpPost]
        public CommonStatus InsSetAsDefaultLocation(zdesk_m_location_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_upd_location_set_as_default_by_id_sp   @location_id_pk", new { s.location_id_pk });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_customer_tbl> GetCustomer()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_customer_tbl>("exec zdesk_get_customer_list_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_location_tbl> GetLocation()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_location_tbl>("exec zdesk_m_get_location_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_stored_location_tbl> GetStoreLocation()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_stored_location_tbl>("exec zdesk_m_get_store_location_sp");
        }
        [HttpPost]
        public CommonStatus InsAssetCategory(zdesk_m_asset_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_asset_category_sp  @asset_cat_name,@mapping_required", new { s.asset_cat_name, s.mapping_required });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_asset_category_tbl> GetAssetCategory()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_asset_category_tbl>("exec zdesk_m_asset_category_tbl_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_business_unit_tbl> GetBusinessUnit()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_business_unit_tbl>("exec zdesk_m_business_unit_sp");
        }
        [HttpPost]
        public CommonStatus InsBusinessUnit(zdesk_m_business_unit_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_business_unit_sp  @business_unit,@business_head", new { s.business_unit, s.business_head });
        }
        [HttpPost]
        public CommonStatus InsSetAsDefaultBusinessUnit(zdesk_m_business_unit_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_upd_business_unit_set_as_default_by_id_sp @business_unit_id_pk", new { s.business_unit_id_pk });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_change_type_tbl> GetChangeTypes()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_change_type_tbl>("exec zdesk_m_change_type_sp");
        }
        [HttpPost]
        public CommonStatus InsChangeType(zdesk_m_change_type_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_change_type_sp  @change_type_name", new { s.change_type_name });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_common_category_tbl> GetCategoryName()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_common_category_tbl>("exec zdesk_m_common_category_sp");
        }
        [HttpPost]
        public IEnumerable<zdesk_m_common_sub_category_tbl> GetSubCategoryName(zdesk_m_common_sub_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_common_sub_category_tbl>("exec zdesk_m_common_sub_category_sp @common_cat_id_fk", new { s.common_cat_id_fk });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_non_it_asset_category_tbl> GetNonItAssetCategoryName()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_non_it_asset_category_tbl>("exec zdesk_m_non_it_asset_category_sp");
        }
        [HttpPost]
        public CommonStatus InsCategoryName(zdesk_m_common_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_common_category_sp  @category_name", new { s.category_name });
        }
        [HttpPost]
        public CommonStatus InsNonItAssetCategoryName(zdesk_m_non_it_asset_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_non_it_asset_category_sp  @non_it_ass_cat_name", new { s.non_it_ass_cat_name });
        }
        [HttpPost]
        public CommonStatus InsDepartment(zdesk_m_departments_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_department_sp  @business_unit_id_fk,@department_name,@department_head", new { s.business_unit_id_fk, s.department_name, s.department_head });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_peripherals_category_tbl> GetPeripheralsCategory()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_peripherals_category_tbl>("exec zdesk_m_peripherals_category_sp");
        }
        [HttpPost]
        public CommonStatus InsPeripheralsCategory(zdesk_m_peripherals_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_peripherals_category_sp  @category_name", new { s.category_name });
        }
        [HttpPost]
        public CommonStatus InsSubLocation(zdesk_m_sub_location_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_sub_location_sp  @sub_location,@location_Id", new { s.sub_location, s.location_Id });
        }
        [HttpPost]
        public CommonStatus InsKnowledgeSubCategory(zdesk_m_knowledge_base_sub_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_Know_sub_Category_sp  @sub_category_name,@category_id_fk", new { s.sub_category_name, s.category_id_fk });
        }
        [HttpPost]
        public CommonStatus InsKnowledgeCategroy(zdesk_m_knowledge_base_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_know_category_sp  @category_name", new { s.category_name });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_knowledge_base_category_tbl> GetKnowledgeBaseLocation()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_knowledge_base_category_tbl>("select * from zdesk_m_knowledge_base_category_tbl");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_sub_location_tbl> GetSubLocation()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_sub_location_tbl>("exec zdesk_get_sub_location_list_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_knowledge_base_sub_category_tbl> GetKnowledgeSubCategory()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_knowledge_base_sub_category_tbl>("select c.category_name, * from zdesk_m_knowledge_base_sub_category_tbl sc left join zdesk_m_knowledge_base_category_tbl c on sc.category_id_fk=c.catogory_id_pk");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_sub_location_tbl> GetSubLocationbylocationid(int id)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_sub_location_tbl>("exec zdesk_get_sub_location_Bylocationid @id", new { id });
        }
        [HttpPost]
        public CommonStatus InsFloor(zdesk_m_floor_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_floor_sp  @floor_name", new { s.floor_name });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_floor_tbl> GetFloor()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_floor_tbl>("exec zdesk_get_floor_list_sp");
        }
        [HttpPost]
        public CommonStatus InsSection(zdesk_m_section_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_section_sp  @department_id_fk,@section_name", new { s.department_id_fk, s.section_name });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_section_tbl> GetSection()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_section_tbl>("exec zdesk_get_section_list_sp");
        }
        [HttpPost]
        public IEnumerable<zdesk_m_section_tbl> GetSectionDepartmentWise(zdesk_m_section_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_section_tbl>("exec zdesk_get_section_list_department_sp @department_id_fk", new { s.department_id_fk });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_publisher_tbl> GetPeripherals()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_publisher_tbl>("exec zdesk_get_peripherals_list_sp");
        }

        [HttpPost]
        public CommonStatus InsPeripherals(zdesk_m_publisher_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_peripherals_sp  @publisher_name", new { s.publisher_name });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_publisher_tbl> GetPublisher()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_publisher_tbl>("exec zdesk_m_publisher_tbl_sp");
        }
        [HttpPost]
        public CommonStatus InsPublisher(zdesk_m_publisher_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_Publisher_sp  @publisher_name", new { s.publisher_name });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_support_department_tbl> GetSupportDepartment()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_support_department_tbl>("exec zdesk_get_support_dep_list_sp");
        }
        [HttpPost]
        public CommonStatus InsSupportDepartment(zdesk_m_support_department_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_support_department_sp  @support_dep_name,@support_dep_head", new { s.support_dep_name, s.support_dep_head });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_reason_for_change_tbl> GetReasonForChange()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_reason_for_change_tbl>("exec zdesk_m_reason_for_change_sp");
        }
        [HttpPost]
        public CommonStatus InsReasonForChange(zdesk_m_reason_for_change_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_reason_for_change_sp  @reason_name", new { s.reason_name });
        }

        [HttpGet]
        public IEnumerable<zdesk_m_risk_tbl> GetRisk()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_risk_tbl>("exec zdesk_m_risk_sp");
        }
        [HttpPost]
        public CommonStatus InsRisk(zdesk_m_risk_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_risk_sp  @risk_name", new { s.risk_name });
        }
        [HttpPost]
        public CommonStatus InsCondition(zdesk_m_condition_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_condition_sp  @condition_name", new { s.condition_name });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_condition_tbl> GetCondition()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_condition_tbl>("Exec zdesk_m_condition_sp");
        }
        [HttpPost]
        public CommonStatus InsComponent(zdesk_m_component_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_component_sp  @component_name", new { s.component_name });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_component_tbl> GetComponent()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_component_tbl>("Exec zdesk_m_component_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_status_tbl> GetStatus()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_status_tbl>("exec zdesk_m_status_tbl_sp");
        }
        [HttpPost]
        public CommonStatus InsStatus(zdesk_m_status_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_status_sp  @status", new { s.status });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_publisher_tbl> GetPublisherList()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_publisher_tbl>("exec zdesk_m_publisher_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_software_name_tbl> GetSoftwareName()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_software_name_tbl>("exec zdesk_m_software_name_sp");
        }
        [HttpPost]
        public CommonStatus InsSoftwareName(zdesk_m_software_name_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_software_name_sp  @software_name,@publisher_id_fk,@soft_catogory_id_fk", new { s.software_name, s.publisher_id_fk, s.soft_catogory_id_fk });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_common_sub_category_tbl> GetAllSubCategory()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_common_sub_category_tbl>("exec zdesk_get_all_common_sub_category_list_sp");
        }
        [HttpPost]
        public CommonStatus InsSoftwareCategoryName(zdesk_m_software_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_software_category_name_sp  @soft_category_name", new { s.soft_category_name });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_software_category_tbl> GetAllSoftwareCategory()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_software_category_tbl>("exec zdesk_get_software_category_list_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_group_name_tbl> GetAllEndGroup()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_group_name_tbl>("select * from zdesk_m_group_name_tbl where is_active=1");
        }
        [HttpPost]
        public CommonStatus InsEndPointGroupName(zdesk_m_group_name_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_Group_name_sp  @group_name", new { s.group_name });
        }
        [HttpPost]
        public CommonStatus InsSubCategoryName(zdesk_m_common_sub_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_common_sub_category_sp  @common_cat_id_fk,@sub_category_name,@keywords", new { s.common_cat_id_fk, s.sub_category_name, s.keywords });
        }
        [HttpPost]
        public CommonStatus InsSupportGroup(zdesk_m_support_department_group_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_support_group_sp  @support_dep_id_pk,@support_dep_group_name,@support_group_head", new { s.support_dep_id_pk, s.support_dep_group_name, s.support_group_head });
        }
        [HttpPost]
        public CommonStatus InsPendingReason(zdesk_m_pending_reason_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_pending_reason_sp  @pending_reason_name", new { s.pending_reason_name });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_pending_reason_tbl> GetPendingReason()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_pending_reason_tbl>("exec zdesk_get_pending_reason_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_support_department_group_tbl> GetSupportGroup()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_support_department_group_tbl>("exec zdesk_get_all_support_department_group_list_sp");
        }
        [HttpPost]
        public CommonStatus InsConsultant(zdesk_m_consultant_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_consultant_sp  @department_id_fk,@consultant_name,@consultant_email,@consultant_contact_no", new { s.department_id_fk, s.consultant_name, s.consultant_email, s.consultant_contact_no });
        }
        [HttpPost]
        public CommonStatus UpdConsultant(zdesk_m_consultant_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_upd_consultant_sp  @consultant_id_pk,@department_id_fk,@consultant_name,@consultant_email,@consultant_contact_no,@updated_by", new { s.consultant_id_pk, s.department_id_fk, s.consultant_name, s.consultant_email, s.consultant_contact_no, s.updated_by });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_consultant_tbl> GetConsultant()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_consultant_tbl>("exec zdesk_get_all_consultant_list_sp");
        }
        [HttpPost]
        public IEnumerable<zdesk_m_consultant_tbl> GetConsultantName(zdesk_m_consultant_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_consultant_tbl>("exec zdesk_get_all_consultant_name_sp @department_id_fk", new { s.department_id_fk });
        }
        [HttpPost]
        public zdesk_m_consultant_tbl GetConsultantDetails(zdesk_m_consultant_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_consultant_tbl>("Exec zdesk_get_all_consultant_details_sp @consultant_id_pk", new { c.consultant_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteAssetCategoryByID(zdesk_m_asset_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_asset_category_by_id_sp  @asset_category_id_pk", new { s.asset_category_id_pk });
        }
        [HttpPost]
        public CommonStatus DeletePredefineReplyByID(zdesk_m_tickets_predefine_reply_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_predefine_reply_by_id_sp  @p_def_r_id_pk", new { s.p_def_r_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteBusinessUnitByID(zdesk_m_business_unit_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_business_unit_by_id_sp  @business_unit_id_pk", new { s.business_unit_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteChangeTypeByID(zdesk_m_change_type_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_change_type_by_id_sp  @change_type_id_pk", new { s.change_type_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteSectionByID(zdesk_m_section_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_section_by_id_sp  @section_id_pk", new { s.section_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteFloorByID(zdesk_m_floor_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_floor_by_id_sp  @floor_id_pk", new { s.floor_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteSubLocationID(zdesk_m_sub_location_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_sub_location_by_id_sp  @sub_location_id_pk", new { s.sub_location_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteKnowSubCategoryID(zdesk_m_knowledge_base_sub_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("delete from zdesk_m_knowledge_base_sub_category_tbl where sub_catogory_id_pk= @sub_catogory_id_pk; select 1 as status_id,'Sub Category delete successfully' as status", new { s.sub_catogory_id_pk });
        }
        [HttpGet]
        public CommonStatus DeleteKnowledgeCategoryID(int catogory_id_pk)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("delete from zdesk_m_knowledge_base_category_tbl where catogory_id_pk= @catogory_id_pk; select 1 as status_id,'Category delete successfully' as status", new { catogory_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteCommonCategoryByID(zdesk_m_common_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_common_category_by_id_sp  @common_cat_id_pk", new { s.common_cat_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteCommonSubCategoryByID(zdesk_m_common_sub_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_common_sub_category_by_id_sp  @sub_category_id_pk", new { s.sub_category_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteLocationByID(zdesk_m_location_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_location_by_id_sp  @location_id_pk", new { s.location_id_pk });
        }
        [HttpPost]
        public CommonStatus DeletePeripheralsCtegoryByID(zdesk_m_peripherals_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_peripherals_category_by_id_sp  @p_category_id_pk", new { s.p_category_id_pk });
        }
        [HttpPost]
        public CommonStatus DeletePublisherByID(zdesk_m_publisher_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_publisher_by_id_sp  @publisher_id_pk", new { s.publisher_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteReasonForChangeByID(zdesk_m_reason_for_change_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_reason_for_change_by_id_sp  @reason_id_pk", new { s.reason_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteRiskByID(zdesk_m_risk_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_risk_by_id_sp  @risk_id_pk", new { s.risk_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteConditionByID(zdesk_m_condition_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_condition_by_id_sp  @condition_id_pk", new { s.condition_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteSoftwareCategoryByID(zdesk_m_software_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_software_category_by_id_sp  @soft_catogory_id_pk", new { s.soft_catogory_id_pk });
        }
        [HttpPost]
        public CommonStatus DeletegroupByID(zdesk_m_group_name_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_group_by_id_sp  @group_id_pk", new { s.group_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteSoftwareNameByID(zdesk_m_software_name_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_software_name_by_id_sp  @soft_name_id_pk", new { s.soft_name_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteStatusByID(zdesk_m_status_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_status_by_id_sp  @status_id_pk", new { s.status_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteStoreLocationByID(zdesk_m_stored_location_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_store_location_by_id_sp  @stored_location_id_pk", new { s.stored_location_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteSupportDepartmentByID(zdesk_m_support_department_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_support_department_by_id_sp  @support_dep_id_pk", new { s.support_dep_id_pk });
        }
        [HttpPost]
        public CommonStatus DeletePendingReasonByID(zdesk_m_pending_reason_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_pending_reason_by_id_sp  @pending_reason_id_pk", new { s.pending_reason_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteConsultantByID(zdesk_m_consultant_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_cosultant_by_id_sp  @consultant_id_pk", new { s.consultant_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteComponentByID(zdesk_m_component_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_component_by_id_sp  @component_id_pk", new { s.component_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteEscalationMatrixByID(zdesk_m_escalation_matrix_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_escalation_matrix_by_id_sp  @escalation_id_pk", new { s.escalation_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteDepartmentByID(zdesk_m_departments_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_department_by_id_sp  @department_id_pk", new { s.department_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteSupportGroupByID(zdesk_m_support_department_group_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_support_department_group_by_id_sp  @support_group_id_pk", new { s.support_group_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteCloserCodeByID(zdesk_m_ticket_closer_code_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_closer_code_by_id_sp  @closer_id_pk", new { s.closer_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteGatePassAddressByID(zdesk_m_getpass_address_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_gate_pass_by_id_sp  @get_pass_add_id_pk", new { s.get_pass_add_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteSupplierCategoryByID(zdesk_m_supplier_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_supplier_category_by_id_sp  @sup_category_id_pk", new { s.sup_category_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteVendorServiceCategoryByID(zdesk_m_supplier_category_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_vendorService_category_by_id_sp  @sup_category_id_pk", new { s.sup_category_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteIssueTypeByID(zdesk_m_issue_type_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_issue_type_by_id_sp  @issue_type_id_pk", new { s.issue_type_id_pk });
        }

        //Edited By Ankur//

        [HttpPost]
        public zdesk_m_component_tbl GetComponentById(zdesk_m_component_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_component_tbl>("exec zdesk_get_components_name_by_id_sp @component_id_pk", new { c.component_id_pk });
        }
        [HttpPost]
        public zdesk_m_business_unit_tbl GetBusinessUnitById(zdesk_m_business_unit_tbl v)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_business_unit_tbl>("exec zdesk_get_Bussiness_unit_name_by_id_sp @business_unit_id_pk", new { v.business_unit_id_pk });
        }
        [HttpPost]
        public zdesk_m_location_tbl GetLocationNameById(zdesk_m_location_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_location_tbl>("exec zdesk_get_Location_name_by_id_sp @location_id_pk", new { w.location_id_pk });
        }
        [HttpPost]
        public zdesk_m_sub_location_tbl GetSubLocationById(zdesk_m_sub_location_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_sub_location_tbl>("exec zdesk_get_Sub_Location_name_by_id_sp @sub_location_id_pk", new { w.sub_location_id_pk });
        }
        [HttpPost]
        public zdesk_m_knowledge_base_sub_category_tbl GetKnowledgeSubCategoryById(zdesk_m_knowledge_base_sub_category_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_knowledge_base_sub_category_tbl>("select * from zdesk_m_knowledge_base_sub_category_tbl where sub_catogory_id_pk=  @sub_catogory_id_pk", new { w.sub_catogory_id_pk });
        }
        [HttpGet]
        public zdesk_m_knowledge_base_category_tbl GetKnowledgeCategoryById(int catogory_id_pk)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_knowledge_base_category_tbl>("select * from zdesk_m_knowledge_base_category_tbl where  catogory_id_pk=@catogory_id_pk", new { catogory_id_pk });
        }
        [HttpPost]
        public zdesk_m_floor_tbl GetFloorById(zdesk_m_floor_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_floor_tbl>("exec zdesk_get_floor_by_id_sp @floor_id_pk", new { w.floor_id_pk });
        }
        [HttpPost]
        public zdesk_m_status_tbl GetstatusById(zdesk_m_status_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_status_tbl>("exec zdesk_get_status_by_id_sp @status_id_pk", new { w.status_id_pk });
        }
        [HttpPost]
        public zdesk_m_risk_tbl GetriskById(zdesk_m_risk_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_risk_tbl>("exec zdesk_get_risk_by_id_sp @risk_id_pk", new { w.risk_id_pk });
        }
        [HttpPost]
        public zdesk_m_support_department_tbl GetsupportdepartmentById(zdesk_m_support_department_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_support_department_tbl>("exec zdesk_get_support_department_by_id_sp @support_dep_id_pk", new { w.support_dep_id_pk });
        }
        [HttpPost]
        public zdesk_m_support_department_group_tbl GetsupportgroupById(zdesk_m_support_department_group_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_support_department_group_tbl>("exec zdesk_get_support_group_by_id_sp @support_group_id_pk", new { w.support_group_id_pk });
        }
        [HttpPost]
        public zdesk_m_ticket_closer_code_tbl GetclosercodeById(zdesk_m_ticket_closer_code_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_ticket_closer_code_tbl>("exec zdesk_get_closer_code_by_id_sp @closer_id_pk ", new { w.closer_id_pk });
        }
        [HttpPost]
        public zdesk_m_tickets_predefine_reply_tbl GetPredifineReplyById(zdesk_m_tickets_predefine_reply_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_tickets_predefine_reply_tbl>("exec zdesk_get_predefine_reply_by_id_sp @p_def_r_id_pk ", new { w.p_def_r_id_pk });
        }
        [HttpPost]
        public zdesk_m_pending_reason_tbl GetPendingreasonById(zdesk_m_pending_reason_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_pending_reason_tbl>("exec zdesk_get_pending_reason_by_id_sp @pending_reason_id_pk ", new { w.pending_reason_id_pk });
        }
        [HttpPost]
        public zdesk_m_reason_for_change_tbl GetreasonforchangeById(zdesk_m_reason_for_change_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_reason_for_change_tbl>("exec zdesk_get_reason_for_change_by_id_sp @reason_id_pk ", new { w.reason_id_pk });
        }
        [HttpPost]
        public zdesk_m_common_category_tbl GetcommoncategoryById(zdesk_m_common_category_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_common_category_tbl>("exec zdesk_get_common_category_by_id_sp @common_cat_id_pk ", new { w.common_cat_id_pk });
        }
        [HttpPost]
        public zdesk_m_common_sub_category_tbl GetcommonsubcategoryById(zdesk_m_common_sub_category_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_common_sub_category_tbl>("exec zdesk_get_common_sub_category_by_id_sp @sub_category_id_pk ", new { w.sub_category_id_pk });
        }
        [HttpPost]
        public zdesk_m_issue_type_tbl GetIssueTypesById(zdesk_m_issue_type_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_issue_type_tbl>("exec zdesk_get_issue_type_by_id_sp @issue_type_id_pk ", new { w.issue_type_id_pk });
        }
        [HttpPost]
        public zdesk_m_prefix_value_tbl GetPrefixvalueById(zdesk_m_prefix_value_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_prefix_value_tbl>("exec zdesk_get_prefix_value_by_id_sp @prefix_id_pk", new { c.prefix_id_pk });
        }
        [HttpPost]
        public zdesk_m_auto_closed_tbl GetautoclosedById(zdesk_m_auto_closed_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            var data = db.SingleOrDefault<zdesk_m_auto_closed_tbl>("exec zdesk_get_auto_closed_by_id_sp @auto_closed_id_pk", new { c.auto_closed_id_pk });
            return data;
        }
        [HttpPost]
        public zdesk_m_service_req_predefine_reply_tbl GetPreDefineById(zdesk_m_service_req_predefine_reply_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_service_req_predefine_reply_tbl>("exec zdesk_get_pre_reply_by_id_sp @p_def_r_id_pk", new { c.p_def_r_id_pk });
        }
        [HttpPost]
        public zdesk_m_asset_category_tbl GetAssetCategoryById(zdesk_m_asset_category_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_asset_category_tbl>("exec zdesk_get_Asset_category_by_id_sp @asset_category_id_pk", new { c.asset_category_id_pk });
        }
        [HttpPost]
        public zdesk_m_software_category_tbl GetSoftwareCategoryById(zdesk_m_software_category_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_software_category_tbl>("exec zdesk_get_software_category_by_id_sp @soft_catogory_id_pk", new { c.soft_catogory_id_pk });
        }
        [HttpPost]
        public zdesk_m_group_name_tbl GetGroupnameById(zdesk_m_group_name_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_group_name_tbl>("select * from zdesk_m_group_name_tbl where group_id_pk =@group_id_pk", new { c.group_id_pk });
        }
        [HttpPost]
        public zdesk_m_software_name_tbl GetSoftwareNameById(zdesk_m_software_name_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_software_name_tbl>("exec zdesk_get_software_name_by_id_sp @soft_name_id_pk", new { c.soft_name_id_pk });
        }
        [HttpPost]
        public zdesk_m_publisher_tbl GetPublisherById(zdesk_m_publisher_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_publisher_tbl>("exec zdesk_get_publisher_by_id_sp @publisher_id_pk", new { c.publisher_id_pk });
        }
        [HttpPost]
        public zdesk_m_stored_location_tbl GetStoreLocationById(zdesk_m_stored_location_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_stored_location_tbl>("exec zdesk_get_store_location_by_id_sp @stored_location_id_pk", new { c.stored_location_id_pk });
        }
        [HttpPost]
        public zdesk_m_condition_tbl GetConditionById(zdesk_m_condition_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_condition_tbl>("exec zdesk_get_condition_by_id_sp @condition_id_pk", new { c.condition_id_pk });
        }
        [HttpPost]
        public zdesk_m_category_tbl GetConsumabeById(zdesk_m_category_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_category_tbl>("exec zdesk_get_consumable_by_id_sp @catogory_id_pk", new { c.catogory_id_pk });
        }
        [HttpPost]
        public zdesk_m_item_tbl GetConsumabelSubCategoryById(zdesk_m_item_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_item_tbl>("exec zdesk_get_sub_Cunsumable_category_by_id_sp @item_id_pk", new { c.item_id_pk });
        }
        [HttpPost]
        public zdesk_m_getpass_address_tbl GetGetPassAddressById(zdesk_m_getpass_address_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_getpass_address_tbl>("exec zdesk_get_get_pass_address_by_id_sp @get_pass_add_id_pk", new { c.get_pass_add_id_pk });
        }
        [HttpPost]
        public zdesk_m_supplier_category_tbl GetVendorCategoryById(zdesk_m_supplier_category_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_supplier_category_tbl>("exec zdesk_get_vendor_category_by_id_sp @sup_category_id_pk", new { c.sup_category_id_pk });
        }
        [HttpPost]
        public zdesk_m_supplier_service_category_tbl GetVendorServiceCategoryById(zdesk_m_supplier_category_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_supplier_service_category_tbl>("select * from zdesk_m_supplier_service_category_tbl where service_cat_id_pk=@sup_category_id_pk", new { c.sup_category_id_pk });
        }
        [HttpPost]
        public zdesk_m_priority_matrix_tbl GetSlaTimelineById(zdesk_m_priority_matrix_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_priority_matrix_tbl>("exec zdesk_get_sla_timeline_by_id_sp @priority_matrix_id_pk", new { c.priority_matrix_id_pk });
        }
        [HttpPost]
        public zdesk_m_holiday_cal_location_tbl GetHolidayCalendarlocationById(zdesk_m_holiday_cal_location_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_holiday_cal_location_tbl>("exec zdesk_get_holiday_calendar_location_by_id_sp @hol_cal_loc_id_pk", new { c.hol_cal_loc_id_pk });
        }
        [HttpPost]
        public roles GetTechnicianById(roles c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            var data = db.SingleOrDefault<roles>("exec zdesk_get_technician_by_id_sp @id", new { c.id });
            var pass = EncryptDecrypt.DecryptUrl(data.password);
            data.password = pass;
            return data;
        }
        [HttpPost]
        public zdesk_m_departments_tbl GetDeprtmentById(zdesk_m_departments_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_departments_tbl>("exec zdesk_get_department_by_id_sp @department_id_pk", new { c.department_id_pk });
        }
        [HttpPost]
        public CommonStatus UpdateDepartmentById(zdesk_m_departments_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_department_by_id_sp  @department_id_pk,@department_name,@business_unit_id_fk,@department_head",
                new { c.department_id_pk, c.department_name, c.business_unit_id_fk, c.department_head });
        }
        [HttpPost]
        public CommonStatus UpdatetechnicianById(roles c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            if (c.password != null && c.password != "")
            {
                c.password = EncryptDecrypt.EncryptUrl(c.password);
            }
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_technician_by_id_sp  @id,@name,@roleid,@email,@mobile,@location_id_pk,@title,@password,@support_dep_group,@type_license,@user_role_id_fk,@map_asset_by,@asset_category",
                new { c.id, c.name, c.roleid, c.email, c.mobile, c.location_id_pk, c.title, c.password, c.support_dep_group, c.type_license, c.user_role_id_fk, c.map_asset_by, c.asset_category });
        }
        [HttpPost]
        public CommonStatus UpdatetHolidayCalendarlocationById(zdesk_m_holiday_cal_location_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_holiday_calendar_list_by_id_sp @hol_cal_loc_id_pk,@hol_cal_location_name", new { c.hol_cal_loc_id_pk, c.hol_cal_location_name });
        }
        [HttpPost]
        public CommonStatus UpdateSlaTimelineById(zdesk_m_priority_matrix_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_get_pass_address_by_id_sp @priority_matrix_id_pk,@priority_id_fk,@display_name,@description,@response_sla,@resolution_sla,@penality_amount,@color,@is_active",
                new { c.priority_matrix_id_pk, c.priority_id_fk, c.display_name, c.description, c.response_sla, c.resolution_sla, c.penality_amount, c.color, c.is_active });
        }
        [HttpPost]
        public CommonStatus UpdateGetPassAddressById(zdesk_m_getpass_address_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_get_pass_address_by_id_sp @get_pass_add_id_pk,@address", new { c.get_pass_add_id_pk, c.address });
        }
        [HttpPost]
        public CommonStatus UpdateVendorById(zdesk_m_supplier_category_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_vendor_category_by_id_sp @sup_category_id_pk,@category_name", new { c.sup_category_id_pk, c.category_name });
        }
        [HttpPost]
        public CommonStatus UpdateVendorServiceById(zdesk_m_supplier_category_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_vendorService_category_by_id_sp @sup_category_id_pk,@category_name", new { c.sup_category_id_pk, c.category_name });
        }
        [HttpPost]
        public CommonStatus UpdateConsumableSubCategoryById(zdesk_m_item_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_sub_Cunsumable_category_by_id_sp @item_id_pk,@item_name,@catogory_id_fk", new { c.item_id_pk, c.item_name, c.catogory_id_fk });
        }
        [HttpPost]
        public CommonStatus UpdateConsumableById(zdesk_m_category_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_consumable_by_id_sp @catogory_id_pk,@category_name", new { c.catogory_id_pk, c.category_name });
        }
        [HttpPost]
        public CommonStatus UpdateConditionById(zdesk_m_condition_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_condition_by_id_sp @condition_id_pk,@condition_name", new { c.condition_id_pk, c.condition_name });
        }
        [HttpPost]
        public CommonStatus UpdateStoreLocationById(zdesk_m_stored_location_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_store_location_by_id_sp @stored_location_id_pk,@stored_location_name,@location_id_fk",
                new { c.stored_location_id_pk, c.stored_location_name, c.location_id_fk });
        }
        [HttpPost]
        public CommonStatus UpdatePublisherById(zdesk_m_publisher_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_publisher_by_id_sp @publisher_id_pk,@publisher_name", new { c.publisher_id_pk, c.publisher_name });
        }
        [HttpPost]
        public CommonStatus UpdateSoftwareNameById(zdesk_m_software_name_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_software_name_by_id_sp @soft_name_id_pk,@software_name,@publisher_id_fk,@soft_catogory_id_fk", new { c.soft_name_id_pk, c.software_name, c.publisher_id_fk, c.soft_catogory_id_fk });
        }
        [HttpPost]
        public CommonStatus UpdateSoftwareCategoryById(zdesk_m_software_category_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_software_category_by_id_sp @soft_catogory_id_pk,@soft_category_name", new { c.soft_catogory_id_pk, c.soft_category_name });
        }
        [HttpPost]
        public CommonStatus UpdateGroupById(zdesk_m_group_name_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_grouo_by_id_sp @group_id_pk,@group_name", new { c.group_id_pk, c.group_name });
        }
        [HttpPost]
        public CommonStatus UpdateAssetCategoryById(zdesk_m_asset_category_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_asset_category_by_id_sp @asset_category_id_pk,@asset_cat_name,@mapping_required", new { c.asset_category_id_pk, c.asset_cat_name, c.mapping_required });
        }
        [HttpPost]
        public CommonStatus UpdatepredefineById(zdesk_m_service_req_predefine_reply_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_pre_rply_by_id_sp @p_def_r_id_pk,@content", new { c.p_def_r_id_pk, c.content });
        }
        [HttpPost]
        public CommonStatus UpdateautoclosedById(zdesk_m_auto_closed_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_auto_closed_by_id_sp @auto_closed_id_pk,@auto_close_time", new { c.auto_closed_id_pk, c.auto_close_time });
        }
        [HttpPost]
        public CommonStatus UpdatePrefixvalueById(zdesk_m_prefix_value_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_prefix_value_by_id_sp @prefix_id_pk,@prefix_value", new { c.prefix_id_pk, c.prefix_value });
        }
        [HttpPost]
        public CommonStatus UpdateIssueTypeById(zdesk_m_issue_type_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_issue_type_by_id_sp @issue_type_id_pk,@issue_type", new { c.issue_type_id_pk, c.issue_type });
        }
        [HttpPost]
        public CommonStatus UpdatecommonsubcategoryById(zdesk_m_common_sub_category_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_common_sub_category_by_id_sp @sub_category_id_pk,@sub_category_name,@common_cat_id_fk,@keywords", new { c.sub_category_id_pk, c.sub_category_name, c.common_cat_id_fk, c.keywords });
        }
        [HttpPost]
        public CommonStatus UpdatecommoncategoryById(zdesk_m_common_category_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_common_category_by_id_sp @common_cat_id_pk,@category_name", new { c.common_cat_id_pk, c.category_name });
        }
        [HttpPost]
        public CommonStatus UpdatereasonforchangeById(zdesk_m_reason_for_change_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_reason_for_change_by_id_sp @reason_id_pk,@reason_name", new { c.reason_id_pk, c.reason_name });
        }
        [HttpPost]
        public CommonStatus UpdatependingreasonById(zdesk_m_pending_reason_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_Pending_reason_by_id_sp @pending_reason_id_pk,@pending_reason_name", new { c.pending_reason_id_pk, c.pending_reason_name });
        }
        [HttpPost]
        public CommonStatus UpdatepredefinereplyById(zdesk_m_tickets_predefine_reply_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_Predefine_rply_by_id_sp @p_def_r_id_pk,@content", new { c.p_def_r_id_pk, c.content });
        }
        [HttpPost]
        public CommonStatus UpdateclosercodeById(zdesk_m_ticket_closer_code_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_closer_code_by_id_sp @closer_id_pk,@closer_code", new { c.closer_id_pk, c.closer_code });
        }
        [HttpPost]
        public CommonStatus UpdateComponentById(zdesk_m_component_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_components_name_by_id_sp @component_id_pk,@component_name", new { c.component_id_pk, c.component_name });
        }
        [HttpPost]
        public CommonStatus UpdateBussinessUnitById(zdesk_m_business_unit_tbl v)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_bussiness_unit_by_id_sp @business_unit_id_pk,@business_unit,@business_head", new { v.business_unit_id_pk, v.business_unit,v.business_head });
        }
        [HttpPost]
        public CommonStatus UpdateLocationNmaeById(zdesk_m_location_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_location_name_by_id_sp @location_id_pk,@location_name,@business_unit_id_fk", new { w.location_id_pk, w.location_name, w.business_unit_id_fk });
        }
        [HttpPost]
        public CommonStatus UpdateSubLocationById(zdesk_m_sub_location_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_Sub_location_name_by_id_sp @sub_location_id_pk,@sub_location,@location_Id", new { w.sub_location_id_pk, w.sub_location, w.location_Id });
        }
        [HttpPost]
        public CommonStatus UpdateKnowdlegeSubCategoryById(zdesk_m_knowledge_base_sub_category_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_know_Sub_Category_name_by_id_sp @sub_catogory_id_pk,@sub_category_name,@category_id_fk", new { w.sub_catogory_id_pk, w.sub_category_name, w.category_id_fk });
        }
        [HttpPost]
        public CommonStatus UpdateKnowledgeCategoryById(zdesk_m_knowledge_base_category_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_knowledge_categroy_name_by_id_sp @catogory_id_pk,@category_name", new { w.catogory_id_pk, w.category_name });
        }

        [HttpPost]
        public CommonStatus UpdateFloorById(zdesk_m_floor_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_floor_by_id_sp @floor_id_pk,@floor_name", new { w.floor_id_pk, w.floor_name });
        }
        [HttpPost]
        public CommonStatus UpdatestatusById(zdesk_m_status_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_status_by_id_sp @status_id_pk,@status", new { w.status_id_pk, w.status });
        }
        [HttpPost]
        public CommonStatus UpdatriskById(zdesk_m_risk_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_risk_by_id_sp @risk_id_pk,@risk_name", new { w.risk_id_pk, w.risk_name });
        }
        [HttpPost]
        public CommonStatus UpdatesupportdepartmentById(zdesk_m_support_department_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_support_department_by_id_sp @support_dep_id_pk,@support_dep_name,@support_dep_head", new { w.support_dep_id_pk, w.support_dep_name, w.support_dep_head });
        }
        [HttpPost]
        public CommonStatus UpdatesupportdgrouptById(zdesk_m_support_department_group_tbl w)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_support_group_by_id_sp @support_group_id_pk,@support_dep_id_pk,@support_dep_group_name,@support_group_head",
                new { w.support_group_id_pk, w.support_dep_id_pk, w.support_dep_group_name, w.support_group_head });
        }
        [HttpGet]
        public zdesk_t_license_tbl GetLicense()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_t_license_tbl>("exec zdesk_t_get_license_sp");
        }
        [HttpPost]
        public CommonStatus RegisterKey(zdesk_t_license_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_apply_license_key_sp @product_code,@license_key,@license_type,@start_date,@end_date,@base_platform,@admin_license,@asset_admin_license,@technician_license,@full_suite,@lifecycle_mgmt,@support_type",
                new { t.product_code, t.license_key, t.license_type, t.start_date, t.end_date, t.base_platform, t.admin_license, t.asset_admin_license, t.standard_technician_license, t.full_suite, t.lifecycle_mgmt, t.support_type });
        }
        [HttpPost]
        public zdesk_t_license_tbl VerifyKey(zdesk_t_license_tbl t)
        {
            var db = new Database("Constr1");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_t_license_tbl>("exec zsp_verify_license_key @license_key", new { t.license_key });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_known_error_db_tbl> GetKEDBList()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_known_error_db_tbl>("exec zdesk_get_kedb_list_sp");
        }
        [HttpPost]
        public CommonStatus SoftDeleteKEDB(zdesk_m_known_error_db_tbl k)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_del_kedb_sp @kebd_id", new { k.kebd_id });
        }
        [HttpPost]
        public CommonStatus DeleteConsumableSubCategory(zdesk_m_item_tbl i)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_del_consumable_sub_category_sp @item_id_pk", new { i.item_id_pk });
        }
        [HttpPost]
        public CommonStatus InsServiceCategory(zdesk_m_service_category_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_ins_service_category_sp @category_name", new { t.category_name });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_service_category_tbl> GetServiceCategory()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_service_category_tbl>("exec zdesk_get_service_category_list_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_service_request_templete_tbl> GettempleteList()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_service_request_templete_tbl>("exec Zdesk_Proc_Get_TempleteList");
        }
        [HttpPost]
        public CommonStatus DelServiceCategory(zdesk_m_service_category_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_del_service_category_sp @service_cat_id_pk", new { t.service_cat_id_pk });
        }
        [HttpPost]
        public CommonStatus DeleteServicetemplete(zdesk_m_service_request_templete_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec [zdesk_del_service_Templete_sp] @service_req_templete_id_pk", new { t.service_req_templete_id_pk });
        }
        [HttpPost]
        public zdesk_m_service_category_tbl GetServiceCategoryById(zdesk_m_service_category_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_service_category_tbl>("exec zdesk_get_service_category_by_id_sp @service_cat_id_pk", new { t.service_cat_id_pk });
        }
        [HttpPost]
        public CommonStatus UpdateServiceCategory(zdesk_m_service_category_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_service_category_by_id_sp @service_cat_id_pk,@category_name", new { t.service_cat_id_pk, t.category_name });
        }
        [HttpPost]
        public CommonStatus InsServiceSubCategory(zdesk_m_service_sub_cat_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_ins_service_sub_category_sp @service_cat_id_fk,@sub_cat_name", new { t.service_cat_id_fk, t.sub_cat_name });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_service_sub_cat_tbl> GetServiceSubCategory()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_service_sub_cat_tbl>("exec zdesk_get_service_sub_category_list_sp");
        }
        [HttpPost]
        public CommonStatus DelServiceSubCategory(zdesk_m_service_sub_cat_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_del_service_sub_category_sp @service_sub_cat_id_pk", new { t.service_sub_cat_id_pk });
        }
        [HttpPost]
        public zdesk_m_service_sub_cat_tbl GetServiceSubCategoryById(zdesk_m_service_sub_cat_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_service_sub_cat_tbl>("exec zdesk_get_service_sub_category_by_id_sp @service_sub_cat_id_pk", new { t.service_sub_cat_id_pk });
        }
        [HttpPost]
        public CommonStatus UpdateServiceSubCategory(zdesk_m_service_sub_cat_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_upd_service_sub_category_by_id_sp @service_sub_cat_id_pk,@service_cat_id_fk, @sub_cat_name", new { t.service_sub_cat_id_pk, t.service_cat_id_fk, t.sub_cat_name });
        }
        [HttpPost]
        public IEnumerable<zdesk_m_service_sub_cat_tbl> GetServiceSubCategoryByCategory(zdesk_m_service_sub_cat_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_service_sub_cat_tbl>("exec zdesk_get_service_sub_cat_by_cat_id_sp @service_cat_id_fk", new { t.service_cat_id_fk });
        }
        [HttpPost]
        public CommonStatus InsIntent(zdesk_t_chatbot_intent_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec zdesk_bot_ins_bot_info_sp @intent_name,@intent_loc", new { c.intent_name, c.intent_loc });
        }
        [HttpGet]
        public IEnumerable<zdesk_t_chatbot_intent_tbl> GetIndents()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_t_chatbot_intent_tbl>("exec zdesk_bot_get_bot_info_sp");
        }

        [HttpPost]
        public IEnumerable<zdesk_m_asset_tag_prefix_tbl> GetAssetTagPrefixLists(zdesk_m_asset_tag_prefix_tbl c)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_asset_tag_prefix_tbl>("exec zdesk_get_asset_tag_prefix_sp @asset_tag_prefix_id_pk", new { c.asset_tag_prefix_id_pk });
        }

        [HttpPost]
        public CommonStatus InsAssetTagPrefix(zdesk_m_asset_tag_prefix_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_asset_tag_prefix_sp @business_unit_id_fk, @asset_category, @asset_tag_prefix",
            new { s.business_unit_id_fk, s.asset_category, s.asset_tag_prefix });
        }

        [HttpPost]
        public CommonStatus UpdAssetTagPrefix(zdesk_m_asset_tag_prefix_tbl s)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_upd_asset_tag_prefix_sp @asset_tag_prefix_id_pk,@business_unit_id_fk, @asset_category, @asset_tag_prefix",
            new { s.asset_tag_prefix_id_pk, s.business_unit_id_fk, s.asset_category, s.asset_tag_prefix });
        }

        //Sub Department Functions
        [HttpGet]
        public IEnumerable<zdesk_m_sub_department_tbl> GetSubDepartmentList()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_sub_department_tbl>("Exec zdesk_get_sub_department_list_sp");
        }

        [HttpPost]
        public CommonStatus DelSubDepartment(zdesk_m_sub_department_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_sub_department_by_id_sp @sub_dept_id_pk,@updated_by", new { t.sub_dept_id_pk, t.updated_by });
        }

        [HttpPost]
        public CommonStatus InsSubDepartment(zdesk_m_sub_department_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_sub_department_sp @dept_id_fk,@sub_dept_name", new { t.dept_id_fk, t.sub_dept_name });
        }
        [HttpPost]
        public zdesk_m_sub_department_tbl SubDepartmentDetails(zdesk_m_sub_department_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_sub_department_tbl>("Exec zdesk_get_sub_department_by_id_sp @sub_dept_id_pk", new { t.sub_dept_id_pk });
        }
        [HttpPost]
        public CommonStatus UpdSubDepartment(zdesk_m_sub_department_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_upd_sub_department_sp @sub_dept_id_pk,@dept_id_fk,@sub_dept_name,@updated_by", new { t.sub_dept_id_pk, t.dept_id_fk, t.sub_dept_name, t.updated_by });
        }

        //Cost Centre Functions
        [HttpGet]
        public IEnumerable<zdesk_m_cost_centre_tbl> GetCostCentreList()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_cost_centre_tbl>("Exec zdesk_get_cost_centre_list_sp");
        }

        [HttpPost]
        public CommonStatus DelCostCentre(zdesk_m_cost_centre_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_del_cost_centre_by_id_sp @cc_id_pk,@updated_by", new { t.cc_id_pk, t.updated_by });
        }

        [HttpPost]
        public CommonStatus InsCostCentre(zdesk_m_cost_centre_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_ins_cost_centre_sp @cc_name", new { t.cc_name });
        }
        [HttpPost]
        public zdesk_m_cost_centre_tbl CostCentreDetails(zdesk_m_cost_centre_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<zdesk_m_cost_centre_tbl>("Exec zdesk_get_cost_centre_by_id_sp @cc_id_pk", new { t.cc_id_pk });
        }
        [HttpPost]
        public CommonStatus UpdCostCentre(zdesk_m_cost_centre_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("Exec zdesk_upd_cost_centre_sp @cc_id_pk,@cc_name,@updated_by", new { t.cc_id_pk, t.cc_name, t.updated_by });
        }
        [HttpGet]
        public IEnumerable<zdesk_m_grade_tbl> GetGradeList()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_grade_tbl>("exec zdesk_get_grade_list_sp");
        }
        [HttpGet]
        public IEnumerable<zdesk_m_template_tbl> GetTemplate()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            var data = db.Query<zdesk_m_template_tbl>("exec zdesk_get_all_email_template_list_sp");
            return data;
        }
        [HttpPost]
        public zdesk_m_template_tbl GetTemplateForEdit(zdesk_m_template_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            var data = db.SingleOrDefault<zdesk_m_template_tbl>("exec zdesk_get_email_template_for_edit_by_is_sp @id", new { t.id });
            return data;
        }
        [HttpPost]
        public CommonStatus UpdateTemplate(zdesk_m_template_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            var data = db.SingleOrDefault<CommonStatus>("exec zdesk_upd_email_template_by_id_sp @id,@Template", new { t.id, t.Template });
            return data;
        }

        [HttpPost]
        public CommonStatus RestoreTemplate(zdesk_m_template_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            var data = db.SingleOrDefault<CommonStatus>("exec zdesk_upd_email_template_restore_by_id_sp @id", new { t.id });
            return data;
        }
        [HttpGet]
        public IEnumerable<Zdesk_m_smpt_tbl> GetSMTP()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            var data = db.Query<Zdesk_m_smpt_tbl>("exec zdesk_get_all_Smpt_list_sp");
            return data;
        }

        [HttpPost]
        public CommonStatus InsSmtp(Zdesk_m_smpt_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            var data = db.SingleOrDefault<CommonStatus>("exec zdesk_Ins_SMTP @ServiceProtocol,@FromAddress,@SmptPort,@UserName,@Password,@Islts,@Isssl", new { t.ServiceProtocol, t.FromAddress, t.SmptPort, t.UserName, t.Password, t.Islts, t.Isssl });
            return data;
        }

        [HttpPost]
        public CommonStatus SmtpDelete(Zdesk_m_smpt_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            var data = db.SingleOrDefault<CommonStatus>("exec zdesk_Delete_SMTP @Id_pk", new { t.Id_pk });
            return data;
        }
        [HttpPost]
        public CommonStatus SmtpChangeStatus(Zdesk_m_smpt_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            var data = db.SingleOrDefault<CommonStatus>("exec zdesk_StatusChange_SMTP @Id_pk", new { t.Id_pk });
            return data;
        }

        [HttpGet]
        public IEnumerable<zdesk_m_users_status_history_tbl> GetUserStatusHistory()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_users_status_history_tbl>("exec zdesk_get_user_status_history_list_sp");
        }

        [HttpPost]
        public CommonStatus uploadLogo()
        {
            string DomainName = HttpContext.Current.Request.UrlReferrer.AbsoluteUri;
            string logo = "";
            string backGround = "";
            string OrganizationName = "";
            string Address = "";
            string ContactNo = "";
            string ApplicationAdmin = "";
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {

                // Get the uploaded file from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedFilelogo"];
                var httpPostedFileBackground = HttpContext.Current.Request.Files["UploadedFilebackground"];

                if (httpPostedFile != null)
                {
                    var TempFolderPath = "~/DocFolder";
                    var DocFolderPath = TempFolderPath + "/" + "logo/";

                    if (!(Directory.Exists(HttpContext.Current.Server.MapPath(TempFolderPath))))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(TempFolderPath));
                    }

                    if (!(Directory.Exists(HttpContext.Current.Server.MapPath(DocFolderPath))))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(DocFolderPath));
                    }


                    var fileSave = HttpContext.Current.Server.MapPath(DocFolderPath);
                    var fileName = System.DateTime.Now.Millisecond + httpPostedFile.FileName;
                    var fileSavePath = Path.Combine(fileSave, fileName);
                    logo = Path.Combine(ConfigurationManager.AppSettings["APIUrl"].ToString() + "DocFolder/logo/", fileName);
                    httpPostedFile.SaveAs(fileSavePath);
                }
                if (httpPostedFileBackground != null)
                {
                    var TempFolderPath = "~/DocFolder";
                    var DocFolderPath = TempFolderPath + "/" + "logo";

                    if (!(Directory.Exists(HttpContext.Current.Server.MapPath(TempFolderPath))))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(TempFolderPath));
                    }

                    if (!(Directory.Exists(HttpContext.Current.Server.MapPath(DocFolderPath))))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(DocFolderPath));
                    }


                    var fileSave = HttpContext.Current.Server.MapPath(DocFolderPath);
                    var fileName = System.DateTime.Now.Millisecond + httpPostedFileBackground.FileName;
                    var fileSavePath = Path.Combine(fileSave, fileName);
                    backGround = Path.Combine(ConfigurationManager.AppSettings["APIUrl"].ToString() + "DocFolder/logo/", fileName);
                    httpPostedFileBackground.SaveAs(fileSavePath);
                }
            }

            OrganizationName = HttpContext.Current.Request.Form["txtOrganizationName"].ToString();
            Address = HttpContext.Current.Request.Form["Address"].ToString();
            ContactNo = HttpContext.Current.Request.Form["txtContactNo"].ToString();
            ApplicationAdmin = HttpContext.Current.Request.Form["ddlAdmin"].ToString();
            var adminId = HttpContext.Current.Request.Form["adminId"].ToString();
            var Id = HttpContext.Current.Request.Form["infoid"].ToString();

            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.SingleOrDefault<CommonStatus>("exec Proc_Zdesk_m_organization_Info_tbl @logo,@backGround,@OrganizationName,@Address,@ContactNo,@ApplicationAdmin,@adminId,@Id", new { logo, backGround, OrganizationName, Address, ContactNo, ApplicationAdmin, adminId, Id });
        }

        [HttpGet]
        public Zdesk_m_logo_tbl getlogo()
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            var data = db.SingleOrDefault<Zdesk_m_logo_tbl>("select top 1 * from Zdesk_m_organization_Info_tbl order by id desc");
            return data;
        }
        [HttpGet]
        public IEnumerable<zdesk_m_audit_trail_tbl> UserAuditLogs(zdesk_m_audit_trail_tbl t)
        {
            var db = new Database("Constr");
            db.EnableAutoSelect = false;
            return db.Query<zdesk_m_audit_trail_tbl>("exec zdesk_get_audit_User_sp");
        }
    }
}
