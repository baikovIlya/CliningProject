using Dapper;
using System.Data.SqlClient;

namespace CliningContoraFromValera.DAL
{
    public class ServiceTypeManager
    {
        public List<ServiceTypeDTO> GetAllServices()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<ServiceTypeDTO>(
                    StoredProcedures.ServiceType_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public ServiceTypeDTO GetServicetById(int id)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<ServiceTypeDTO>(
                    StoredProcedures.ServiceType_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddServiceType(string name)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<ServiceTypeDTO>(
                    StoredProcedures.ServiceType_Add,
                    param: new { Name = name},
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateServiceTypeById(int id, string name)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<ServiceTypeDTO>(
                    StoredProcedures.ServiceType_UpdateById,
                    param: new { id = id, Name = name },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteServiceTypeById(int id)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<ServiceTypeDTO>(
                    StoredProcedures.ServiceType_DeleteById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
