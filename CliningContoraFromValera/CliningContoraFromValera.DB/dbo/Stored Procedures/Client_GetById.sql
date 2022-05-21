CREATE PROCEDURE [dbo].[Client_GetById]
	@Id int
AS
BEGIN

	SELECT Id, FirstName, LastName, Email, Phone
	FROM Client
	WHERE Id=@Id

END
