CREATE PROCEDURE [dbo].[Employee_Service_GetAll]
	
AS
BEGIN

	SELECT Id, EmployeeId, ServiceId
	FROM dbo.Employee_Service

END