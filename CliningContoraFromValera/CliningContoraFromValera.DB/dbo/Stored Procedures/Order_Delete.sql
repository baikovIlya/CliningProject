CREATE PROCEDURE [dbo].[Order_Delete]
	@Id int

AS
BEGIN

DELETE FROM dbo.[Order]
WHERE Id=@Id

END

