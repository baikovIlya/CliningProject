CREATE PROCEDURE [dbo].[WorkTime_Add]
@Id int,
@Date nvarchar(255),
@StartTime nvarchar(10),
@FinishTime nvarchar(10),
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
