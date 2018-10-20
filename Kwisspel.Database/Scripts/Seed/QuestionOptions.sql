SET IDENTITY_INSERT QuestionOptions ON

MERGE INTO dbo.QuestionOptions AS Target  
USING (values 
	(1,1, '5',1),
	(2,1, '6',0),
	(3,1, '3',0),
	(4,2, '4',1),
	(5,2, '3',0),
	(6,2, '6',0),
	(7,3, '10',1),
	(8,3, '6',0),
	(9,3, '12',0),
	(10,3, '32',0),
	(11,4, '6',1),
	(12,4, '32',0),
	(13,4, '2',0),
	(14,5, 'Ga ik niet berekenen',1),
	(15,5, 'Fout',0),
	(16,6, '1939',1),
	(17,6, '1943',0),
	(18,6, '1938',0),
	(19,6, '1940',0),
	(20,7, '1914',1),
	(21,7, '1915',0),
	(22,7, '1938',0),
	(23,8, '1492',1),
	(24,8, '1800',0),
	(25,8, '1682',0),
	(26,9, 'Aliens',1),
	(27,9, 'Slaven',1),
	(28,9, 'God',0),
	(29,10, 'Ancients',1),
	(30,10, 'Goa uld',0),
	(31,10, 'Asgard',0),
	(32,10, 'Jafa',0),
	(33,11, 'ja',0),
	(34,11, 'nee',1),
	(35,12, 'Ijzer',1),
	(36,12, 'Staal',0),
	(37,12, 'Koper',0),
	(38,13, 'Water',1),
	(39,13, 'Waterstof',0),
	(40,13, 'Zuurstof',0),
	(41,13, 'Messing',0),
	(42,14, 'Water',0),
	(43,14, 'Zuurstof',0),
	(44,15, 'Water',1),
	(45,15, 'Stikstof',0),
	(46,15, 'Koud',0),
	(47,15, 'Warmte',1),
	(48,16, 'Goed',1),
	(49,16, 'Fout',0),
	(50,17, 'Goed',1),
	(51,17, 'Fout',0),
	(52,18, 'Goed',1),
	(53,18, 'Fout',0),
	(54,19, 'Goed',1),
	(55,19, 'Fout',0),
	(56,20, 'Goed',1),
	(57,20, 'Fout',0)
) AS Source (id, Questions_id,anwser,isAnwser)  
ON Target.id = Source.id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (id, Questions_id,anwser,isAnwser)  
	VALUES (id, Questions_id,anwser,isAnwser)  
WHEN MATCHED THEN
	UPDATE SET
		Questions_id = Source.Questions_id,
		anwser = Source.anwser,
		isAnwser = Source.isAnwser;
        
SET IDENTITY_INSERT QuestionOptions OFF