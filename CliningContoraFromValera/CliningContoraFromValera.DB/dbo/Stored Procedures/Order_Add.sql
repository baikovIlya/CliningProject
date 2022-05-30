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
        [Date],
        StartTime,
        EstimatedEndTime,
        FinishTime,
        Price,
        [Status],
        CountOfEmployees,
        IsCommercial,
        ClientId,
        AddressId)
        
 VALUES (
        @Date,
        @StartTime,
        @EstimatedEndTime,
        @FinishTime,
        @Price,
        @Status,
        @CountOfEmployees,
        @IsCommercial,
        @ClientId,
        @AddressId)
SELECT @@IDENTITY 
END
 
