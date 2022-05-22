CREATE PROCEDURE [dbo].[Employee_WorkArea_GetAll]
	
AS
BEGIN

	SELECT Id, WorkAreaId, EmployeeId
	FROM dbo.Employee_WorkArea

END
