CREATE PROCEDURE [dbo].[GetAllOrderServicesInfoById]
@Id int
AS
BEGIN
SELECT 
SO.Id, 
SO.OrderId, 
SO.ServiceId, 
SO.[Count], 
O.Id,
O.ClientId,
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
from dbo.[Service_Order] as SO 
join [dbo].[Order] AS O ON O.Id = SO.OrderId 
join [dbo].[Service] AS S on S.Id = SO.ServiceId 
WHERE SO.Id = @Id;
END 
