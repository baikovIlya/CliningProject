CREATE PROCEDURE [dbo].[Employee_DeleteById]
	@Id int

AS
BEGIN

UPDATE dbo.Employee
SET IsDeleted = 1
WHERE Id = @Id

END