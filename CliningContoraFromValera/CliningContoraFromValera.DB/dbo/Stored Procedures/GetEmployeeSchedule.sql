CREATE PROCEDURE [dbo].[GetEmployeeSchedule]
AS
BEGIN
	  SELECT E.Id, E.FirstName, E.LastName, WT.[Date], WT.StartTime, WT.FinishTime FROM [dbo].[Employee] AS E
	  join dbo.WorkTime as WT on E.Id = WT.EmployeeId
      WHERE E.IsDeleted = 0 
END
