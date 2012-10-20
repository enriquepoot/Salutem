CREATE PROCEDURE [dbo].[AccessUpdate]
	@ID uniqueidentifier, 
	@UserIdentifier varchar(150),
	@PasswordHash varchar(150),
	@PasswordSalt varchar(150),
	@PersonID uniqueidentifier,
	@Deleted bit = null
AS
	if @ID = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER)
		begin
			declare @newid uniqueidentifier = NEWID();
			insert into Access (ID, UserIdentifier, PasswordHash, PasswordSalt, PersonID) 
			values(@newid, @UserIdentifier, @PasswordHash, @PasswordSalt, @PersonID);
			select @newid;
		end
	else
		begin
			update Person set UserIdentifier = @UserIdentifier, PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt, PersonID = @PersonID, 
			MdDt = GETDATE(), Deleted = ISNULL(@Deleted, Deleted) where ID = @ID;
			select @ID;
		end
RETURN 0