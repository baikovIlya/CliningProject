CREATE PROCEDURE [dbo].[GetEmployeesInOrderByOrderId]
@OrderId int
AS
BEGIN
	  SELECT E.Id, E.FirstName, E.LastName, E.Phone From [dbo].[Employee] as E
	  join [dbo].[Employee_Order] as EO on E.Id = EO.EmployeeId
	  join [dbo].[Order] as O on EO.OrderId = O.Id
      WHERE O.Id = @OrderId
END
