CREATE PROCEDURE [dbo].[ServiceType_GetAll]

AS
BEGIN

SELECT Id, Name
FROM [dbo].[ServiceType]

END
