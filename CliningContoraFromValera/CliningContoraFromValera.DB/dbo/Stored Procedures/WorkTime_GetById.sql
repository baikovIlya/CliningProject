CREATE PROCEDURE [dbo].[WorkTime_GetById]
	@Id int
AS
Begin
Select *from dbo.WorkTime
where Id = @Id
End
