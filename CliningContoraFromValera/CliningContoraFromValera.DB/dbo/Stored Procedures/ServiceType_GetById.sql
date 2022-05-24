CREATE PROCEDURE [dbo].[ServiceType_GetById]
	@Id int

AS
BEGIN

SELECT Id, [Name]
FROM [dbo].[ServiceType] ST
WHERE (Id = @Id) AND (ST.IsDeleted = 0)

END
