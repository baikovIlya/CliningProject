CREATE PROCEDURE [dbo].[WorkArea_Add]
	@Id int,
	@Name nvarchar(30)
AS
BEGIN
INSERT INTO dbo.WorkArea(
	[Name])
VALUES(
	@Name)

SELECT @@IDENTITY
END
