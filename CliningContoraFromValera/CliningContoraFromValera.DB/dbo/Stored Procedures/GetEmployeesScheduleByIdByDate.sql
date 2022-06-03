CREATE PROCEDURE [dbo].[GetEmployeesScheduleByIdByDate]
@EmployeeId int,
@Date date
AS
BEGIN
	  SELECT O.Id, O.[Date], O.StartTime,  O.EstimatedEndTime, O.FinishTime, O.Price, O.[Status], O.CountOfEmployees,
	  O.IsCommercial, O.ClientId, O.AddressId, A.Id, A.Street, A.Building, A.Room, A.WorkAreaId FROM [dbo].[Order] AS O
	  join dbo.[Employee_Order] as EO on EO.OrderId = O.Id
	  join dbo.Address as A on A.Id = O.AddressId
      WHERE EO.EmployeeId = @EmployeeId AND O.[Date] = @Date AND O.IsDeleted = 0
END
