CREATE PROCEDURE [dbo].[ServiceType_Add]
	@Id int,
	@Name nvarchar(50)

AS
BEGIN
INSERT INTO [dbo].[ServiceType] (
	Name
	)
VALUES (
	@Name
	)

SET @Id = SCOPE_IDENTITY()

SELECT 
Name = @Name
FROM [dbo].[ServiceType]
WHERE Id=@Id
END
