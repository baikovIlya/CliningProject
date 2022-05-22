CREATE PROCEDURE [dbo].[Service_GetAll]

AS
BEGIN

	SELECT Id, [Name], [Description], Price, CommercialPrice, Unit, ServiceTypeId, EstimatedTime
	FROM dbo.[Service]

END
