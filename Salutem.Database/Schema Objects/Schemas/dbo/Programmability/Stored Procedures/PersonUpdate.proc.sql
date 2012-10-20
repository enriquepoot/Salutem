CREATE PROCEDURE [dbo].[PersonUpdate]
	@ID uniqueidentifier, 
	@Name varchar(100),
	@LastName varchar(100),
	@Deleted bit = null
AS
	if @ID = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER)
		begin
			declare @newid uniqueidentifier = NEWID();
			insert into Person (ID, Name, LastName) values(@newid, @Name, @LastName);
			select @newid;
		end
	else
		begin
			update Person set Name = @Name, LastName = @LastName, MdDt = GETDATE(), Deleted = ISNULL(@Deleted, Deleted) where ID = @ID;
			select @ID;
		end
RETURN 0