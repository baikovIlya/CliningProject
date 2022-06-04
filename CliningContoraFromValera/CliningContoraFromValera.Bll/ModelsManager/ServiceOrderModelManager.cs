using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class ServiceOrderModelManager
    {
        ServiceOrderManager _serviceOrderManager = new ServiceOrderManager();

        public void AddServiceToOrder(ServiceOrderModel serviceOrderModel)
        {
            ServiceOrderDTO serviceOrderDTO = MapperConfigStorage.GetInstance().Map<ServiceOrderDTO>(serviceOrderModel);
            _serviceOrderManager.AddServiceFromOrder(serviceOrderDTO);
        }

        public void DeleteServiceFromOrder(ServiceOrderModel serviceOrderModel)
        {
            _serviceOrderManager.DeleteServiceFromOrder(serviceOrderModel.OrderId, serviceOrderModel.ServiceId);
        }
    }
}
