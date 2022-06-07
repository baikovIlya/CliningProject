using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class EmployeeModelManager
    {
        EmployeeManager employeeManager = new EmployeeManager();

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

        public List<ServiceModel> GetEmployeesServicesById(int employeeId)
        {
            EmployeeDTO employeesService = employeeManager.GetAllEmployeesServicesById(employeeId);
            return MapperConfigStorage.GetInstance().Map<List<ServiceModel>>(employeesService.Services);
        }

        public void AddOrderToEmployee(int employeeId, int orderId)
        {
            employeeManager.AddOrderToEmployee(employeeId, orderId);
        }

        public List<EmployeeModel> GetEmployeesInOrderByOrdeerId(int orderId)
        {
            List<EmployeeDTO> employees = employeeManager.GetEmployeesInOrderByOrderId(orderId);
            return MapperConfigStorage.GetInstance().Map<List<EmployeeModel>>(employees);
        }
    }
}
