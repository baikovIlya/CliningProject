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
    }
}
