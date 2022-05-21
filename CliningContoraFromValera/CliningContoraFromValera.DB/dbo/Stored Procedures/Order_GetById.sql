CREATE PROCEDURE [dbo].[Order_GetById]
	@Id int
AS
BEGIN

	SELECT Id, ClientId, [Date], StartTime, EstimatedEndTime, EndTime, Price, [Status], AddressId, CountOfEmployees, IsCommercial
	FROM dbo.[Order]
	WHERE Id=@Id

END
