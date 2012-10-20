CREATE TABLE [dbo].[Access]
(
	ID uniqueidentifier primary key default newid(), 
	UserIdentifier varchar(150) not null,
	PasswordHash varchar(150) not null,
	PasswordSalt varchar(150) not null,
	PersonID uniqueidentifier not null references Person(ID),
	[CrDt] datetime NOT NULL default getdate(),
	[MdDt] datetime NOT NULL default getdate(),
	[Deleted] bit Not Null default 0
)
