CREATE PROCEDURE [dbo].[ChangeEmployeeScheduleByEmployeeIdByDate]
@EmployeeId int,
@Date date,
@StartTime time,
@FinishTime time
AS
BEGIN
UPDATE dbo.WorkTime
SET
StartTime = @StartTime,
FinishTime = @FinishTime
WHERE EmployeeId = @EmployeeId AND [Date] = @Date
END
