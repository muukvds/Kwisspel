CREATE TABLE [dbo].[QuestionOptions]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [questions_id] INT NOT NULL, 
    [anwser] VARCHAR(50) NOT NULL, 
    [isAnwser] TINYINT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_QuestionOptions_Questions] FOREIGN KEY ([Questions_id]) REFERENCES [Questions]([id])
)

GO

CREATE INDEX [IX_QuestionOptions_Column] ON [dbo].[QuestionOptions] ([id])

GO

CREATE INDEX [IX_QuestionOptions_Column_1] ON [dbo].[QuestionOptions] ([Questions_id])
