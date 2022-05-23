CREATE PROCEDURE [dbo].[WorkTime_Update]
@Id int,
@Date nvarchar(255),
@StartTime nvarchar(10),
@FinishTime nvarchar(10),
@EmployeeId int
AS
Begin
update dbo.WorkTime
set
[Date] = @Date,
[StartTime] = @StartTime,
[FinishTime] = @FinishTime,
[EmployeeId] = @EmployeeId
where Id = @Id
End
