CREATE TABLE [dbo].[QuestionsQuizzes]
(
	[Questions_id] INT NOT NULL,
	[Quizzes_id] INT NOT NULL,
	PRIMARY KEY (Questions_id, Quizzes_id),
    CONSTRAINT [FK_QuestionsQuizzes_Questions] FOREIGN KEY ([Questions_id]) REFERENCES [Questions]([id]),
    CONSTRAINT [FK_QuestionsQuizzes_Quizzes] FOREIGN KEY ([Quizzes_id]) REFERENCES [Quizzes]([id])
)
