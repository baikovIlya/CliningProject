using Dapper;
using System.Data.SqlClient;

namespace CliningContoraFromValera.DAL
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

        public WorkTimeDTO GetWorkTimeByID(int id)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<WorkTimeDTO>(
                    StoredProcedures.WorkTime_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddWorkTime(DateOnly date, TimeOnly startTime, TimeOnly finishTime, int employeeId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<WorkTimeDTO>(
                    StoredProcedures.WorkTime_Add,
                    param: new
                    {
                        Date = date,
                        StartTime = startTime,
                        FinishTime = finishTime,
                        EmployeeId = employeeId
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateWorkTimeById(int id, DateOnly date, TimeOnly startTime, TimeOnly finishTime, int employeeId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkTimeDTO>(
                    StoredProcedures.WorkTime_UpdateById,
                    param: new
                    {
                        id = id,
                        Date = date,
                        StartTime = startTime,
                        FinishTime = finishTime,
                        EmployeeId = employeeId
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteWorkTimeById(int id)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkTimeDTO>(
                    StoredProcedures.WorkTime_DeleteById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void ChangeEmployeeScheduleByEmployeeIdByDate(int id, DateOnly date, TimeOnly startTime, TimeOnly finishTime)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkTimeDTO>(
                    StoredProcedures.ChangeEmployeeScheduleByEmployeeIdByDate,
                    param: new
                    {
                        id = id,
                        Date = date,
                        StartTime = startTime,
                        FinishTime = finishTime
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
