CREATE PROCEDURE [dbo].[Client_GetById]
	@Id int
AS
BEGIN

	SELECT Id, FirstName, LastName, Email, Phone
	FROM dbo.Client
	WHERE Id=@Id

END
