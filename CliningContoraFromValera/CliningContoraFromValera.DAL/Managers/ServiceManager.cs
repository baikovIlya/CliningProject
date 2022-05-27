using Dapper;
using System.Data.SqlClient;

namespace CliningContoraFromValera.DAL
{
    public class ServiceManager
    {
        public List<ServiceDTO> GetAllServices()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<ServiceDTO>(
                    StoredProcedures.Service_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public ServiceDTO GetServicetById(int id)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<ServiceDTO>(
                    StoredProcedures.Service_GetById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddService(string name, string description, decimal price, decimal commercialPrice, string unit, int serviceTypeId, TimeOnly estimatedTime)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<ServiceDTO>(
                    StoredProcedures.Service_Add,
                    param: new
                    {
                        Name = name,
                        Description = description,
                        Price = price,
                        CommercialPrice = commercialPrice,
                        Unit = unit,
                        ServiceTypeId = serviceTypeId,
                        EstimatedTime = estimatedTime
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateServiceById(int id, string name, string description, decimal price, decimal commercialPrice, string unit, int serviceTypeId, TimeOnly estimatedTime)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<ServiceDTO>(
                    StoredProcedures.Service_UpdateById,
                    param: new
                    {
                        id = id,
                        Name = name,
                        Description = description,
                        Price = price,
                        CommercialPrice = commercialPrice,
                        Unit = unit,
                        ServiceTypeId = serviceTypeId,
                        EstimatedTime = estimatedTime
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteServiceById(int id)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<ServiceDTO>(
                    StoredProcedures.Service_DeleteById,
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
