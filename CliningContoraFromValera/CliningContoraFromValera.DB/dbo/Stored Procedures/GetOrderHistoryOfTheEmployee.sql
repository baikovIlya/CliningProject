CREATE PROCEDURE [dbo].[GetOrderHistoryOfTheEmployee]
	@Id int
AS
BEGIN
	SELECT E.Id, E.FirstName, E.LastName, O.[Date], ST.[Name], S.[Name], SO.[Count], O.Price, C.FirstName, C.LastName,
	W.[Name], A.Street, A.Building, A.Room, O.[Status] FROM [dbo].[Employee] AS E
	join [dbo].[Employee_Order] AS EO ON E.Id = EO.EmployeeId
	join [dbo].[Order] AS O ON EO.OrderId = O.Id
	join [dbo].[Client] AS C ON O.ClientId = C.Id
	join [dbo].[Address] AS A ON O.AddressId = A.Id
	join [dbo].[WorkArea] AS W ON A.WorkAreaId = W.id
	join [dbo].[Service_Order] AS SO ON O.Id = SO.OrderId
	join [dbo].[Service] AS S ON SO.ServiceId = S.Id
	join [dbo].[ServiceType] AS ST ON S.Id = ST.Id
	WHERE O.IsDeleted = 0 AND (E.Id = @Id)
END
