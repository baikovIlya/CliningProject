CREATE PROCEDURE [dbo].[WorkTime_DeleteById]
	@Id int 
 
AS 
BEGIN 
 
UPDATE dbo.WorkTime 
SET IsDeleted = 1 
WHERE Id = @Id 
 
END 
