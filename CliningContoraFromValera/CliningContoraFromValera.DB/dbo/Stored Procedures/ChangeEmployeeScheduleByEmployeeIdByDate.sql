CREATE PROCEDURE [dbo].[ChangeEmployeeScheduleByEmployeeIdByDate]
@Id int,
@Date date,
@StartTime time,
@FinishTime time
AS
BEGIN
UPDATE dbo.WorkTime
SET
StartTime = @StartTime,
FinishTime = @FinishTime
WHERE EmployeeId = @Id AND [Date] = @Date
END
