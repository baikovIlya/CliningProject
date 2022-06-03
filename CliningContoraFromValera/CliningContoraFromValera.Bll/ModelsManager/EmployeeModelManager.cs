using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL;
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

        public void GetEmployeesWorkAreasById(int employeeId)
        {
            employeeManager.DeleteEmployeeById(employeeId);
        }

        public void GetEmployeesServicesById(int employeeId)
        {
            employeeManager.DeleteEmployeeById(employeeId);
        }
    }
}
