CREATE PROCEDURE [dbo].[Client_GetAll]
	
AS
BEGIN

	SELECT Id, FirstName, LastName, Email, Phone
	FROM dbo.Client
	WHERE (IsDeleted = 0)

END
