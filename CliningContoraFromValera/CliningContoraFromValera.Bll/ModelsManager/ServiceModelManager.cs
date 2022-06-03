using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;


namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class ServiceModelManager
    {
        ServiceManager _serviceManager = new ServiceManager();

        public List<ServiceModel> GetAllServices()
        {
            List<ServiceDTO> serviceDTOs = _serviceManager.GetAllServices();
            return MapperConfigStorage.GetInstance().Map<List<ServiceModel>>(serviceDTOs);
        }

        public ServiceModel GetServiceById(int id)
        {
            ServiceDTO serviceDTO = _serviceManager.GetServiceById(id);
            return MapperConfigStorage.GetInstance().Map<ServiceModel>(serviceDTO);
        }
        public void AddService(ServiceModel service)
        {
            ServiceDTO serviceDTO = MapperConfigStorage.GetInstance().Map<ServiceDTO>(service);
            _serviceManager.AddService(serviceDTO);
        }
        public void UpdateService(ServiceModel service)
        {
            ServiceDTO serviceDTO = MapperConfigStorage.GetInstance().Map<ServiceDTO>(service);
            _serviceManager.UpdateServiceById(serviceDTO);
        }
    }
}
