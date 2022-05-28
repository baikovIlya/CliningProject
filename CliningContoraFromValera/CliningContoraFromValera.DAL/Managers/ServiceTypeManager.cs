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

        public ServiceTypeDTO GetServicetById(int serviceTypeId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<ServiceTypeDTO>(
                    StoredProcedures.ServiceType_GetById,
                    param: new { serviceTypeId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddServiceType(ServiceTypeDTO newServiceType)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<ServiceTypeDTO>(
                    StoredProcedures.ServiceType_Add,
                    param: new { newServiceType.Name},
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateServiceTypeById(ServiceTypeDTO newServiceType)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<ServiceTypeDTO>(
                    StoredProcedures.ServiceType_UpdateById,
                    param: new { newServiceType.Id, newServiceType.Name },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteServiceTypeById(int serviceTypeId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<ServiceTypeDTO>(
                    StoredProcedures.ServiceType_DeleteById,
                    param: new { serviceTypeId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
