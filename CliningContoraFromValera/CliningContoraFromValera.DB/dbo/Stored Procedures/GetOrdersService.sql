CREATE PROCEDURE [dbo].[GetOrdersService]
	@Id int
AS
BEGIN
SELECT O.Id, O.[Date], O.StartTime, O.EstimatedEndTime, O.FinishTime, O.Price, O.[Status], 
O.CountOfEmployees, O.IsCommercial,
S.Id, S.ServiceType, S.[Name], S.[Description], S.Price, S.CommercialPrice, S.Unit, S.EstimatedTime, 
 SO.Id, So.OrderId, SO.ServiceId, SO.[Count]
from dbo.[Order] as O
join dbo.Service_Order as SO on O.Id = SO.OrderId
join dbo.[Service] as S on SO.ServiceId = S.Id
WHERE O.IsDeleted = 0 AND O.Id=@Id
END
