CREATE PROCEDURE [dbo].[Order_GetAll]
AS 
BEGIN 
SELECT O.Id, O.[Date], O.StartTime, O.EstimatedEndTime, O.FinishTime, O.Price, O.[Status], O.CountOfEmployees,
O.IsCommercial, O.ClientId, O.AddressId,
C.Id, C.FirstName, C.LastName, c.Email, c.Phone, 
A.Id, A.Street, A.Building, A.Room, A.WorkAreaId,
WA.Id, WA.[Name] from dbo.[Order] as O
join dbo.Client as C on C.Id = O.ClientId
join dbo.[Address] as A on A.Id = O.AddressId
join dbo.[WorkArea] as WA on WA.Id = A.WorkAreaId
WHERE (O.IsDeleted = 0)

END
