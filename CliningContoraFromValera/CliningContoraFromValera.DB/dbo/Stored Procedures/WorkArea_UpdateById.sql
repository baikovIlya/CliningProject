CREATE PROCEDURE [dbo].[WorkArea_UpdateById]
	@Id int,
	@Name nvarchar(30)

AS
BEGIN

UPDATE dbo.WorkArea
SET [Name] = @Name
WHERE Id = @Id

END
