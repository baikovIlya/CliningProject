CREATE PROCEDURE [dbo].[Service_Add]
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
INSERT INTO dbo.[Service](
	[Name],
	[Description],
	Price,
	CommercialPrice,
	Unit,
	ServiceTypeId,
	EstimatedTime)
VALUES(
	@Name,
	@Description,
	@Price,
	@CommercialPrice,
	@Unit,
	@ServiceTypeId,
	@EstimatedTime)

SET @Id=SCOPE_IDENTITY()

SELECT 
[Name] = @Name,
[Description] = @Description,
Price = @Price,
CommercialPrice = @CommercialPrice,
Unit = @Unit,
ServiceTypeId = @ServiceTypeId,
EstimatedTime = @EstimatedTime
FROM dbo.[Service]
WHERE Id = @Id
END
