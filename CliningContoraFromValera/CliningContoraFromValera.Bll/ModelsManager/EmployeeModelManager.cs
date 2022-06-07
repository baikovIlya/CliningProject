using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class EmployeeModelManager
    {
        EmployeeManager employeeManager = new EmployeeManager();
        WorkAreaModelManager _workAreaManager = new WorkAreaModelManager();
        ServiceModelManager _serviceManager = new ServiceModelManager();

        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeDTO> employees = employeeManager.GetAllEmployees();
            return MapperConfigStorage.GetInstance().Map<List<EmployeeModel>>(employees);
        }

        public EmployeeModel GetEmployeeById(int employeeId)
        {
            EmployeeDTO employee = employeeManager.GetEmployeeByID(employeeId);
            return MapperConfigStorage.GetInstance().Map<EmployeeModel>(employee);
        }

        public void UpdateEmployeeById(EmployeeModel employeeModel)
        {
            EmployeeDTO employee = MapperConfigStorage.GetInstance().Map<EmployeeDTO>(employeeModel);
            employeeManager.UpdateEmployeeById(employee);
        }

        public void AddEmployee(EmployeeModel employeeModel)
        {
            EmployeeDTO employee = MapperConfigStorage.GetInstance().Map<EmployeeDTO>(employeeModel);
            employeeManager.AddEmployee(employee);
        }

        public void DeleteEmployeeById(int employeeId)
        {
            employeeManager.DeleteEmployeeById(employeeId);
        }

        public List<WorkAreaModel> GetEmployeesWorkAreasById(int employeeId)
        {
            EmployeeDTO employeesWorkArea = employeeManager.GetAllEmployeesWorkAreasById(employeeId);
            return MapperConfigStorage.GetInstance().Map<List<WorkAreaModel>>(employeesWorkArea.WorkAreas);
        }

        public List<WorkAreaModel> GetEmployeesUnableWorkAreasById(int employeeId)
        {
            List<WorkAreaModel> result = new List<WorkAreaModel>();
            List<WorkAreaModel> allWorkAreas = _workAreaManager.GetAllWorkAreas();
            List<WorkAreaModel> actualWorkAreas = GetEmployeesWorkAreasById(employeeId);
            for(int i=0; i<allWorkAreas.Count; i++)
            {
                WorkAreaModel workAreaModel = allWorkAreas[i];
                result.Add(workAreaModel);
                for (int j=0; j<actualWorkAreas.Count; j++)
                {
                    if (workAreaModel.Id == actualWorkAreas[j].Id)
                    {
                        result.Remove(workAreaModel);
                        break;
                    }
                }
            }
            return result;
        }

        public List<ServiceModel> GetEmployeesServicesById(int employeeId)
        {
            EmployeeDTO employeesService = employeeManager.GetAllEmployeesServicesById(employeeId);
            return MapperConfigStorage.GetInstance().Map<List<ServiceModel>>(employeesService.Services);
        }
        public List<ServiceModel> GetEmployeesUnableServicesById(int employeeId)
        {
            List<ServiceModel> result = new List<ServiceModel>();
            List<ServiceModel> allServices = _serviceManager.GetAllServices();
            List<ServiceModel> actualServices = GetEmployeesServicesById(employeeId);
            for (int i = 0; i < allServices.Count; i++)
            {
                ServiceModel service = allServices[i];
                result.Add(service);
                for (int j = 0; j < actualServices.Count; j++)
                {
                    if (service.Id == actualServices[j].Id)
                    {
                        result.Remove(service);
                        break;
                    }
                }
            }
            return result;

        }


        public void AddOrderToEmployee(int employeeId, int orderId)
        {
            employeeManager.AddOrderToEmployee(employeeId, orderId);
        }
        public void AddWorkAreaToEmployee(int employeeID, int workAreaId)
        {
            employeeManager.AddWorkAreaToEmployee(employeeID, workAreaId);
        }

        public List<EmployeeModel> GetEmployeesInOrderByOrdeerId(int orderId)
        {
            List<EmployeeDTO> employees = employeeManager.GetEmployeesInOrderByOrderId(orderId);
            return MapperConfigStorage.GetInstance().Map<List<EmployeeModel>>(employees);
        }

        public void DeleteEmployeesFromOrder(int employeeId, int orderId)
        {
            employeeManager.DeleteEmployeesOrder(employeeId, orderId);
        }

    }
}
