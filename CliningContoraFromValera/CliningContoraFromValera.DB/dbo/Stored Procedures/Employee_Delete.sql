CREATE PROCEDURE [dbo].[Employee_Delete]
	@Id int

AS
BEGIN

UPDATE dbo.Employee
SET IsDeleted = 1
WHERE Id = @Id

END