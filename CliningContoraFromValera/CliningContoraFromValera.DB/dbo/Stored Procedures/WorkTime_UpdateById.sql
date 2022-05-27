CREATE PROCEDURE [dbo].[WorkTime_UpdateById]
@Id int,
@Date date,
@StartTime time,
@FinishTime time,
@EmployeeId int
AS
Begin
update dbo.WorkTime
set
[Date] = @Date,
StartTime = @StartTime,
FinishTime = @FinishTime,
EmployeeId = @EmployeeId
where Id = @Id
End
