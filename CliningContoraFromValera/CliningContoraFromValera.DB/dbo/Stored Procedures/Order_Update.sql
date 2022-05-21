CREATE PROCEDURE [dbo].[Order_Update]
	@id int,
	@ClientId int,
	@Date nvarchar(10),
	@StartTime nvarchar(10),
	@EstimatedEndTime nvarchar(10),
	@EndTime nvarchar(10),
	@Price decimal(10,2),
	@Status nvarchar(1),
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
        EndTime = @EndTime,
        Price = @Price,
        [Status] = @Status,
        AddressId = @AddressId,
        CountOfEmployees = @CountOfEmployees,
        IsCommercial = @IsCommercial
WHERE Id = @Id

END
