CREATE PROCEDURE [dbo].[Address_GetAll]
	
AS
BEGIN

	SELECT Id, Street, Building, Room, WorkAreaId
	FROM dbo.[Address]

END

