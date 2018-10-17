CREATE TABLE [dbo].[Quizzes]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [name] VARCHAR(50) NOT NULL, 
    [Categorie_id] INT NOT NULL, 
    CONSTRAINT [FK_Quizzes_Categorie_id] FOREIGN KEY ([Categorie_id]) REFERENCES [Categorie]([id])
)

GO

CREATE INDEX [IX_Quizzes_Id] ON [dbo].[Quizzes] ([id])

GO

CREATE INDEX [IX_Quizzes_Categorie] ON [dbo].[Quizzes] ([Categorie_id])
