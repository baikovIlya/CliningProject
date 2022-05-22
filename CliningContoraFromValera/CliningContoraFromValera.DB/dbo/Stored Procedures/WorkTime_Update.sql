CREATE PROCEDURE [dbo].[WorkTime_Update]
	@Id int,
@Date nvarchar(255),
@StartTime time,
@FinishTime time
AS
Begin
update dbo.WorkTime
set
[Date] = @Date,
[StartTime] = @StartTime,
[FinishTime] = @FinishTime
where Id = @Id
End
