using Dapper;
using System.Data.SqlClient;
using CliningContoraFromValera.DAL.Dtos;

namespace CliningContoraFromValera.DAL.Managers
{
    public class WorkTimeManager
    {
        public List<WorkTimeDto> GetAllWorkTimes()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<WorkTimeDto>(
                    StoredProcedures.WorkTime_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public WorkTimeDto GetWorkTimeById(int workTimeId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<WorkTimeDto>(
                    StoredProcedures.WorkTime_GetById,
                    param: new { id = workTimeId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddWorkTime(WorkTimeDto newWokrTime)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<WorkTimeDto>(
                    StoredProcedures.WorkTime_Add,
                    param: new
                    {
                        newWokrTime.Date,
                        newWokrTime.StartTime,
                        newWokrTime.FinishTime,
                        newWokrTime.EmployeeId
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateWorkTimeById(WorkTimeDto newWokrTime)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkTimeDto>(
                    StoredProcedures.WorkTime_UpdateById,
                    param: new
                    {
                        newWokrTime.Id,
                        newWokrTime.Date,
                        newWokrTime.StartTime,
                        newWokrTime.FinishTime,
                        newWokrTime.EmployeeId
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteWorkTimeById(int workTimeId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkTimeDto>(
                    StoredProcedures.WorkTime_DeleteById,
                    param: new { id = workTimeId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void ChangeEmployeeScheduleByEmployeeIdByDate(int employeeId, DateTime date,
            TimeSpan startTime, TimeSpan finishTime)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkTimeDto>(
                    StoredProcedures.ChangeEmployeeScheduleByEmployeeIdByDate,
                    param: new
                    {
                        EmployeeId = employeeId,
                        Date = date,
                        StartTime = startTime,
                        FinishTime = finishTime
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<EmployeeDto> GetEmployeesAndWorkTimes()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                Dictionary<int, EmployeeDto> result = new Dictionary<int, EmployeeDto>();

                connection.Query<EmployeeDto, WorkTimeDto, EmployeeDto>(
                    StoredProcedures.GetEmployeesAndWorkTimes,
                    (employee, workTime) => {
                        if (!result.ContainsKey(employee.Id))
                        {
                            result.Add(employee.Id, employee);
                        }

                        EmployeeDto crnt = result[employee.Id];

                        if (workTime != null)
                        {
                            crnt.WorkTime = workTime;
                        }
                        return crnt;
                    },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "Id"
                );

                return result.Values.ToList();
            }
        }
    }
}
