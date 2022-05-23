CREATE PROCEDURE [dbo].[GetAllEmployeesSkills]
AS
BEGIN
	SELECT  E.Id, E.FirstName, E.LastName, S.Name,S.CommercialPrice from dbo.[Employee] as E
join dbo.[Employee_Service] as ES on E.Id = ES.EmployeeId
join dbo.[Service] as S on ES.EmployeeId = S.id
WHERE (E.IsDeleted = 0)
END
