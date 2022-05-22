CREATE PROCEDURE [dbo].[Service_GetById]
	@Id int
AS
BEGIN

	SELECT Id, [Name], [Description], Price, CommercialPrice, Unit, ServiceTypeId, EstimatedTime
	FROM dbo.[Service]
	WHERE Id=@Id

END
