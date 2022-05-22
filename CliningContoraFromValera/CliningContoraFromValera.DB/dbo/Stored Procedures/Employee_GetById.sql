CREATE PROCEDURE [dbo].[Employee_GetById]
	@Id int
AS
BEGIN
	SELECT 
		E.Id,
		E.FirstName,
		E.LastName,
		E.Phone,
		E.WorkTimeId
	FROM dbo.[Employee] E
	WHERE Id = @Id
END	
