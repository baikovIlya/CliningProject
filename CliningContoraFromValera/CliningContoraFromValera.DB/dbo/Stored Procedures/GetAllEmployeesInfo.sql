CREATE PROCEDURE [dbo].[GetAllEmployeesInfo]

AS
BEGIN
	SELECT E.Id, E.FirstName, E.LastName, E.Phone, W.[Name] from dbo.[Employee] as E
join dbo.[Employee_WorkArea] as WA on E.Id = WA.EmployeeId
join dbo.[WorkArea] as W on WA.WorkAreaId = W.id
WHERE E.IsDeleted = 0 AND W.IsDeleted = 0
END
