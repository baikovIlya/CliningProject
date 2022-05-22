CREATE PROCEDURE [dbo].[Employee_Order_GetAll]
	
AS
BEGIN

	SELECT Id, EmployeeId, OrderId
	FROM dbo.Employee_Order

END
