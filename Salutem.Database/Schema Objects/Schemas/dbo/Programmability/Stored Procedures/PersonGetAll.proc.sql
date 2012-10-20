CREATE PROCEDURE [dbo].[PersonGetAll]
	@WithDeleted bit = 0
AS
	if @WithDeleted = 1
		SELECT * from Person order by CrDt;
	else
		select * from Person where Deleted = 0 order by CrDt;
RETURN 0