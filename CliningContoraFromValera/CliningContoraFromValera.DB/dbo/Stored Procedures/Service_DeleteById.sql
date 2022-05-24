CREATE PROCEDURE [dbo].[Service_DeleteById]
	@Id int
AS 
BEGIN 
	UPDATE dbo.[Service] 
	SET 
	IsDeleted = 1 
	WHERE Id = @Id 
END 
