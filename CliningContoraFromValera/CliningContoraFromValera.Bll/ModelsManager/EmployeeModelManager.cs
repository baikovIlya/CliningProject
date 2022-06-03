using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.DTOs;
using CliningContoraFromValera.DAL.Managers;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class EmployeeModelManager
    {
        EmployeeManager EmployeeManager = new EmployeeManager();

        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeDTO> clients = EmployeeManager.GetAllEmployees();
            return MapperConfigStorage.GetInstance().Map<List<EmployeeModel>>(clients);
        }

        public EmployeeModel GetEmployeeById(int employeeId)
        {
            EmployeeDTO employee = EmployeeManager.GetEmployeeByID(employeeId);
            return MapperConfigStorage.GetInstance().Map<EmployeeModel>(employee);
        }



    }
}
