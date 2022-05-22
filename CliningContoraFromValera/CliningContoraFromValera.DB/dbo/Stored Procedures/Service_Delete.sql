CREATE PROCEDURE [dbo].[Service_Delete]
	@Id int
AS 
BEGIN 
	UPDATE dbo.[Service] 
	SET 
	IsDeleted = 1 
	WHERE Id = @Id 
END 
