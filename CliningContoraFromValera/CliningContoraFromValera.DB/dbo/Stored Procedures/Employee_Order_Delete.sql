CREATE PROCEDURE [dbo].[Employee_Order_Delete]
	@Id int

AS
BEGIN

DELETE FROM dbo.Employee_Order
WHERE Id=@Id

END
