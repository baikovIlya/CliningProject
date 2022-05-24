CREATE PROCEDURE [dbo].[Service_GetById]
	@Id int
AS
BEGIN

	SELECT Id, [Name], [Description], Price, CommercialPrice, Unit, ServiceTypeId, EstimatedTime
	FROM dbo.[Service] S
	WHERE Id=@Id AND (S.IsDeleted = 0)

END
