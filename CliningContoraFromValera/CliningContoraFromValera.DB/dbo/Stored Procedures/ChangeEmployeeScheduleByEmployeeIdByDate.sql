CREATE PROCEDURE [dbo].[ChangeEmployeeScheduleByEmployeeIdByDate]
@Id int,
@Date nvarchar(10),
@StartTime nvarchar(10),
@FinishTime nvarchar(10)
AS
BEGIN
UPDATE dbo.WorkTime
SET
[Date] = @Date,
StartTime = @StartTime,
FinishTime = @FinishTime
WHERE EmployeeId = @Id AND [Date] = @Date
END
