CREATE PROCEDURE [dbo].[WorkTime_Add]
@Date nvarchar(255),
@StartTime time,
@FinishTime time
AS
BEGIN
	INSERT INTO dbo.WorkTime
	(
	[Date],
	[StartTime],
	[FinishTime]
	)
	
	VALUES
	(
	@Date,
	@StartTime,
	@FinishTime
)

SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]
END
