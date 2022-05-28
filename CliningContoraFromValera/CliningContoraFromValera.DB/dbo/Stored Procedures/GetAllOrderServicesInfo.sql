CREATE PROCEDURE [dbo].[GetAllOrderServicesInfo]
AS
BEGIN
SELECT O.ClientId,
O.[Date],
O.StartTime,
O.EstimatedEndTime,
O.FinishTime, 
O.Price, 
O.[Status],
O.AddressId, 
O.CountOfEmployees,
O.IsCommercial, 
S.Id,
S.[Name], 
S.Price, 
S.CommercialPrice, 
S.Unit, 
S.ServiceTypeId, 
S.EstimatedTime
from dbo.[Order] as O 
join [dbo].[Service_Order] AS SO ON O.Id = SO.OrderId 
join [dbo].[Service] AS S on S.Id = SO.ServiceId 
END 
