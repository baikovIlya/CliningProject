CREATE PROCEDURE [dbo].[ServiceType_UpdateById]
	@Id int,
	@Name nvarchar(50)

AS
BEGIN

UPDATE [dbo].[ServiceType]
SET [Name] = @Name
WHERE Id = @Id

END
