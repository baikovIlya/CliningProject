using Dapper;
using System.Data.SqlClient;
using CliningContoraFromValera.DAL.Dtos;

namespace CliningContoraFromValera.DAL.Managers
{
    public class ServiceManager
    {
        public List<ServiceDto> GetAllServices()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<ServiceDto>(
                    StoredProcedures.Service_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public ServiceDto GetServiceById(int serviceId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<ServiceDto>(
                    StoredProcedures.Service_GetById,
                    param: new { id = serviceId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddService(ServiceDto newService)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<ServiceDto>(
                    StoredProcedures.Service_Add,
                    param: new
                    {
                        newService.ServiceType,
                        newService.Name,
                        newService.Description,
                        newService.Price,
                        newService.CommercialPrice,
                        newService.Unit,
                        newService.EstimatedTime
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateServiceById(ServiceDto newService)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<ServiceDto>(
                    StoredProcedures.Service_UpdateById,
                    param: new
                    {
                        newService.Id,
                        newService.ServiceType,
                        newService.Name,
                        newService.Description,
                        newService.Price,
                        newService.CommercialPrice,
                        newService.Unit,
                        newService.EstimatedTime
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteServiceById(int serviceId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<ServiceDto>(
                    StoredProcedures.Service_DeleteById,
                    param: new { id = serviceId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }



    }
}
