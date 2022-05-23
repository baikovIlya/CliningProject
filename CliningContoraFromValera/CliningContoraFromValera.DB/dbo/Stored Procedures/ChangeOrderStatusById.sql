CREATE PROCEDURE [dbo].[Order_GetById]
	@Id int,
	@NewStatus nvarchar(50)
AS
BEGIN

	UPDATE dbo.[Order]
	SET [Status] = NewStatus
	WHERE Id=@Id

END