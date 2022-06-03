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

        //public OrderDTO GetOrderById(int orderId)
        //{
        //    using (var connection = new SqlConnection(ServerSettings._connectionString))
        //    {
        //        connection.Open();

        //        return connection.QuerySingle<OrderDTO>(
        //            StoredProcedures.Order_GetById,
        //            param: new { id = orderId },
        //            commandType: System.Data.CommandType.StoredProcedure);
        //    }
        //}

        public void AddOrder(OrderDTO newOrder, ClientDTO newClient, AddressDTO newAddress, WorkAreaDTO newWorkArea,
            ServiceDTO newService, ServiceOrderDTO newServiceOrder, int count)
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
            ClientManager clientManager = new ClientManager();
            clientManager.AddClient(newClient);
            AddressManager addressManager = new AddressManager();
            addressManager.AddAddress(newAddress);
            WorkAreaManager workAreaManager = new WorkAreaManager();
            workAreaManager.AddWorkArea(newWorkArea);
            ServiceManager servicsManager = new ServiceManager();
            servicsManager.AddService(newService);
            ServiceOrderManager serviceOrderManager = new ServiceOrderManager();
            serviceOrderManager.AddServiceFromOrder(newOrder.Id, newService.Id, count);
        }

        public void UpdateOrderById(OrderDTO newOrder, ClientDTO newClient, AddressDTO newAddress, WorkAreaDTO newWorkArea,
            ServiceDTO newService, ServiceOrderDTO newServiceOrder, int count)
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
            ClientManager clientManager = new ClientManager();
            clientManager.UpdateClientById(newClient);
            AddressManager addressManager = new AddressManager();
            addressManager.UpdateAddressById(newAddress);
            WorkAreaManager workAreaManager = new WorkAreaManager();
            workAreaManager.UpdateWorkAreaById(newWorkArea);
            ServiceManager servicsManager = new ServiceManager();
            servicsManager.UpdateServiceById(newService);
            ServiceOrderManager serviceOrderManager = new ServiceOrderManager();
            serviceOrderManager.DeleteServiceFromOrder(newOrder.Id, newService.Id);
            serviceOrderManager.AddServiceFromOrder(newOrder.Id, newService.Id, count);
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

        public OrderDTO GetOrdersServices(int ordersService)
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
                    param: new { id = ordersService },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "Id"
                );
                return result;
            }
        }

    }
}
