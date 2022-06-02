using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class EmployeeModelManager
    {
        EmployeeManager EmployeeManager = new EmployeeManager();

        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeDTO> employees = EmployeeManager.GetAllEmployees();
            return MapperConfigStorage.GetInstance().Map<List<EmployeeModel>>(employees);
        }

        public EmployeeModel GetEmployeeById(int employeeId)
        {
            EmployeeDTO employee = EmployeeManager.GetEmployeeByID(employeeId);
            return MapperConfigStorage.GetInstance().Map<EmployeeModel>(employee);
        }
    }
}
