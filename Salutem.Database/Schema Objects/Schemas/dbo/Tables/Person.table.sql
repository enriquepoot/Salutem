CREATE TABLE [dbo].[Person]
(
	[ID] uniqueidentifier PRIMARY KEY DEFAULT NEWID(), 
	[Name] varchar(100) NOT NULL,
	[LastName] varchar(100) NOT NULL,
	[CrDt] datetime NOT NULL default getdate(),
	[MdDt] datetime NOT NULL default getdate(),
	[Deleted] bit Not Null default 0
)
