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

        public WorkTimeDTO GetWorkTimeById(int id)
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

        public void DeleteWorkTimeById(WorkTimeDTO newWokrTime)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkTimeDTO>(
                    StoredProcedures.WorkTime_DeleteById,
                    param: new { newWokrTime.Id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void ChangeEmployeeScheduleByEmployeeIdByDate(WorkTimeDTO newWokrTime)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkTimeDTO>(
                    StoredProcedures.ChangeEmployeeScheduleByEmployeeIdByDate,
                    param: new
                    {
                        newWokrTime.EmployeeId,
                        newWokrTime.Date,
                        newWokrTime.StartTime,
                        newWokrTime.FinishTime
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
