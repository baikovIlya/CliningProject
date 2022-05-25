using CliningContoraFromValera.DAL;
using Dapper;
using System.Data.SqlClient;

namespace CliningContoraFromValera.DAL
{
    public class ClientManager
    {
        public string connectionString = @"Server=.;Database=CliningContoraFromValera.DB;Trusted_Connection=True;";

        public List<ClientDTO> GetAllClients()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<ClientDTO>(
                    "Client_GetAll",
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public ClientDTO GetClientByID(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<ClientDTO>(
                    "Client_GetById",
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
