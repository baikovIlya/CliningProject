CREATE PROCEDURE [dbo].[Service_Order_Delete]
	@Id int

AS
BEGIN

DELETE FROM dbo.Service_Order
WHERE Id=@Id

END