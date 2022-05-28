CREATE PROCEDURE [dbo].[GetAllOrderInfo]
AS
BEGIN
SELECT O.Id, O.[Date], O.StartTime, O.EndTime, S.[Name], C.FirstName, C.LastName, A.[Street], A.Building, A.Room, O.Price, O.[Status] from dbo.[Order] as O
join [dbo].[Client] AS C ON O.ClientId = C.Id
join [dbo].[Address] AS A ON O.Id = A.Id
join [dbo].[Employee_Order] AS EO ON O.Id = EO.OrderId
join [dbo].[Service_Order] AS SO ON O.Id = SO.OrderId
join [dbo].[Service] AS S on S.Id = SO.ServiceId
WHERE S.IsDeleted = 0 
END
