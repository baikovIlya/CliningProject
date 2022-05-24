CREATE PROCEDURE [dbo].[ServiceType_DeleteById]
	@Id int

AS
BEGIN


UPDATE [dbo].[ServiceType]
SET IsDeleted = 1
WHERE Id = @Id

END
