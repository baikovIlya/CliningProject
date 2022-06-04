using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.DTOs;
using CliningContoraFromValera.DAL.Managers;


namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class EmployeeWorkTimeModelManager
    {
            WorkTimeManager WorkTimeManager = new WorkTimeManager();

        public List<EmployeeWorkTimeModel> GetEmployeesAndWorkTimes()
        {

            List<EmployeeDTO> workTimes = WorkTimeManager.GetEmployeesAndWorkTimes();
            return MapperConfigStorage.GetInstance().Map<List<EmployeeWorkTimeModel>>(workTimes);
        }

        public List<EmployeeWorkTimeModel> GetEmployeesSchedule(DateTime minData, DateTime maxData)
        {
            List<EmployeeDTO> workTimes = WorkTimeManager.GetEmployeesSchedule(minData, maxData);
            return MapperConfigStorage.GetInstance().Map<List<EmployeeWorkTimeModel>>(workTimes);
        }
    }
}
