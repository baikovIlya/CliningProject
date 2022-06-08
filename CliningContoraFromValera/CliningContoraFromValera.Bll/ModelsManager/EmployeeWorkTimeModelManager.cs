using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.DTOs;
using CliningContoraFromValera.DAL.Managers;


namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class EmployeeWorkTimeModelManager
    {
        WorkTimeManager _workTimeManager = new WorkTimeManager();
        public List<EmployeeWorkTimeModel> GetEmployeesAndWorkTimes()
        {
            List<EmployeeDTO> workTimes = _workTimeManager.GetEmployeesAndWorkTimes();
            return MapperConfigStorage.GetInstance().Map<List<EmployeeWorkTimeModel>>(workTimes);
        }

        public List<EmployeeWorkTimeModel> GetSuitableEmployees(DateTime date, int serviceId, int workAreaId)
        {
            EmployeeManager employeeManager = new EmployeeManager();

            List<EmployeeDTO> employyes = employeeManager.GetEmployyesAvailableForOrder(date, serviceId, workAreaId);
            return MapperConfigStorage.GetInstance().Map<List<EmployeeWorkTimeModel>>(employyes);
        }

        public List<EmployeeWorkTimeModel> GetEmployeesSchedule(DateTime minData, DateTime maxData)
        {
            List<EmployeeDTO> workTimes = _workTimeManager.GetEmployeesSchedule(minData, maxData);
            return MapperConfigStorage.GetInstance().Map<List<EmployeeWorkTimeModel>>(workTimes);
        }
    }
}
