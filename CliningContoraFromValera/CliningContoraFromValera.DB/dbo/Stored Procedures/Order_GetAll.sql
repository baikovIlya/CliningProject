--CREATE PROCEDURE [dbo].[Order_GetAll]
	
--AS
--BEGIN

--	SELECT Id, [Date], StartTime, EstimatedEndTime, FinishTime, Price, [Status], CountOfEmployees, IsCommercial, ClientId, AddressId
--	FROM dbo.[Order]
--	WHERE (IsDeleted = 0)

--END


CREATE PROCEDURE [dbo].[Order_GetAll]
AS 
BEGIN 
SELECT O.Id, O.[Date], O.StartTime, O.EstimatedEndTime, O.FinishTime, 
O.Price, O.[Status], O.CountOfEmployees, O.IsCommercial,
C.Id, C.FirstName, C.LastName, c.Email, c.Phone, 
A.Id, a.Street, A.Building, A.Room,
SO.Id, SO.[Count],
S.Id, S.ServiceType, S.[Name], S.[Description], s.Price, S.CommercialPrice, S.Unit, S.EstimatedTime
from dbo.[Order] as O
join dbo.Client as C on C.Id = O.ClientId
join dbo.[Address] as A on A.Id = O.AddressId
join dbo.[Service_Order] as SO on O.Id = SO.OrderId
join dbo.[Service] as S on S.Id = SO.ServiceId
WHERE (O.IsDeleted = 0)

END
