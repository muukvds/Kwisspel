CREATE TABLE [dbo].[Anwsers]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Quizzes_id] INT NOT NULL, 
    [Questions_id] INT NOT NULL, 
    [QuestionOptions_id] INT NOT NULL, 
    CONSTRAINT [FK_Anwsers_Quizzes] FOREIGN KEY ([Quizzes_id]) REFERENCES [Quizzes]([id]),
    CONSTRAINT [FK_Anwsers_Questions] FOREIGN KEY ([Questions_id]) REFERENCES [Questions]([id]),
    CONSTRAINT [FK_Anwsers_QuestionOptions] FOREIGN KEY ([QuestionOptions_id]) REFERENCES [QuestionOptions]([id])
)

GO

CREATE INDEX [IX_Anwsers_Id] ON [dbo].[Anwsers] ([id])

GO

CREATE INDEX [IX_Anwsers_Quizzes] ON [dbo].[Anwsers] ([Quizzes_id])

GO

CREATE INDEX [IX_Anwsers_Questions] ON [dbo].[Anwsers] ([Questions_id])

GO

CREATE INDEX [IX_Anwsers_QuestionOptions] ON [dbo].[Anwsers] ([QuestionOptions_id])
