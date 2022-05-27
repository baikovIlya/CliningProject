CREATE PROCEDURE [dbo].[WorkTime_Add]
@Date date,
@StartTime time,
@FinishTime time,
@EmployeeId int
AS
BEGIN
	INSERT INTO dbo.WorkTime
	(
	[Date],
	StartTime,
	FinishTime,
	EmployeeId
	)
	
	VALUES
	(
	@Date,
	@StartTime,
	@FinishTime,
	@EmployeeId
)

SELECT @@IDENTITY
END
