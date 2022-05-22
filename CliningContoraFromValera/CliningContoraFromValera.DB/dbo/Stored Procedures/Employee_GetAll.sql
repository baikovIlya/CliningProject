CREATE PROCEDURE [dbo].[Employee_GetAll]
AS
BEGIN
	SELECT 
		E.Id,
		E.FirstName,
		E.LastName,
		E.Phone,
		E.WorkTimeId
		
	FROM dbo.[Employee] E
	WHERE (E.IsDeleted = 0)
END
