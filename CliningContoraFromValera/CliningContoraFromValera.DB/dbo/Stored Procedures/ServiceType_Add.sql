CREATE PROCEDURE [dbo].[ServiceType_Add]
	@Id int,
	@Name nvarchar(50)

AS
BEGIN
INSERT INTO [dbo].[ServiceType] (
	[Name]
	)
VALUES (
	@Name
	)

SELECT @@IDENTITY
END
