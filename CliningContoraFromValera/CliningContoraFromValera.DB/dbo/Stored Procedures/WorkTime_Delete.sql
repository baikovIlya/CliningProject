CREATE PROCEDURE [dbo].[WorkTime_Delete]
	@Id int

AS
BEGIN

UPDATE dbo.[WorkTime]
SET IsDeleted = 1
WHERE Id=@Id

END