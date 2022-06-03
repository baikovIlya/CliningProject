CREATE PROCEDURE [dbo].[Order_GetAll]
AS 
BEGIN 
SELECT O.Id, O.[Date], O.StartTime, O.EstimatedEndTime, O.FinishTime, O.Price, O.[Status], O.CountOfEmployees,
O.IsCommercial, O.ClientId, O.AddressId,
C.Id, C.FirstName, C.LastName, c.Email, c.Phone, 
A.Id, A.Street, A.Building, A.Room, A.WorkAreaId,
WA.Id, WA.[Name],
S.Id, S.ServiceType, S.[Name], S.[Description], S.Price, S.CommercialPrice, S.Unit, S.EstimatedTime,
SO.Id, SO.OrderId, SO.ServiceId, SO.[Count] from dbo.[Order] as O
join dbo.Client as C on C.Id = O.ClientId
join dbo.[Address] as A on A.Id = O.AddressId
join dbo.[WorkArea] as WA on WA.Id = A.WorkAreaId
join dbo.[Service_Order] as SO on O.Id = SO.OrderId
join dbo.[Service] as S on S.Id = SO.ServiceId
WHERE (O.IsDeleted = 0)

END
