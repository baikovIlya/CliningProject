CREATE PROCEDURE [dbo].[Client_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@Phone nvarchar(25)

AS
BEGIN

UPDATE Client
SET FirstName = @FirstName,
	LastName = @LastName,
	Email = @Email,
	Phone = @Phone
WHERE Id = @Id

END
