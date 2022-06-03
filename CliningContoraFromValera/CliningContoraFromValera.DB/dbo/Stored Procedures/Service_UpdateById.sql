CREATE PROCEDURE [dbo].[Service_UpdateById]
	@Id int,
	@ServiceType nvarchar(50),
	@ServiceName nvarchar(100),
	@Description nvarchar(255),
	@ServicePrice DECIMAL (10, 2),
	@CommercialPrice DECIMAL (10, 2),
	@Unit nvarchar(30),
	@EstimatedTime time
AS
BEGIN

UPDATE dbo.[Service]
SET ServiceType = @ServiceType,
    ServiceName = @ServiceName,
    [Description] = @Description,
    ServicePrice = @ServicePrice,
    CommercialPrice = @CommercialPrice,
    Unit = @Unit,
    EstimatedTime = @EstimatedTime
WHERE Id = @Id

END
