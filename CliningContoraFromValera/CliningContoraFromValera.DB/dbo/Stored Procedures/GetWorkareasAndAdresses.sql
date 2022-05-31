CREATE PROCEDURE [dbo].[GetWorkareasAndAdresses]
AS
BEGIN
	SELECT WA.[Name], A.Street, A.Building, A.Room
	FROM dbo.WorkArea WA
	join dbo.[Address] A ON A.WorkAreaId = WA.[Name]
	WHERE WA.IsDeleted = 0
END
