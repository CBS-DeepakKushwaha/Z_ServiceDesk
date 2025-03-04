USE [zdesknew]
GO
/****** Object:  StoredProcedure [dbo].[zdesk_get_problrm_by_id_sp]    Script Date: 01-07-2021 22:34:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[zdesk_get_problrm_by_id_sp] 12  (
								                 @promblems_id_pk int    
											     )

as 
begin
set nocount on
							select  
							          subject
							        ,submitted_by_id
									,common_cat_id_pk
									,sub_category_id_pk 
									,business_unit_id_pk
									,location_id_fk
									,impact_id_pk
									,urgency_id_fk
									,support_dep_id_pk
									,support_group_id_fk 
									,assign_to 
									,asset_id_pk   
									,problem_id_fk 
									,due_date 
									,description 
									,user_id_fk 
									,department_id_fk 
									,priority_id_fk 
									,asset_id_pk 
					from zdesk_m_problems_tbl
					  Where is_active=1 and promblems_id_pk=@promblems_id_pk
set nocount off
end

