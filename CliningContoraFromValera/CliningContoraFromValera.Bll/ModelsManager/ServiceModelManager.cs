using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;    


namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class ServiceModelManager
    {
        ServiceManager serviceManager = new ServiceManager();
        EmployeeManager employeeManager = new EmployeeManager();

        public List<ServiceModel> GetAllServices()
        {
            List<ServiceDTO> serviceDTOs = serviceManager.GetAllServices();
            return MapperConfigStorage.GetInstance().Map<List<ServiceModel>>(serviceDTOs);
        }
        public ServiceModel GetServiceById(int id)
        {
            ServiceDTO serviceDTO = serviceManager.GetServiceById(id);
            return MapperConfigStorage.GetInstance().Map<ServiceModel>(serviceDTO);
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
        public void DeleteServiceyId(int id)
        {
            _serviceManager.DeleteServiceById(id);
        }

        public List<ServiceModel> GetServicesByType(List<ServiceModel> list, ServiceType serviceType)
        {
            List<ServiceModel> result = new List<ServiceModel>();
            foreach(ServiceModel service in list)
            {
                if (service.ServiceType == serviceType)
                {
                    result.Add(service);
                }
            }
            return result;
        }
        public void DeleteEmployeesService(int employeeId, int serviceId)
        {
            employeeManager.DeleteEmployeesService(employeeId, serviceId);
        }

        public void AddServiceToEmployee(int employeeId, int serviceId)
        {
            employeeManager.AddServiceToEmployee(employeeId, serviceId);
        }

        public void AddService(ServiceModel service)
        {
            ServiceDTO serviceDTO = MapperConfigStorage.GetInstance().Map<ServiceDTO>(service);
            serviceManager.AddService(serviceDTO);
        }

        public void UpdateServiceById(ServiceModel service)
        {
            ServiceDTO serviceDTO = MapperConfigStorage.GetInstance().Map<ServiceDTO>(service);
            serviceManager.UpdateServiceById(serviceDTO);
        }
        public void DeleteServiceyId(int id)
        {
            serviceManager.DeleteServiceById(id);
        }
    }
}