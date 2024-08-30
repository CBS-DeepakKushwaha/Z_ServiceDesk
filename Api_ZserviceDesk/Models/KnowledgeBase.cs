using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_ZserviceDesk.Models
{
    public class KnowledgeBase
    {
    }
    public partial class zdesk_m_knowledge_base_category_tbl
    {
        public Nullable<int> catogory_id_pk { get; set; }
        public Nullable<int> category_id_fk { get; set; }
        public string category_name { get; set; }

    }
    public partial class zdesk_m_knowledge_base_sub_category_tbl
    {
        public Nullable<int> sub_catogory_id_pk { get; set; }
        public Nullable<int> category_id_fk { get; set; }
        public string Category { get; set; }
        public string sub_category_name { get; set; }
        public Nullable<int> fst_approver { get; set; }
        public Nullable<int> snd_approver { get; set; }
        public Nullable<int> trd_approver { get; set; }
        public string Name { get; set; }
        public string category_name { get; set; }

    }
    public partial class zdesk_m_knowledge_base_solutions_tbl
    {
        public Nullable<int> solution_id_pk { get; set; }
        public Nullable<int> category_id_fk { get; set; }
        public Nullable<int> sub_catogory_id_fk { get; set; }
        public Nullable<int> sub_category_id_fk { get; set; }
        public Nullable<int> ticket_id_fk { get; set; }
        public Nullable<int> problem_id_fk { get; set; }
        public Nullable<int> updated_by { get; set; }
        public Nullable<int> is_user { get; set; }
        public Nullable<int> is_tecnician { get; set; }
        public string solution_title { get; set; }
        public string support_dep_group { get; set; }
        public string contents { get; set; }
        public string category_name { get; set; }
        public string sub_category_name { get; set; }
        public string keywords { get; set; }
        public string Approval_Status { get; set; }
        public string name { get; set; }
        public string url{ get; set; }
        public string file { get; set; }
        public Nullable<int> approver_id_fk { get; set; }
        public Nullable<int> approver_status_id_fk { get; set; }

        //-----------------------------------------------------------------
        // Updates on 18-06-2021 By Umesh
        //-----------------------------------------------------------------
        public int review_required { get; set; }
        public int reviewer1_id_pk { get; set; }
        public int reviewer1_status_id_fk { get; set; }
        public int reviewer2_id_pk { get; set; }
        public int reviewer2_status_id_fk { get; set; }
        public int reviewer3_id_pk { get; set; }
        public int reviewer3_status_id_fk { get; set; }
        public int approval_required { get; set; }
        public int approver1_id_fk { get; set; }
        public int approver1_status_id_fk { get; set; }
        public int approver2_id_fk { get; set; }
        public int approver2_status_id_fk { get; set; }
        public int approver3_id_fk { get; set; }
        public int approver3_status_id_fk { get; set; }
        public int status { get; set; }
        public string _Status { get; set; }
        public string assigned_group { get; set; }
        public int owner_id_fk { get; set; }
        public string  owner { get; set; }
    }

    public partial class zdesk_t_knowledge_base_approver_status_tbl
    {
        public Nullable<int> category_id_fk { get; set; }
        public Nullable<int> sub_catogory_id_fk { get; set; }
        public Nullable<int> approver_id_fk { get; set; }
        public Nullable<int> approver_status_id_fk { get; set; }
        public Nullable<int> kb_approver_cat_sub_id_fk { get; set; }
        public string name { get; set; }

    }

    public class zdesk_m_org_documents_tbl
    {
        public int org_documents_id_pk { get; set; }
        public string document_name { get; set; }
        public string document_description { get; set; }
        public string document_docPath { get; set; }
        public int document_category_id_fk { get; set; }
        public int document_sub_category_id_fk { get; set; }
        public string document_FileName { get; set; }
        public string document_category_name { get; set; }
        public string document_sub_category_name { get; set; }
        public string keywords { get; set; }
    }
    public class zdesk_m_document_sub_category_tbl
    {
        public int document_sub_category_id_pk { get; set; }
        public string document_sub_category { get; set; }
        public int document_category_id_fk { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int updated_by { get; set; }

    }

    public class zdesk_m_document_category_tbl
    {
        public int document_category_id_pk { get; set; }
        public string document_category { get; set; }
        public int is_active { get; set; }
        public Nullable<DateTime> created_date { get; set; }
        public Nullable<DateTime> updated_date { get; set; }
        public int updated_by { get; set; }
    }
}