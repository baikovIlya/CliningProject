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
                    StoredProcedures.Client_GetAll,
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
                    StoredProcedures.Client_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddClient(int id, string firstName, string lastName, string email, string phone)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.QuerySingle<ClientDTO>(
                    StoredProcedures.Client_Add,
                    param: new { 
                        id = id,
                        FirstName = firstName,
                        LastName = lastName, 
                        Email = email,
                        Phone = phone},
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateClientById(int id, string firstName, string lastName, string email, string phone)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<ClientDTO>(
                    StoredProcedures.Client_UpdateById,
                    param: new
                    {
                        id = id,
                        FirstName = firstName,
                        LastName = lastName,
                        Email = email,
                        Phone = phone
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteClientById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<ClientDTO>(
                    StoredProcedures.Client_DeleteById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }


    }
}
