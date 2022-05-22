﻿CREATE PROCEDURE [dbo].[Service_Add]
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

SELECT @@IDENTITY 
END