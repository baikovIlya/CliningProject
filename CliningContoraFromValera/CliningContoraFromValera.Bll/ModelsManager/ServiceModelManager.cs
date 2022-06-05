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
