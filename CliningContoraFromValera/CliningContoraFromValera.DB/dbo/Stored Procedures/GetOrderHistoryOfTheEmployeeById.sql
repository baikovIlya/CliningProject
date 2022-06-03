CREATE PROCEDURE [dbo].[GetOrderHistoryOfTheEmployeeById]
	@Id int
AS
BEGIN
	SELECT E.Id, E.FirstName, E.LastName,E.Phone, O.Id, O.[Date], O.StartTime, O.EstimatedEndTime, O.FinishTime,
	O.Price, O.[Status], O.CountOfEmployees, O.IsCommercial, O.ClientId, O.AddressId, C.Id, C.FirstName, C.LastName,
	C.Email, C.Phone, A.Id, A.Street, A.Building, A.Room, A.WorkAreaId, W.Id, W.[Name], S.Id, S.ServiceType, S.ServiceName,
	S.[Description], S.ServicePrice, S.CommercialPrice, S.Unit, S.EstimatedTime, SO.Id, SO.OrderId, SO.ServiceId, SO.[Count] FROM [dbo].[Employee] AS E
	join [dbo].[Employee_Order] AS EO ON E.Id = EO.EmployeeId
	join [dbo].[Order] AS O ON EO.OrderId = O.Id
	join [dbo].[Client] AS C ON O.ClientId = C.Id
	join [dbo].[Address] AS A ON O.AddressId = A.Id
	join [dbo].[WorkArea] AS W ON A.WorkAreaId = W.id
	join [dbo].[Service_Order] AS SO ON O.Id = SO.OrderId
	join [dbo].[Service] AS S ON SO.ServiceId = S.Id
	WHERE E.IsDeleted = 0 AND E.Id = @Id
END
