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

        public List<OrderDTO> GetAllOrderInfo()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                Dictionary<int, OrderDTO> result = new Dictionary<int, OrderDTO>();

                connection.Query<OrderDTO, ServiceOrderDTO, OrderDTO>(
                    "GetAllOrderServicesInfo",
                    (order, service) => {
                        if (!result.ContainsKey(order.Id))
                        {
                            result.Add(order.Id, order);
                        }

                        OrderDTO crnt = result[order.Id];

                        if (service != null)
                        {
                            crnt.OrderServices.Add(service);
                        }

                        return crnt;
                    },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "id"
                );

                return result.Values.ToList();
            }
        }
    }
}
