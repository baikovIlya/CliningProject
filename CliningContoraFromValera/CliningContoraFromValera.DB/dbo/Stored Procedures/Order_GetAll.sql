CREATE PROCEDURE [dbo].[Order_GetAll]
	
AS
BEGIN

	SELECT Id, ClientId, [Date], StartTime, EstimatedEndTime, EndTime, Price, [Status], AddressId, CountOfEmployees, IsCommercial
	FROM dbo.[Order]
	WHERE (IsDeleted = 0)

END
