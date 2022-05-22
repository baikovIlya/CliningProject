CREATE PROCEDURE [dbo].[Service_Update]
	@Id int,
	@Name nvarchar(100),
	@Description nvarchar(255),
	@Price DECIMAL (10, 2),
	@CommercialPrice DECIMAL (10, 2),
	@Unit nvarchar(30),
	@ServiceTypeId int,
	@EstimatedTime nvarchar(10)
AS
BEGIN

UPDATE dbo.[Service]
SET [Name] = @Name,
    [Description] = @Description,
    Price = @Price,
    CommercialPrice = @CommercialPrice,
    Unit = @Unit,
    ServiceTypeId = @ServiceTypeId,
    EstimatedTime = @EstimatedTime
WHERE Id = @Id

END
