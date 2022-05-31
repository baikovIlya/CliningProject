CREATE PROCEDURE [dbo].[Employee_Service_DeleteByValue]
	@EmployeeId int,
	@ServiceId int

AS
BEGIN

DELETE FROM dbo.Employee_Service
WHERE EmployeeId = @EmployeeId AND ServiceId = @ServiceId

END