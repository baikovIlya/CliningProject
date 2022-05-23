CREATE PROCEDURE [dbo].[Employee_Add]
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
    @Phone NVARCHAR (25),
    @WorkTimeId INT
AS
BEGIN
	INSERT INTO dbo.[Employee] ([FirstName], [LastName], [Phone])
	VALUES (@FirstName, @LastName, @Phone, @WorkTimeId)
	SELECT @@IDENTITY
END