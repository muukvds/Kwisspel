CREATE TABLE [dbo].[Quizzes]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [name] VARCHAR(50) NOT NULL, 
    [Categories_id] INT NOT NULL, 
    CONSTRAINT [FK_Quizzes_Categories_id] FOREIGN KEY ([Categories_id]) REFERENCES [Categories]([id])
)

GO

CREATE INDEX [IX_Quizzes_Id] ON [dbo].[Quizzes] ([id])

GO

CREATE INDEX [IX_Quizzes_Categorie] ON [dbo].[Quizzes] ([Categories_id])
