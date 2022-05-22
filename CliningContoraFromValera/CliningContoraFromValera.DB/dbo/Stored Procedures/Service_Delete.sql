CREATE PROCEDURE [dbo].[Service_Delete]
	@Id int
AS
BEGIN

DELETE FROM dbo.[Service]
WHERE Id=@Id

END
