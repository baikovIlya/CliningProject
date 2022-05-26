CREATE PROCEDURE [dbo].[ServiceType_Add]
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
