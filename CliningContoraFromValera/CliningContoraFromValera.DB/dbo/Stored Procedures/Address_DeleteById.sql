CREATE PROCEDURE [dbo].[Address_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.[Address]
SET IsDeleted = 1
WHERE Id=@Id

END