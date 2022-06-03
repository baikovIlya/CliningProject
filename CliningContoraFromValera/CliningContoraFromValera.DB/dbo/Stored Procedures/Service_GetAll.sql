CREATE PROCEDURE [dbo].[Service_GetAll]

AS
BEGIN

	SELECT Id, ServiceType, ServiceName, [Description], ServicePrice, CommercialPrice, Unit, EstimatedTime
	FROM dbo.[Service]
	WHERE IsDeleted = 0

END
