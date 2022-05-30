CREATE PROCEDURE [dbo].[Service_GetAll]

AS
BEGIN

	SELECT Id, [Name], [Description], Price, CommercialPrice, Unit, EstimatedTime
	FROM dbo.[Service]
	WHERE (IsDeleted = 0)

END
