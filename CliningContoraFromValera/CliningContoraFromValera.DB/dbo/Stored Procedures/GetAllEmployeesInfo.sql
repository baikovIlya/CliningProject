CREATE PROCEDURE [dbo].[GetAllEmployeesInfo]

AS
BEGIN
SELECT E.Id, E.FirstName, E.LastName, E.Phone, S.Id, S.[Name], S.[Description], S.Price,
S.CommercialPrice, S.Unit, S.ServiceTypeId, S.EstimatedTime, W.Id, W.[Name] from [dbo].[Employee] AS E
join dbo.[Employee_WorkArea] as EW on E.Id = EW.EmployeeId
join dbo.[WorkArea] as W on EW.WorkAreaId = W.id
join dbo.[Employee_Service] as ES on E.Id = ES.EmployeeId
join dbo.[Service] as S on ES.ServiceId = S.id
WHERE E.IsDeleted = 0 AND W.IsDeleted = 0 AND S.IsDeleted = 0
END
