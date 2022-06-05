CREATE PROCEDURE [dbo].[GetEmployeeSchedule]
@MinDate dateTime,
@MaxDate dateTime
AS
BEGIN
	  SELECT E.Id, E.FirstName, E.LastName, E.Phone, WT.Id, WT.[Date], WT.StartTime, WT.FinishTime,
	  WT.EmployeeId FROM [dbo].[Employee] AS E
	  join dbo.WorkTime as WT on E.Id = WT.EmployeeId
      WHERE E.IsDeleted = 0 AND WT.[Date] >= @MinDate AND WT.[Date] <= @MaxDate AND @MaxDate = @MinDate
END
