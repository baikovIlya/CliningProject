using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;


namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class ServiceModelManager
    {
        ServiceManager _serviceManager = new ServiceManager();
        EmployeeManager employeeManager = new EmployeeManager();

        public List<ServiceModel> GetAllServices()
        {
            List<ServiceDTO> serviceDTOs = _serviceManager.GetAllServices();
            return MapperConfigStorage.GetInstance().Map<List<ServiceModel>>(serviceDTOs);
        }

        public void DeleteEmployeesService(int employeeId, int serviceId)
        {
            employeeManager.DeleteEmployeesService(employeeId, serviceId);
        }
    }
}
