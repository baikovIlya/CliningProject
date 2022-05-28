using CliningContoraFromValera.DAL.DTOs;
using Dapper;
using System.Data.SqlClient;

namespace CliningContoraFromValera.DAL
{
    public class OrderManager
    {
        public List<OrderDTO> GetAllOrders()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<OrderDTO>(
                    StoredProcedures.Order_GetAll, 
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public OrderDTO GetOrderById(int id)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<OrderDTO>(
                    StoredProcedures.Order_GetById,
                    param: new {id = id},
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void AddOrder(OrderDTO newOrder)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<OrderDTO>(
                    StoredProcedures.Order_Add,
                    param: new
                    {
                        newOrder.Date,
                        newOrder.StartTime,
                        newOrder.EstimatedEndTime,
                        newOrder.FinishTime,
                        newOrder.Price,
                        newOrder.Status,
                        newOrder.CountOfEmployees,
                        newOrder.IsCommercial,
                        newOrder.ClientId,
                        newOrder.AddressId
                    },
                    commandType: System.Data.CommandType.StoredProcedure);          
            }
        }

        public void UpdateOrderById(OrderDTO newOrder)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<OrderDTO>(
                    StoredProcedures.Order_UpdateById,
                    param: new
                    {
                        newOrder.Id,
                        newOrder.Date,
                        newOrder.StartTime,
                        newOrder.EstimatedEndTime,
                        newOrder.FinishTime,
                        newOrder.Price,
                        newOrder.Status,
                        newOrder.CountOfEmployees,
                        newOrder.IsCommercial,
                        newOrder.ClientId,
                        newOrder.AddressId
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void DeleteOrderById(OrderDTO newOrder)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<OrderDTO>(
                    StoredProcedures.Order_DeleteById,
                    param: new { newOrder.Id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

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
    }
}
