CREATE PROCEDURE [dbo].[Employee_UpdateById]
	@Id int,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
    @Phone NVARCHAR (25)
AS
BEGIN
	UPDATE dbo.[Employee]
	SET 
		FirstName = @FirstName,
		LastName = @LastName,
		Phone = @Phone
	WHERE Id = @Id
END