CREATE PROCEDURE [dbo].[WorkArea_Delete]
	@Id int

AS
BEGIN

UPDATE dbo.WorkArea  
	SET
	IsDeleted = 1  
	WHERE Id = @Id

END
