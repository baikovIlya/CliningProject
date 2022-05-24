CREATE PROCEDURE [dbo].[Service_Order_DeleteById]
	@Id int

AS
BEGIN

DELETE FROM dbo.Service_Order
WHERE Id=@Id

END