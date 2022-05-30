CREATE PROCEDURE [dbo].[GetEmployyesAvailableForOrder]
@Date date,
@ServiceId int,
@WorkAreaId int
AS
BEGIN
	  SELECT E.Id, E.FirstName, E.LastName, E.Phone, WT.Id, WT.[Date], WT.StartTime, WT.FinishTime, WT.EmployeeId,
	  S.Id, S.ServiceType, S.[Name], S.[Description], S.Price, S.CommercialPrice, S.Unit, S.EstimatedTime,
	  WA.Id, WA.[Name] FROM [dbo].[Employee] AS E
	  join dbo.WorkTime as WT on E.Id = WT.EmployeeId
	  join dbo.Employee_Service as ES on E.Id = ES.EmployeeId
	  join dbo.[Service] as S on ES.ServiceId = S.Id
	  join dbo.Employee_WorkArea as EA on E.Id = EA.EmployeeId
	  join dbo.WorkArea as WA on EA.WorkAreaId = WA.Id
      WHERE E.IsDeleted = 0 AND WT.IsDeleted = 0 AND S.IsDeleted = 0 AND WA.IsDeleted = 0 AND
	  WT.[Date] = @Date AND S.Id = @ServiceId AND WA.Id = @WorkAreaId
END
