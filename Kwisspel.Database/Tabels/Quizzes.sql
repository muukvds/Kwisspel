CREATE TABLE [dbo].[Quizzes]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] VARCHAR(50) NOT NULL, 
    )
GO

CREATE INDEX [IX_Quizzes_Id] ON [dbo].[Quizzes] ([id])