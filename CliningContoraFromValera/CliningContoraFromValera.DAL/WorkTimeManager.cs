using Dapper;
using System.Data.SqlClient;

namespace CliningContoraFromValera.DAL
{
    public class WorkTimeManager
    {
        public string connectionString = @"Server=.;Database=CliningContoraFromValera.DB;Trusted_Connection=True;";

        public List<WorkTimeDTO> GetAllWorkTimes()
        {
            using (var connection = new SqlConnection(connectionString))
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
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<WorkTimeDTO>(
                    StoredProcedures.WorkTime_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddWorkTime(string date, string startTime, string finishTime, int employeeId)
        {
            using (var connection = new SqlConnection(connectionString))
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

        public void UpdateWorkTimeById(int id, string date, string startTime, string finishTime, int employeeId)
        {
            using (var connection = new SqlConnection(connectionString))
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
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkTimeDTO>(
                    StoredProcedures.WorkTime_DeleteById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void ChangeEmployeeScheduleByEmployeeIdByDate(int id, string date, string startTime, string finishTime)
        {
            using (var connection = new SqlConnection(connectionString))
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
