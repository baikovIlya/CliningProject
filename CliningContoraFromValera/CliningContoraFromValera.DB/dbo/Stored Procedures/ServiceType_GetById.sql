CREATE PROCEDURE [dbo].[ServiceType_GetById]
	@Id int

AS
BEGIN

SELECT Id, [Name]
FROM [dbo].[ServiceType]
WHERE (Id = @Id)

END
