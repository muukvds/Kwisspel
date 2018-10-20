SET IDENTITY_INSERT Questions ON

MERGE INTO dbo.Questions AS Target  
USING (values 
	(1, '2+3=',1),
	(2, '2+2=',1),
	(3, '5+5=',1),
	(4, '2x4=',1),
	(5, '4323x20=',1),
	(6, 'In welk jaar begin de tweede wereld oorlog?',2),
	(7, 'In welk jaar begin de eerste wereld oorlog?',2),
	(8, 'Wanneer is america ondekt?',2),
	(9, 'Wie bouwde de piramides?',2),
	(10, 'Welk ras heeft de stargate gebouwd?',2),
	(11, 'Kan een wormhole twee kanten op?',3),
	(12, 'voor welk element staat Fe?',3),
	(13, 'Voor welk element staat H2o?',3),
	(14, 'Welk element moet ijzen in aanraking komen om te roesten?',3),
	(15, 'Wat versneld het roest proces?',3),
	(16, 'biologie vraag 1',4),
	(17, 'biologie vraag 2',4),
	(18, 'biologie vraag 3',4),
	(19, 'boilogie vraag 4',4),
	(20, 'boilogie vraag 5',4)
) AS Source (id, question,Categories_id)  
ON Target.id = Source.id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (id, question,Categories_id)  
	VALUES (id, question,Categories_id)  
WHEN MATCHED THEN
	UPDATE SET
		question = Source.question,
		Categories_id = Source.Categories_id;
        
SET IDENTITY_INSERT Questions OFF