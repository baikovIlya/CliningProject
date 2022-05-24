CREATE PROCEDURE [dbo].[Client_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.Client
SET IsDeleted = 1
WHERE Id = @Id

END
