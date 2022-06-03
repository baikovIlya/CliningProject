CREATE PROCEDURE [dbo].[Service_Add]
    @ServiceType nvarchar(50),
	@ServiceName nvarchar(100),
	@Description nvarchar(255),
	@ServicePrice DECIMAL (10, 2),
	@CommercialPrice DECIMAL (10, 2),
	@Unit nvarchar(30),
	@EstimatedTime time
AS
BEGIN
INSERT INTO dbo.[Service](
	ServiceType,
	ServiceName,
	[Description],
	ServicePrice,
	CommercialPrice,
	Unit,
	EstimatedTime)
VALUES(
    @ServiceType,
	@ServiceName,
	@Description,
	@ServicePrice,
	@CommercialPrice,
	@Unit,
	@EstimatedTime)

SELECT @@IDENTITY 
END
