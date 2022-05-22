CREATE PROCEDURE [dbo].[Employee_Order_Add]
	@Id int,
	@EmployeeId int,
	@OrderId int, 	
AS
BEGIN
INSERT INTO dbo.Employee_Order(
	EmployeeId,
	OrderId)

VALUES(
	@EmployeeId,
	@OrderId)
SELECT @@IDENTITY
END
