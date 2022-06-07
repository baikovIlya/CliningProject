CREATE PROCEDURE [dbo].[GetOrderHistoryOfTheEmployeeById]
	@EmployeeId int
AS
BEGIN
SELECT O.Id, O.[Date], O.StartTime,  O.EstimatedEndTime, O.FinishTime, O.Price, O.[Status], O.CountOfEmployees,
	  O.IsCommercial, O.ClientId, O.AddressId, A.Id, A.Street, A.Building, A.Room, A.WorkAreaId, W.Id, W.[Name] FROM [dbo].[Order] AS O
	  join dbo.[Employee_Order] as EO on EO.OrderId = O.Id
	  join dbo.[Address] as A on A.Id = O.AddressId
	  join [dbo].[WorkArea] AS W ON A.WorkAreaId = W.id
      WHERE EO.EmployeeId = @EmployeeId AND O.IsDeleted = 0
END


