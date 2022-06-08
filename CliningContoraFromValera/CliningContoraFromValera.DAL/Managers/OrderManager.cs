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
                connection.Query<OrderDTO, ClientDTO, AddressDTO, WorkAreaDTO, OrderDTO>(
                    StoredProcedures.Order_GetAll,
                    (order, client, address, wokrArea) => {
                        if (!result.ContainsKey(order.Id))
                        {
                            result.Add(order.Id, order);
                        }
                        OrderDTO crnt = result[order.Id];
                        if (order !=  null && client != null && crnt.Client == null)
                        {
                           crnt.Client = client;    
                        }
                        if (order != null && address != null && crnt.Address == null)
                        {
                           crnt.Address = address;
                        }
                        if (order != null && address != null && wokrArea != null
                        && crnt.Address!.WorkArea == null)
                        {
                            crnt.Address!.WorkArea = wokrArea;
                        }
                        return crnt;
                    },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "Id"
                );
                return result.Values.ToList();
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

        public OrderDTO GetOrdersServices(int orderId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();
                OrderDTO result = new OrderDTO();
                List<int> serviceId = new List<int>();
                connection.Query<OrderDTO, ServiceDTO, ServiceOrderDTO, OrderDTO >(
                    StoredProcedures.GetOrdersService,
                    (order, service, serviceOrder) =>
                    {
                        if (order != null && result.Id != order.Id)
                        {
                            result = order;
                        }
                        if (result.Services == null)
                        {
                            result.Services = new List<ServiceDTO>();
                        }
                        if (order != null && service != null && !serviceId.Contains(service.Id))
                        {
                            serviceId.Add(service.Id);
                            result.Services!.Add(service);
                            for (int i = 0; i <= result.Services.Count - 1; i++)
                            {
                                ServiceDTO crntServiceOrder = result.Services[i];
                                if (crntServiceOrder.ServiceOrder == null)
                                {
                                    crntServiceOrder.ServiceOrder = new ServiceOrderDTO();
                                }
                                if (serviceOrder.OrderId == result.Id
                                && serviceOrder.ServiceId == crntServiceOrder.Id)
                                {
                                    crntServiceOrder.ServiceOrder = serviceOrder;
                                }
                            }
                        }
                        return result;
                    },
                    param: new { id = orderId },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "Id"
                );
                return result;
            }
        }


        public List<OrderDTO> GetEmployeesOrdersByEmployeeIdByDateNew(int employeeId, DateTime date)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                Dictionary<int, OrderDTO> result = new Dictionary<int, OrderDTO>();

                connection.Query<OrderDTO, AddressDTO, OrderDTO>(
                    StoredProcedures.GetEmployeesScheduleByIdByDate,
                    (order, address) => {
                        if (!result.ContainsKey(order.Id))
                        {
                            result.Add(order.Id, order);
                        }

                        OrderDTO crnt = result[order.Id];

                        if (address != null)
                        {
                            crnt.Address = address;
                        }
                        return crnt;
                    },
                    param: new { employeeId, date },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "Id"
                );

                return result.Values.ToList();
            }
        }

        public List<OrderDTO> GetOrderHistoryOfTheEmployeeById(int employeeId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                Dictionary<int, OrderDTO> result = new Dictionary<int, OrderDTO>();

                connection.Query<OrderDTO, AddressDTO, WorkAreaDTO, ClientDTO, OrderDTO>(
                    StoredProcedures.GetOrderHistoryOfTheEmployeeById,
                    (order, address, workArea, client) => {
                        if (!result.ContainsKey(order.Id))
                        {
                            result.Add(order.Id, order);
                        }

                        OrderDTO crnt = result[order.Id];

                        if (address != null)
                        {
                            crnt.Address = address;
                        }
                        if (workArea != null)
                        {
                            crnt.Address!.WorkArea = workArea;
                        }
                        if (client != null)
                        {
                            crnt.Client = client;
                        }
                        return crnt;
                    },
                    param: new { employeeId },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "Id"
                );

                return result.Values.ToList();
            }
        }


    }
}
