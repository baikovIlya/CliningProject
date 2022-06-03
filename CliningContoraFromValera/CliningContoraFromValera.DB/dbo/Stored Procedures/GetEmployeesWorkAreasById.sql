CREATE PROCEDURE [dbo].[GetEmployeesWorkAreasById]
	@Id int
AS
BEGIN
SELECT E.Id, E.FirstName, E.LastName, E.Phone, W.Id, W.[Name] from [dbo].[Employee] AS E
join dbo.[Employee_WorkArea] as EW on E.Id = EW.EmployeeId
join dbo.[WorkArea] as W on EW.WorkAreaId = W.id
WHERE E.IsDeleted = 0 AND W.IsDeleted = 0 AND E.Id = @Id
END
