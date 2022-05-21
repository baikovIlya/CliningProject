CREATE PROCEDURE [dbo].[Client_Delete]
	@Id int

AS
BEGIN

DELETE FROM dbo.Client
WHERE Id=@Id

END
