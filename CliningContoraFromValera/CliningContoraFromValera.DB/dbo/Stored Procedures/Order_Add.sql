CREATE PROCEDURE [dbo].[Order_Add]
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
SET IDENTITY_INSERT [Order] ON
INSERT INTO dbo.[Order](
        Id,
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
        @Id,
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
SET IDENTITY_INSERT [Order] OFF
END
 
