CREATE PROCEDURE [dbo].[ServiceType_Delete]
	@Id int

AS
BEGIN

DELETE
FROM [dbo].[ServiceType]
WHERE Id = @Id

END
