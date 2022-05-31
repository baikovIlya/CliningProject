CREATE PROCEDURE [dbo].[Employee_WorkArea_DeleteByValue]
	@EmployeeId int,
	@WorkAreaId int

AS
BEGIN

DELETE FROM dbo.Employee_WorkArea
WHERE EmployeeId = @EmployeeId AND WorkAreaId = @WorkAreaId

END