CREATE PROCEDURE [dbo].[AccessGetByUserAndPassword]
	@UserIdentifier varchar(150),
	@PasswordHash varchar(150) = NULL
AS
	SELECT * from Access where UserIdentifier = @UserIdentifier and PasswordHash = ISNULL(@PasswordHash, PasswordHash);
RETURN 0