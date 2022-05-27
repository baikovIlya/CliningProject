CREATE PROCEDURE [dbo].[GetAllServicesInfo] 
AS 
BEGIN 
	SELECT ST.Id, ST.[Name], S.Id, S.[Name], S.[Description], S.EstimatedTime, 
	S.Price, S.CommercialPrice, s.Unit FROM [dbo].[ServiceType] ST 
	join [dbo].[Service] S ON ST.Id = S.ServiceTypeId 
	WHERE S.IsDeleted = 0 
END 