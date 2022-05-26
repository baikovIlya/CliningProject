CREATE PROCEDURE [dbo].[Order_Add]
	@ClientId int,
	@Date nvarchar(10),
	@StartTime nvarchar(10),
	@EstimatedEndTime nvarchar(10),
	@EndTime nvarchar(10),
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
        EndTime,
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
        @EndTime,
        @Price,
        @Status,
        @AddressId,
        @CountOfEmployees,
        @IsCommercial)
SELECT @@IDENTITY 
END
 
