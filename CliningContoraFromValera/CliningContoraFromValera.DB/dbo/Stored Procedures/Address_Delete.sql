CREATE PROCEDURE [dbo].[Address_Delete]
	@Id int

AS
BEGIN

DELETE FROM dbo.Address
WHERE Id=@Id

END