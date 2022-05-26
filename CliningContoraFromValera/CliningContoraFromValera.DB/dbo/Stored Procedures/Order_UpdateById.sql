CREATE PROCEDURE [dbo].[Order_UpdateById]
	@id int,
	@ClientId int,
	@Date date,
	@StartTime time,
	@EstimatedEndTime time,
	@FinishTime time,
	@Price decimal(10,2),
	@Status nvarchar(50),
	@AddressId int,
	@CountOfEmployees int,
	@IsCommercial bit
AS
BEGIN

UPDATE dbo.[Order]
SET 
        ClientId = @ClientId,
        [Date] = @Date,
        StartTime = @StartTime,
        EstimatedEndTime = @EstimatedEndTime,
        FinishTime = @FinishTime,
        Price = @Price,
        [Status] = @Status,
        AddressId = @AddressId,
        CountOfEmployees = @CountOfEmployees,
        IsCommercial = @IsCommercial
WHERE Id = @Id

END
