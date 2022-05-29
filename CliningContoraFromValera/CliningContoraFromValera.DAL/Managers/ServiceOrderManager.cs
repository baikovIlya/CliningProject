using CliningContoraFromValera.DAL.DTOs;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CliningContoraFromValera.DAL.Managers
{
    public class ServiceOrderManager
    {
        public List<ServiceOrderDTO> GetAllOrderInfo()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                Dictionary<int, ServiceOrderDTO> result = new Dictionary<int, ServiceOrderDTO>();

                connection.Query<ServiceOrderDTO, OrderDTO, ServiceDTO, ServiceOrderDTO>(
                    "GetAllOrderServicesInfo",
                    (serviceOrder, order, service) => {
                        if (!result.ContainsKey(serviceOrder.Id))
                        {
                            result.Add(serviceOrder.Id, serviceOrder);
                        }

                        ServiceOrderDTO crnt = result[serviceOrder.Id];

                        if (order != null)
                        {
                            crnt.Orders.Add(order);
                        }
                        if (service != null)
                        {
                            crnt.Services.Add(service);
                        }
                        return crnt;
                    },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "Id"
                );

                return result.Values.ToList();
            }
        }

        public ServiceOrderDTO GetById(int id)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                ServiceOrderDTO result = new ServiceOrderDTO();

                 connection.Query<ServiceOrderDTO, OrderDTO, ServiceDTO, ServiceOrderDTO>(
                    "GetAllOrderServicesInfoById",
                    (serviceOrder, order, service) =>
                    {

                        ServiceOrderDTO crnt = result;

                        if (order != null)
                        {
                            crnt.Orders.Add(order);
                        }
                        if (service != null)
                        {
                            crnt.Services.Add(service);
                        }

                        return crnt;

                    },
                    param: new { id = id },
                    commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
        }

    }
}
