using Dapper;
using System.Data.SqlClient;
using CliningContoraFromValera.DAL.Dtos;

namespace CliningContoraFromValera.DAL.Managers
{
    public class WorkAreaManager
    {
        public List<WorkAreaDto> GetAllWorkAreas()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<WorkAreaDto>(
                    StoredProcedures.WorkArea_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public WorkAreaDto GetWorkAreaByID(int workAreaId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<WorkAreaDto>(
                    StoredProcedures.WorkArea_GetById,
                    param: new { id = workAreaId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddWorkArea(WorkAreaDto newWorkArea)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<WorkAreaDto>(
                    StoredProcedures.WorkArea_Add,
                    param: new
                    { newWorkArea.Name},
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateWorkAreaById(WorkAreaDto newWorkArea)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkAreaDto>(
                    StoredProcedures.WorkArea_UpdateById,
                    param: new
                    {
                        newWorkArea.Id,
                        newWorkArea.Name,
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteWorkAreaById(int workAreaId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkAreaDto>(
                    StoredProcedures.WorkArea_DeleteById,
                    param: new { id = workAreaId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
