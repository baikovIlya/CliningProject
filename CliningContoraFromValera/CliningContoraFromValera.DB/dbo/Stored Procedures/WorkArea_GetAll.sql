﻿CREATE PROCEDURE [dbo].[WorkArea_GetAll]
	
AS
BEGIN

	SELECT Id, [Name]
	FROM dbo.WorkArea
	WHERE (IsDeleted = 0)

END
