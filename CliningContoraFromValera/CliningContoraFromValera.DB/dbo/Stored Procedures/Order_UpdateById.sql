CREATE PROCEDURE [dbo].[Order_UpdateById]
	@Id int,
	@Date date,
	@StartTime time,
	@EstimatedEndTime time,
	@FinishTime time,
	@Price decimal(10,2),
	@Status nvarchar(50),
	@CountOfEmployees int,
	@IsCommercial bit,
	@ClientId int,
	@AddressId int
AS
BEGIN

UPDATE dbo.[Order]
SET 
        [Date] = @Date,
        StartTime = @StartTime,
        EstimatedEndTime = @EstimatedEndTime,
        FinishTime = @FinishTime,
        Price = @Price,
        [Status] = @Status,
        CountOfEmployees = @CountOfEmployees,
        IsCommercial = @IsCommercial,
		ClientId = @ClientId,
		AddressId = @AddressId

WHERE Id = @Id

END
