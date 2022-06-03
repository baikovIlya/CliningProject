using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.DTOs;
using CliningContoraFromValera.DAL.Managers;


namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class EmployeeWorkTimeModelManager
    {
        public List<EmployeeWorkTimeModel> GetEmployeesAndWorkTimes()
        {
            WorkTimeManager workTimeManager = new WorkTimeManager();

            List<EmployeeDTO> workTimes = workTimeManager.GetEmployeesAndWorkTimes();
            return MapperConfigStorage.GetInstance().Map<List<EmployeeWorkTimeModel>>(workTimes);
        }

        public List<EmployeeWorkTimeModel> GetSuitableEmployees(DateTime date, int serviceId, int workAreaId)
        {
            EmployeeManager employeeManager = new EmployeeManager();

            List<EmployeeDTO> employyes = employeeManager.GetEmployyesAvailableForOrder(date, serviceId, workAreaId);
            return MapperConfigStorage.GetInstance().Map<List<EmployeeWorkTimeModel>>(employyes);
        }
    }
}
