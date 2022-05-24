CREATE PROCEDURE [dbo].[Order_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.[Order]
SET IsDeleted = 1
WHERE Id=@Id

END

