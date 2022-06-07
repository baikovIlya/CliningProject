CREATE PROCEDURE [dbo].[WorkTime_DeleteById]
	@Id int 
 
AS 
BEGIN 
 
DELETE FROM dbo.WorkTime
WHERE Id=@Id
 
END 
