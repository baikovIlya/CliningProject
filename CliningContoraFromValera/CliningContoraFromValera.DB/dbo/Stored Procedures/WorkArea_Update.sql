CREATE PROCEDURE [dbo].[WorkArea_Update]
	@Id int,
	@Name nvarchar(30)

AS
BEGIN

UPDATE dbo.WorkArea
SET [Name] = @Name
WHERE Id = @Id

END
