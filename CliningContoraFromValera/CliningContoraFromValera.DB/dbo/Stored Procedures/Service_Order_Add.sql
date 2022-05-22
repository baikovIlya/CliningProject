CREATE PROCEDURE [dbo].[Service_Order_Add]
	@Id int,
	@OrderId int,
	@ServiceId int, 
	@Count int
AS
BEGIN
INSERT INTO dbo.Service_Order(
	OrderId,
	ServiceId, 
	[Count])

VALUES(
	@OrderId,
	@ServiceId,
	@Count)
SELECT @@IDENTITY
END
