CREATE PROCEDURE [dbo].[Client_Add]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@Phone nvarchar(25)
AS
BEGIN
INSERT INTO Client(
	FirstName,
	LastName,
	Email,
	Phone)
VALUES(
	@FirstName,
	@LastName,
	@Email,
	@Phone)

SET @Id=SCOPE_IDENTITY()

SELECT
FirstName = @FirstName,
LastName = @LastName,
Email = @Email,
Phone = @Phone
FROM Client
WHERE Id = @Id
END
