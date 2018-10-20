MERGE INTO dbo.QuestionsQuizzes AS Target  
USING (values 
	(1,1),
	(1,2),
	(1,3),
	(1,4),
	(1,7),
	(1,20),
	(2,10),
	(2,18),
	(2,17),
	(2,16),
	(2,13),
	(2,8),
	(2,3),
	(2,2),
	(3,5),
	(3,18),
	(3,6),
	(3,9),
	(3,11),
	(3,12),
	(3,14),
	(3,15),
	(3,19),
	(3,1),
	(3,4)
) AS Source (Quizzes_id, Questions_id)  
ON Target.Questions_id = Source.Questions_id AND Target.Quizzes_id = Source.Quizzes_id
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (Questions_id, Quizzes_id)  
	VALUES (Questions_id, Quizzes_id);
        