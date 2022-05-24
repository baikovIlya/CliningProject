CREATE PROCEDURE [dbo].[Employee_WorkArea_DeleteById]
	@Id int

AS
BEGIN

DELETE FROM dbo.Employee_WorkArea
WHERE Id=@Id

END
