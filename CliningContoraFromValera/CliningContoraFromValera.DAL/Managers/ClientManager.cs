using Dapper;
using System.Data.SqlClient;
using CliningContoraFromValera.DAL.Dtos;

namespace CliningContoraFromValera.DAL.Managers
{
    public class ClientManager
    {
        public List<ClientDto> GetAllClients()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<ClientDto>(
                    StoredProcedures.Client_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public ClientDto GetClientByID(int clientId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<ClientDto>(
                    StoredProcedures.Client_GetById,
                    param: new { id = clientId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddClient(ClientDto newClient)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<ClientDto>(
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

        public void UpdateClientById(ClientDto newClient)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<ClientDto>(
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

        public void DeleteClientById(int clientId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<ClientDto>(
                    StoredProcedures.Client_DeleteById,
                    param: new { id = clientId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }


    }
}
