CREATE PROCEDURE [dbo].[ServiceType_GetAll]

AS
BEGIN

SELECT Id, [Name]
FROM [dbo].[ServiceType]
WHERE (IsDeleted = 0)
END
