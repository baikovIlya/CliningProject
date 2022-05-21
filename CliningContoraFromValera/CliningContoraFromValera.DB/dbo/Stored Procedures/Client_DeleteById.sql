CREATE PROCEDURE [dbo].[Client_DeleteById]
	@Id int

AS
BEGIN

DELETE FROM Client
WHERE Id=@Id

END
