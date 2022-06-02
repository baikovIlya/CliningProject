CREATE PROCEDURE [dbo].[GetWorkareasAndAdresses]
AS
BEGIN
	SELECT WA.Id, WA.[Name], A.Id, A.Street, A.Building, A.Room
	FROM dbo.WorkArea WA
	join dbo.[Address] A ON A.WorkAreaId = WA.Id
	WHERE WA.IsDeleted = 0
END
