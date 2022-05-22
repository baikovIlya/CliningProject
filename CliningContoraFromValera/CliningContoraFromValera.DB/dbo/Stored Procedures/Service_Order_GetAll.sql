CREATE PROCEDURE [dbo].[Service_Order_GetAll]
	
AS
BEGIN

	SELECT Id, OrderId, ServiceId, [Count]
	FROM dbo.Service_Order

END

