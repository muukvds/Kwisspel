CREATE TABLE [dbo].[Questions]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [question] VARCHAR(50) NOT NULL
)

GO

CREATE INDEX [IX_Questions_Id] ON [dbo].[Questions] ([id])
