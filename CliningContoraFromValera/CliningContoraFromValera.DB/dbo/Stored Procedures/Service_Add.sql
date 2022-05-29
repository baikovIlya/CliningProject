﻿CREATE PROCEDURE [dbo].[Service_Add]
	@Name nvarchar(100),
	@Description nvarchar(255),
	@Price DECIMAL (10, 2),
	@CommercialPrice DECIMAL (10, 2),
	@Unit nvarchar(30),
	@EstimatedTime time
AS
BEGIN
INSERT INTO dbo.[Service](
	[Name],
	[Description],
	Price,
	CommercialPrice,
	Unit,
	EstimatedTime)
VALUES(
	@Name,
	@Description,
	@Price,
	@CommercialPrice,
	@Unit,
	@EstimatedTime)

SELECT @@IDENTITY 
END
