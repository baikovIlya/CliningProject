using Dapper;
using System.Data.SqlClient;

namespace CliningContoraFromValera.DAL
{
    public class ClientManager
    {
        public List<ClientDTO> GetAllClients()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<ClientDTO>(
                    StoredProcedures.Client_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public ClientDTO GetClientByID(int id)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<ClientDTO>(
                    StoredProcedures.Client_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddClient(ClientDTO newClient)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<ClientDTO>(
                    StoredProcedures.Client_Add,
                    param: new { 
                        newClient.FirstName,
                        newClient.LastName, 
                        newClient.Email,
                        newClient.Phone
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateClientById(ClientDTO newClient)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<ClientDTO>(
                    StoredProcedures.Client_UpdateById,
                    param: new
                    {
                        newClient.Id,
                        newClient.FirstName,
                        newClient.LastName,
                        newClient.Email,
                        newClient.Phone
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteClientById(ClientDTO newClient)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<ClientDTO>(
                    StoredProcedures.Client_DeleteById,
                    param: new { newClient.Id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }


    }
}
