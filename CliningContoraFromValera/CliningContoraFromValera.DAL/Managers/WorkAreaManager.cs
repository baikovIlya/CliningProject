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

        public void AddWorkArea(string Name)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<WorkAreaDTO>(
                    StoredProcedures.WorkArea_Add,
                    param: new
                    {
                        Name = Name
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateClientById(int id, string Name)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkAreaDTO>(
                    StoredProcedures.WorkArea_UpdateById,
                    param: new
                    {
                        id = id,
                        Name = Name,
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteClientById(int id)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkAreaDTO>(
                    StoredProcedures.WorkArea_DeleteById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
