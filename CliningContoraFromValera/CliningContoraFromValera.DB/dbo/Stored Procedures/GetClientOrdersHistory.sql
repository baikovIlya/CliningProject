CREATE PROCEDURE GetClientOrdersHistory
	@Id int

AS
BEGIN
SELECT C.Id, C.FirstName, C.LastName, O.Id, S.[Name], WA.[Name], A.[Street], A.[Building], A.Room, O.Price FROM [dbo].Client AS C
	join [dbo].[Order] as O on C.Id = O.ClientId
	join [dbo].[Service_Order] as SO on O.Id = SO.OrderId
	join [dbo].[Service] as S on SO.ServiceId = S.Id
	join [dbo].[Address] as A on O.AddressId = A.Id
	join [dbo].[WorkArea] as WA on A.WorkAreaId = WA.Id

	WHERE C.Id = @Id
END
