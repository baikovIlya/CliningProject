using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class OrderModelManager
    {
        OrderManager _orderManager = new OrderManager();
        ClientManager _clientManager = new ClientManager();

        public List<OrderModel> GetAllOrder()
        {
            List<OrderDTO> orders = _orderManager.GetAllOrder();
            return MapperConfigStorage.GetInstance().Map<List<OrderModel>>(orders);
        }

        public List<OrderModel> GetAllEmployeesOrdersByDate(int employeeId, DateTime date)
        {
            List<OrderDTO> orders = _orderManager.GetEmployeesOrdersByEmployeeIdByDateNew(employeeId, date);
            return MapperConfigStorage.GetInstance().Map<List<OrderModel>>(orders);
        }

        public void AddOrder(OrderModel orderModel)
        {
            OrderDTO order = MapperConfigStorage.GetInstance().Map<OrderDTO>(orderModel);
            _orderManager.AddOrder(order);
        }
        public List<OrderModel> GetOrderHistoryOfTheEmployeeById(int employeeId)
        {
            List<OrderDTO> orders = _orderManager.GetOrderHistoryOfTheEmployeeById(employeeId);
            return MapperConfigStorage.GetInstance().Map<List<OrderModel>>(orders);
        }
        public List<OrderModel> GetAllOrdersByStatus(StatusType status)
        {
            List<OrderModel> allOrders = GetAllOrder();
            List<OrderModel> result = new List<OrderModel>();
            foreach (var ord in allOrders)
            {
                if(ord.Status == status)
                {
                    result.Add(ord);
                }
            }
            return result;
        }

        public void DeleteOrderById(int orderId)
        {
            _orderManager.DeleteOrderById(orderId);
        }
        public void GetOrdersPrice(OrderModel order, List<ServiceOrderModel> services)
        {
            decimal price = 0;
            if (services != null)
            {
                if (order.IsCommercial)
                {
                    for (int i = 0; i < services.Count; i++)
                    {
                        price = price + (services[i].CommercialPrice * services[i].Count);
                    }
                }
                else
                {
                    for (int i = 0; i < services.Count; i++)
                    {
                        price = price + (services[i].Price * services[i].Count);
                    }
                }
            }
            order.Price = price;
        }
        public void UpdateOrder(OrderModel order)
        {
            OrderDTO orderDTO = MapperConfigStorage.GetInstance().Map<OrderDTO>(order);
            _orderManager.UpdateOrderById(orderDTO);
        }
    }
}
