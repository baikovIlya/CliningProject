CREATE PROCEDURE [dbo].[WorkArea_Add]
	@Id int,
	@Name nvarchar(30)
AS
BEGIN
INSERT INTO dbo.WorkArea(
	[Name])
VALUES(
	@Name)
SET @Id=SCOPE_IDENTITY()

SELECT
[Name] = @Name
FROM dbo.WorkArea
WHERE Id = @Id
END
