using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class ServiceOrderModelManager
    {
        ServiceOrderManager _serviceOrderManager = new ServiceOrderManager();
        OrderManager _orderManager = new OrderManager();

        public void AddServiceToOrder(ServiceOrderModel serviceOrderModel)
        {
            _serviceOrderManager.AddServiceToOrder(serviceOrderModel.OrderId, serviceOrderModel.ServiceId, serviceOrderModel.Count);
        }

        public void DeleteServiceFromOrder(ServiceOrderModel serviceOrderModel)
        {
            _serviceOrderManager.DeleteServiceFromOrder(serviceOrderModel.OrderId, serviceOrderModel.ServiceId);
        }

        public List<ServiceOrderModel> GetOrdersServices(int orderId)
        {
            OrderDTO orderService = _orderManager.GetOrdersServices(orderId);
            return MapperConfigStorage.GetInstance().Map<List<ServiceOrderModel>>(orderService.Services);
        }

    }
}
