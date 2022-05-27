using Dapper;
using System.Data.SqlClient;

namespace CliningContoraFromValera.DAL
{
    public class WorkAreaManager
    {
        public List<WorkAreaDTO> GetAllWorkAreas()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<WorkAreaDTO>(
                    StoredProcedures.WorkArea_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public WorkAreaDTO GetWorkAreaByID(int id)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<WorkAreaDTO>(
                    StoredProcedures.WorkArea_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddWorkArea(WorkAreaDTO newWorkArea)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<WorkAreaDTO>(
                    StoredProcedures.WorkArea_Add,
                    param: new
                    { newWorkArea.Name},
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateClientById(WorkAreaDTO newWorkArea)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkAreaDTO>(
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

        public void DeleteClientById(WorkAreaDTO newWorkArea)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkAreaDTO>(
                    StoredProcedures.WorkArea_DeleteById,
                    param: new { newWorkArea.Id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
