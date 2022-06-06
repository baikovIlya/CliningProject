using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class ServiceOrderModelManager
    {
        ServiceOrderManager _serviceOrderManager = new ServiceOrderManager();
        OrderManager orderManager = new OrderManager();

        public void AddServiceToOrder(ServiceOrderModel serviceOrderModel)
        {
            ServiceOrderDTO serviceOrderDTO = MapperConfigStorage.GetInstance().Map<ServiceOrderDTO>(serviceOrderModel);
            _serviceOrderManager.AddServiceToOrder(serviceOrderDTO);
        }

        public void DeleteServiceFromOrder(ServiceOrderModel serviceOrderModel)
        {
            _serviceOrderManager.DeleteServiceFromOrder(serviceOrderModel.OrderId, serviceOrderModel.ServiceId);
        }

        public List<ServiceOrderModel> GetOrdersServices(int orderId)
        {
            OrderDTO orderService = orderManager.GetOrdersServices(orderId);
            return MapperConfigStorage.GetInstance().Map<List<ServiceOrderModel>>(orderService.Services);
        }

    }
}
