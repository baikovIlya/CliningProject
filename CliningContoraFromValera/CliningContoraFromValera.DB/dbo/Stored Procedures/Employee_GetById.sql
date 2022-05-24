CREATE PROCEDURE [dbo].[Employee_GetById]
	@Id int
AS
BEGIN
	SELECT 
		E.Id,
		E.FirstName,
		E.LastName,
		E.Phone
	FROM dbo.[Employee] E
	WHERE Id = @Id AND (E.IsDeleted = 0)
END	
