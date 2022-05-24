CREATE PROCEDURE [dbo].[ChangeEmployeeScheduleByIdByDate]
@Id int,
@Date nvarchar(255),
@StartTime nvarchar(10),
@FinishTime nvarchar(10),
@EmployeeId int
AS
BEGIN
UPDATE dbo.WorkTime
SET
[Date] = @Date,
StartTime = @StartTime,
FinishTime = @FinishTime
WHERE Id = @Id AND EmployeeId = @EmployeeId AND [Date] = @Date
END
