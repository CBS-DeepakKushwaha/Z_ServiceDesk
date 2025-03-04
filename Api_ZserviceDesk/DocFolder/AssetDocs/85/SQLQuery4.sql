USE [zdesknew]
GO
/****** Object:  StoredProcedure [dbo].[zdesk_upd_symptom_by_id_sp]    Script Date: 08-07-2021 22:08:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		UMESH
-- Create date: 08-07-2021 21:55
-- Description:	Update symptoms by problem id
-- =============================================
ALTER PROCEDURE [dbo].[zdesk_upd_symptom_by_id_sp](
														@promblems_id_pk int,
														@symptoms varchar(max)
												   )
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS(SELECT promblems_id_pk FROM zdesk_m_problems_tbl WHERE promblems_id_pk = @promblems_id_pk AND is_active = 1)
		BEGIN
			UPDATE zdesk_m_problems_tbl
			SET
				symptoms = @symptoms
			WHERE
				promblems_id_pk = @promblems_id_pk
			SELECT 'Symptom updated successfully.' AS 'status',1 AS status_id
		END
	ELSE
		BEGIN
			SELECT 'Problem could not be found.' AS 'status',0 AS status_id
		END
END
