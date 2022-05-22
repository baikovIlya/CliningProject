CREATE PROCEDURE [dbo].[WorkArea_Delete]
	@Id int

AS
BEGIN

DELETE FROM dbo.WorkArea
WHERE Id=@Id

END
