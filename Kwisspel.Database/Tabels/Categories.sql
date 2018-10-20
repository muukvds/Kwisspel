CREATE TABLE [dbo].[Categories]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] VARCHAR(50) NOT NULL
)

GO

CREATE INDEX [IX_Categories_Id] ON [dbo].[Categories] ([id])
