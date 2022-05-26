CREATE PROCEDURE [dbo].[GetAllEmployeesSkills]

AS
BEGIN
	SELECT  E.Id, E.FirstName, E.LastName, S.[Name], S.[Description] from dbo.[Employee] as E
join dbo.[Employee_Service] as ES on E.Id = ES.EmployeeId
join dbo.[Service] as S on ES.ServiceId = S.Id
WHERE E.IsDeleted = 0 AND S.IsDeleted = 0
END
