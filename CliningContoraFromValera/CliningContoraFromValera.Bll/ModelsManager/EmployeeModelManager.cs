using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.Dtos;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class EmployeeModelManager
    {
        EmployeeManager EmployeeManager = new EmployeeManager();

        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeDto> employees = EmployeeManager.GetAllEmployees();
            return MapperConfigStorage.GetInstance().Map<List<EmployeeModel>>(employees);
        }

        public EmployeeModel GetEmployeeById(int employeeId)
        {
            EmployeeDto employee = EmployeeManager.GetEmployeeByID(employeeId);
            return MapperConfigStorage.GetInstance().Map<EmployeeModel>(employee);
        }

        public void UpdateEmployeeById(EmployeeModel employeeModel)
        {
            EmployeeDto employee = MapperConfigStorage.GetInstance().Map<EmployeeDto>(employeeModel);
            EmployeeManager.UpdateEmployeeById(employee);
        }

        public void AddEmployee(EmployeeModel employeeModel)
        {
            EmployeeDto employee = MapperConfigStorage.GetInstance().Map<EmployeeDto>(employeeModel);
            EmployeeManager.AddEmployee(employee);
        }

        public void DeleteEmployeeById(int employeeId)
        {
            EmployeeManager.DeleteEmployeeById(employeeId);
        }
    }
}
