CREATE PROCEDURE [dbo].[Employee_WorkArea_Add]
	@WorkAreaId int,
	@EmployeeId int
AS
BEGIN
INSERT INTO dbo.Employee_WorkArea(
	WorkAreaId,
	EmployeeId)

VALUES(
	@WorkAreaId,
	@EmployeeId)
SELECT @@IDENTITY
END
