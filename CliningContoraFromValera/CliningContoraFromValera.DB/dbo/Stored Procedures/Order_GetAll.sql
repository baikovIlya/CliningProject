CREATE PROCEDURE [dbo].[Order_GetAll]
	
AS
BEGIN

	SELECT Id, [Date], StartTime, EstimatedEndTime, FinishTime, Price, [Status], CountOfEmployees, IsCommercial, ClientId, AddressId
	FROM dbo.[Order]
	WHERE (IsDeleted = 0)

END
