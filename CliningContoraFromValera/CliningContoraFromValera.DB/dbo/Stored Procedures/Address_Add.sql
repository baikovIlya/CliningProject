CREATE PROCEDURE [dbo].[Address_Add]
	@Street nvarchar(50),
	@Building nvarchar(50),
	@Room nvarchar(50),
	@WorkAreaId int
AS
BEGIN
INSERT INTO dbo.[Address](
	Street,
	Building,
	Room,
	WorkAreaId)
VALUES(
	@Street,
	@Building,
	@Room,
	@WorkAreaId)
SELECT @@IDENTITY
END
