SET IDENTITY_INSERT Categories ON

MERGE INTO dbo.Categories AS Target  
USING (values 
	(1, 'Rekenen'),
	(2, 'Geschiedenis'),
	(3, 'Natuurkunde'),
	(4, 'Biologie')
) AS Source (id, name)  
ON Target.id = Source.id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (id, name)  
	VALUES (id, name)  
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.name;
        
SET IDENTITY_INSERT Categories OFF