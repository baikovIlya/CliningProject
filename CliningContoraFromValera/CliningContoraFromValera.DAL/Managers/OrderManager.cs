using Dapper;
using System.Data.SqlClient;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.DAL.Managers
{
    public class OrderManager
    {

        public List<OrderDTO> GetAllOrder()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                Dictionary<int, OrderDTO> result = new Dictionary<int, OrderDTO>();

                connection.Query<OrderDTO, ClientDTO, AddressDTO, ServiceOrderDTO, ServiceDTO, OrderDTO>(
                    StoredProcedures.Order_GetAll,
                    (order, client, address, serviceOrder, service) => {
                        if (!result.ContainsKey(order.Id))
                        {
                            result.Add(order.Id, order);
                        }

                        OrderDTO crnt = result[order.Id];
                        if (client != null)
                        {
                           crnt.Client = client;    
                        }
                        if (address != null)
                        {
                           crnt.Address = address;
                        }
                        if(serviceOrder != null)
                        {
                            crnt.ServiceOrder.Add(serviceOrder);
                        }
                        if(service != null)
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







        //public List<OrderDTO> GetAllOrders()
        //{
        //    using (var connection = new SqlConnection(ServerSettings._connectionString))
        //    {
        //        connection.Open();

        //        return connection.Query<OrderDTO>(
        //            StoredProcedures.Order_GetAll, 
        //            commandType: System.Data.CommandType.StoredProcedure)
        //            .ToList();
        //    }
        //}

        public OrderDTO GetOrderById(int orderId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<OrderDTO>(
                    StoredProcedures.Order_GetById,
                    param: new { id = orderId },
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

        public void DeleteOrderById(int orderId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<OrderDTO>(
                    StoredProcedures.Order_DeleteById,
                    param: new { id = orderId },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void DeleteServiceFromOrder(int serviceId, int orderId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<OrderDTO>(
                    StoredProcedures.Service_Order_DeleteByValue,
                    param: new { ServiceId = serviceId, OrderId = orderId },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
