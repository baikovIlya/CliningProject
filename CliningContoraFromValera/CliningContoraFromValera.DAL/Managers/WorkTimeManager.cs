using Dapper;
using System.Data.SqlClient;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.DAL.Managers
{
    public class WorkTimeManager
    {
        public List<WorkTimeDTO> GetAllWorkTimes()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<WorkTimeDTO>(
                    StoredProcedures.WorkTime_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public WorkTimeDTO GetWorkTimeById(int workTimeId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<WorkTimeDTO>(
                    StoredProcedures.WorkTime_GetById,
                    param: new { id = workTimeId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddWorkTime(WorkTimeDTO newWokrTime)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<WorkTimeDTO>(
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

        public void UpdateWorkTimeById(WorkTimeDTO newWokrTime)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkTimeDTO>(
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

                connection.QuerySingleOrDefault<WorkTimeDTO>(
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

                connection.QuerySingleOrDefault<WorkTimeDTO>(
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

        public List<EmployeeDTO> GetEmployeesAndWorkTimes()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                Dictionary<int, EmployeeDTO> result = new Dictionary<int, EmployeeDTO>();

                connection.Query<EmployeeDTO, WorkTimeDTO, EmployeeDTO>(
                    StoredProcedures.GetEmployeesAndWorkTimes,
                    (employee, workTime) => {
                        if (!result.ContainsKey(employee.Id))
                        {
                            result.Add(employee.Id, employee);
                        }

                        EmployeeDTO crnt = result[employee.Id];

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
