CREATE PROCEDURE [dbo].[Service_Order_GetById]
	@Id int
AS
BEGIN

	SELECT Id, OrderId, ServiceId, [Count]
	FROM dbo.Service_Order
	WHERE Id=@Id

END
