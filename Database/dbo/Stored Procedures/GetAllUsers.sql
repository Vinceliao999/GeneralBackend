CREATE PROCEDURE [dbo].[GetAllUsers]
AS
	SELECT [Id], [Name], [Height], [Weight]
	FROM [dbo].[User]