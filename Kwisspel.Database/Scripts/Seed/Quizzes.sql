SET IDENTITY_INSERT Quizzes ON

MERGE INTO dbo.Quizzes AS Target  
USING (values 
	(1, 'Quiz 1'),
	(2, 'Quiz 2'),
	(3, 'Quiz 3')
) AS Source (id, name)  
ON Target.id = Source.id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (id, name)  
	VALUES (id, name)  
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.name;
        
SET IDENTITY_INSERT Quizzes OFF