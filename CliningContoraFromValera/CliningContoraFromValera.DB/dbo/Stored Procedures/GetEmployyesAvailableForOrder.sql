CREATE PROCEDURE [dbo].[GetEmployyesAvailableForOrder]
@Date date,
@ServiceId int,
@WorkAreaId int
AS
BEGIN
	  SELECT E.FirstName, E.LastName, WT.StartTime, WT.FinishTime, S.[Name], E.Phone FROM [dbo].[Employee] AS E
	  join dbo.WorkTime as WT on E.Id = WT.EmployeeId
	  join dbo.Employee_Service as ES on E.Id = ES.EmployeeId
	  join dbo.[Service] as S on ES.ServiceId = S.Id
	  join dbo.Employee_WorkArea as EA on E.Id = EA.EmployeeId
	  join dbo.WorkArea as WA on EA.WorkAreaId = WA.id
      WHERE E.IsDeleted = 0 AND WT.[Date] = @Date AND S.Id = @ServiceId AND WA.id = @WorkAreaId
END
