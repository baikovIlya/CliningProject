CREATE PROCEDURE [dbo].[Order_Delete]
	@Id int

AS
BEGIN

UPDATE dbo.[Order]
SET IsDeleted = 1
WHERE Id=@Id

END

