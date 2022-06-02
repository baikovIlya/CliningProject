CREATE PROCEDURE [dbo].[Employee_Order_DeleteByValue]
	@EmployeeId int,
	@OrderId int

AS
BEGIN

DELETE FROM dbo.Employee_Order
WHERE EmployeeId = @EmployeeId AND OrderId = @OrderId

END