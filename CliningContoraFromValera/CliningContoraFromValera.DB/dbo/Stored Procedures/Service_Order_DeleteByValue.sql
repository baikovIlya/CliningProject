CREATE PROCEDURE [dbo].[Service_Order_DeleteByValue]
	@OrderId int,
	@ServiceId int

AS
BEGIN

DELETE FROM dbo.Service_Order
WHERE ServiceId = @ServiceId AND OrderId = @OrderId

END