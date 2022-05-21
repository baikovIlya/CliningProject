CREATE PROCEDURE [dbo].[Service_Order_Update]
	@Id int,
	@OrderId int,
	@ServiceId int, 
	@Count int

AS
BEGIN

UPDATE dbo.Service_Order
SET OrderId = @OrderId,
    ServiceId = @ServiceId, 
	[Count] = @Count
WHERE Id = @Id

END
