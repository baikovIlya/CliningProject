CREATE PROCEDURE [dbo].[Address_Update]
	@Id int,
	@Street nvarchar(50),
	@Building nvarchar(50),
	@Room nvarchar(50),
	@WorkAreaId int

AS
BEGIN

UPDATE dbo.[Address]
SET Street = @Street,
    Building = @Building,
    Room = @Room,
    WorkAreaId = @WorkAreaId
WHERE Id = @Id

END
