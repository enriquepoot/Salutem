CREATE PROCEDURE [dbo].[AccessGetById]
	@Id uniqueidentifier
AS
	SELECT * from Access where ID = @Id;
RETURN 0