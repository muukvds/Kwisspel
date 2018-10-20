CREATE TABLE [dbo].[Questions]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [question] VARCHAR(255) NOT NULL,
	[Categories_id] INT NOT NULL, 
	CONSTRAINT [FK_Quizzes_Categories_id] FOREIGN KEY ([Categories_id]) REFERENCES [Categories]([id])
)

GO

CREATE INDEX [IX_Questions_Categorie] ON [dbo].[Questions] ([Categories_id])


GO

CREATE INDEX [IX_Questions_Id] ON [dbo].[Questions] ([id])
