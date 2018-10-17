CREATE TABLE [dbo].[QuestionsQuizzes]
(
	[Questions_id] INT NOT NULL PRIMARY KEY,
	[Quizzes_id] INT NOT NULL PRIMARY KEY, 
    CONSTRAINT [FK_QuestionsQuizzes_Questions] FOREIGN KEY ([Questions_id]) REFERENCES [Questions]([id]),
    CONSTRAINT [FK_QuestionsQuizzes_Quizzes] FOREIGN KEY ([Quizzes_id]) REFERENCES [Quizzes]([id])
)
