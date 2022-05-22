CREATE PROCEDURE [dbo].[Employee_Service_Delete]
	@Id int

AS
BEGIN

DELETE FROM dbo.Employee_Service
WHERE Id=@Id

END