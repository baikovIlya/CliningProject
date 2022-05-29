CREATE PROCEDURE [dbo].[Service_UpdateById]
	@Id int,
	@Name nvarchar(100),
	@Description nvarchar(255),
	@Price DECIMAL (10, 2),
	@CommercialPrice DECIMAL (10, 2),
	@Unit nvarchar(30),
	@EstimatedTime time
AS
BEGIN

UPDATE dbo.[Service]
SET [Name] = @Name,
    [Description] = @Description,
    Price = @Price,
    CommercialPrice = @CommercialPrice,
    Unit = @Unit,
    EstimatedTime = @EstimatedTime
WHERE Id = @Id

END
