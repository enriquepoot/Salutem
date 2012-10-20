CREATE PROCEDURE [dbo].[PersonGetById]
	@Id uniqueidentifier
AS
	SELECT * from Person where ID = @Id;
RETURN 0