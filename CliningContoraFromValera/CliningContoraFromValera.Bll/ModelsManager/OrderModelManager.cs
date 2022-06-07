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
    }
}
