CREATE PROCEDURE [dbo].[Order_GetById]
	@Id int
AS
BEGIN

	SELECT Id, [Date], StartTime, EstimatedEndTime, FinishTime, Price, [Status], CountOfEmployees, IsCommercial, ClientId, AddressId
	FROM dbo.[Order]
	WHERE Id=@Id

END
