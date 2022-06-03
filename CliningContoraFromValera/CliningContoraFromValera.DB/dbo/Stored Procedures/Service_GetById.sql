CREATE PROCEDURE [dbo].[Service_GetById]
	@Id int
AS
BEGIN

	SELECT Id, ServiceType, ServiceName, [Description], ServicePrice, CommercialPrice, Unit, EstimatedTime
	FROM dbo.[Service]
	WHERE Id=@Id

END
