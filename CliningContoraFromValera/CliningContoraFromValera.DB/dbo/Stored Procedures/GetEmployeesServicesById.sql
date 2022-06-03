CREATE PROCEDURE [dbo].[GetEmployeesServicesById]
	@Id int
AS
BEGIN
SELECT E.Id, E.FirstName, E.LastName, E.Phone, S.Id, S.ServiceType, S.[Name], S.[Description], S.Price,
S.CommercialPrice, S.Unit, S.EstimatedTime from [dbo].[Employee] AS E
join dbo.[Employee_Service] as ES on E.Id = ES.EmployeeId
join dbo.[Service] as S on ES.ServiceId = S.id
WHERE E.IsDeleted = 0 AND S.IsDeleted = 0 AND E.Id = @Id
END
