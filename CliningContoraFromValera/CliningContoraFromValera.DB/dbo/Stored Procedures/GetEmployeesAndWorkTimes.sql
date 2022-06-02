CREATE PROCEDURE [dbo].[GetEmployeesAndWorkTimes]
AS
BEGIN
SELECT E.Id, E.FirstName, E.LastName, E.Phone,
WT.Id, WT.[Date], WT.StartTime, WT.FinishTime
from dbo.Employee as E 
join dbo.WorkTime as WT on E.Id = WT.EmployeeId
END
