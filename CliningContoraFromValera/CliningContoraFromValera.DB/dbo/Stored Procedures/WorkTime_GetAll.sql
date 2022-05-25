CREATE PROCEDURE [dbo].[WorkTime_GetAll]
	
AS
Begin
Select 	
    Id,
	[Date],
	StartTime,
	FinishTime,
	EmployeeId
From dbo.[WorkTime] 
WHERE (IsDeleted = 0)
End
