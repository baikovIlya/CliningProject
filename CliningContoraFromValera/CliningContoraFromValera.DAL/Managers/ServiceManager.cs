using Dapper;
using System.Data.SqlClient;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.DAL.Managers
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

        public ServiceDTO GetServiceById(int serviceId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<ServiceDTO>(
                    StoredProcedures.Service_GetById,
                    param: new { id = serviceId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddService(ServiceDTO newService)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<ServiceDTO>(
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

        public void UpdateServiceById(ServiceDTO newService)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<ServiceDTO>(
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

                connection.QuerySingleOrDefault<ServiceDTO>(
                    StoredProcedures.Service_DeleteById,
                    param: new { id = serviceId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }



    }
}
