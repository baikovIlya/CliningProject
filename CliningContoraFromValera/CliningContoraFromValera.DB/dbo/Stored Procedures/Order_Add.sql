CREATE PROCEDURE [dbo].[Order_Add]
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
 
