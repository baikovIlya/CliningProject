CREATE PROCEDURE [dbo].[Order_Add]
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
INSERT INTO dbo.[Order](
        ClientId,
        [Date],
        StartTime,
        EstimatedEndTime,
        FinishTime,
        Price,
        [Status],
        AddressId,
        CountOfEmployees,
        IsCommercial)
        
 VALUES (
        @ClientId,
        @Date,
        @StartTime,
        @EstimatedEndTime,
        @FinishTime,
        @Price,
        @Status,
        @AddressId,
        @CountOfEmployees,
        @IsCommercial)
SELECT @@IDENTITY 
END
 
