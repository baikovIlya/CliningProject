using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.DTOs;
using CliningContoraFromValera.DAL.Managers;


namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class EmployeeWorkTimeModelManager
    {
        WorkTimeManager workTimeManager = new WorkTimeManager();
        public List<EmployeeWorkTimeModel> GetEmployeesAndWorkTimes()
        {
            List<EmployeeDTO> workTimes = workTimeManager.GetEmployeesAndWorkTimes();
            return MapperConfigStorage.GetInstance().Map<List<EmployeeWorkTimeModel>>(workTimes);
        }
    }
}
