CREATE PROCEDURE [dbo].[Address_GetById]
	@Id int
AS
BEGIN

	SELECT Id, Street, Building, Room, WorkAreaId
	FROM dbo.[Address]
	WHERE Id=@Id

END
