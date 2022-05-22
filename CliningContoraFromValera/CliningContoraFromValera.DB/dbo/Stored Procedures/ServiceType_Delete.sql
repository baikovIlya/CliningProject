CREATE PROCEDURE [dbo].[ServiceType_Delete]
	@Id int

AS
BEGIN


UPDATE [dbo].[ServiceType]
SET IsDeleted = 1
WHERE Id = @Id

END
