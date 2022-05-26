CREATE PROCEDURE [dbo].[GetEmployyesAvailableForOrder]
@Date nvarchar (10),
@ServiceId int,
@WorkAreaId int
AS
BEGIN
	  SELECT Empl.FirstName, Empl.LastName, WT.StartTime, WT.FinishTime, Ser.[Name], Empl.Phone FROM [dbo].[Employee] AS Empl
	  join dbo.WorkTime as WT on Empl.Id = WT.EmployeeId
	  join dbo.Employee_Service as EmpSer on Empl.Id = EmpSer.EmployeeId
	  join dbo.[Service] as Ser on EmpSer.ServiceId = Ser.Id
	  join dbo.Employee_WorkArea as EmpArea on Empl.Id = EmpArea.EmployeeId
	  join dbo.WorkArea as WAr on EmpArea.WorkAreaId = WAr.id
      WHERE Empl.IsDeleted = 0 AND WT.[Date] = @Date AND Ser.Id = @ServiceId AND WAr.id = @WorkAreaId
END
