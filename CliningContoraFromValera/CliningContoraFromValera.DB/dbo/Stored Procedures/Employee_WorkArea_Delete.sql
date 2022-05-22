CREATE PROCEDURE [dbo].[Employee_WorkArea_Delete]
	@Id int

AS
BEGIN

DELETE FROM dbo.Employee_WorkArea
WHERE Id=@Id

END
