using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Dtos;
using CliningContoraFromValera.DAL.Managers;


namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class EmployeeWorkTimeModelManager
    {
        public List<EmployeeWorkTimeModel> GetEmployeesAndWorkTimes()
        {
            WorkTimeManager WorkTimeManager = new WorkTimeManager();

            List<EmployeeDto> workTimes = WorkTimeManager.GetEmployeesAndWorkTimes();
            return MapperConfigStorage.GetInstance().Map<List<EmployeeWorkTimeModel>>(workTimes);
        }
    }
}
