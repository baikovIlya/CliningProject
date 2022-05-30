CREATE PROCEDURE [dbo].[Service_Add]
    @ServiceType nvarchar(100),
	@Name nvarchar(100),
	@Description nvarchar(255),
	@Price DECIMAL (10, 2),
	@CommercialPrice DECIMAL (10, 2),
	@Unit nvarchar(30),
	@EstimatedTime time
AS
BEGIN
INSERT INTO dbo.[Service](
	[ServiceType],
	[Name],
	[Description],
	Price,
	CommercialPrice,
	Unit,
	EstimatedTime)
VALUES(
    @ServiceType,
	@Name,
	@Description,
	@Price,
	@CommercialPrice,
	@Unit,
	@EstimatedTime)

SELECT @@IDENTITY 
END
