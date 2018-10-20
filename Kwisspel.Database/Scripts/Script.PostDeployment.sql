/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

:r .\Seed\Categories.sql
:r .\Seed\Quizzes.sql
:r .\Seed\Questions.sql
:r .\Seed\QuestionOptions.sql
:r .\Seed\QuestionsQuizzes.sql