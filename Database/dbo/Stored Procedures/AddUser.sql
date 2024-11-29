CREATE PROCEDURE [dbo].[AddUser]
	@Name nvarchar(20),
	@Height int,
	@Weight int
AS
	INSERT INTO [dbo].[User] (
	[Name], 
	[Height], 
	[Weight])

	VALUES(
	@Name, 
	@Height,
	@Weight)