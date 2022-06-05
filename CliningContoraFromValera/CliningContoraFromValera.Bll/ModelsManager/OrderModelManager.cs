using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class OrderModelManager
    {
        OrderManager orderManager = new OrderManager();

        public List<OrderModel> GetAllOrder()
        {
            List<OrderDTO> orders = orderManager.GetAllOrder();
            return MapperConfigStorage.GetInstance().Map<List<OrderModel>>(orders);
        }

        public List<OrderModel> GetAllEmployeesOrdersByDate(int employeeId, DateTime date)
        {
            List<OrderDTO> orders = orderManager.GetEmployeesOrdersByEmployeeIdByDateNew(employeeId, date);
            return MapperConfigStorage.GetInstance().Map<List<OrderModel>>(orders);
        }

        public OrderModel GetOrdersServices(int orderId)
        {
            OrderDTO orderService = orderManager.GetOrdersServices(orderId);
            return MapperConfigStorage.GetInstance().Map<OrderModel>(orderService);
        }
    }
}
