CREATE PROCEDURE [dbo].[WorkArea_GetById]
	@Id int
AS
BEGIN

	SELECT Id, [Name]
	FROM dbo.WorkArea
	WHERE Id=@Id AND (IsDeleted = 0)

END