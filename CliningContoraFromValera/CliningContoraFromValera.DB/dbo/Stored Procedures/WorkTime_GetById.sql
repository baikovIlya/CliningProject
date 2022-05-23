CREATE PROCEDURE [dbo].[WorkTime_GetById]
	@Id int
AS
BEGIN
	SELECT 
	[Id],
	[Date],
	[StartTime],
	[FinishTime],
	[EmployeeId]
	FROM dbo.[WorkTime] 
	WHERE Id = @Id
END	
