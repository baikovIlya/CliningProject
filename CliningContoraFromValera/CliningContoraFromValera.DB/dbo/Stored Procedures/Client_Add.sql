CREATE PROCEDURE [dbo].[Client_Add]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@Phone nvarchar(25)
AS
BEGIN
INSERT INTO dbo.Client(
	FirstName,
	LastName,
	Email,
	Phone)
VALUES(
	@FirstName,
	@LastName,
	@Email,
	@Phone)

SELECT @@IDENTITY
END
