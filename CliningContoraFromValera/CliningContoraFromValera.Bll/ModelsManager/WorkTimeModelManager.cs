using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;
    
namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class WorkTimeModelManager
    {
        WorkTimeManager workTimeManager = new WorkTimeManager();

        public List<WorkTimeModel> GetAllWorkTimes()
        {
            List<WorkTimeDTO> workTimes = workTimeManager.GetAllWorkTimes();
            return MapperConfigStorage.GetInstance().Map<List<WorkTimeModel>>(workTimes);
        }

        public WorkTimeModel GetWorkTimeById(int workTimeId)
        {
            WorkTimeDTO workTime = workTimeManager.GetWorkTimeById(workTimeId);
            return MapperConfigStorage.GetInstance().Map<WorkTimeModel>(workTime);
        }

        public void UpdateWorkTimeById(WorkTimeModel workTimeModel)
        {
            WorkTimeDTO workTime = MapperConfigStorage.GetInstance().Map<WorkTimeDTO>(workTimeModel);
            workTimeManager.UpdateWorkTimeById(workTime);
        }

        public void AddWorkTime(WorkTimeModel workTimeModel)
        {
            WorkTimeDTO workTime = MapperConfigStorage.GetInstance().Map<WorkTimeDTO>(workTimeModel);
            workTimeManager.AddWorkTime(workTime);
        }

        public void DeleteWorkTimeById(int workTimeId)
        {
            workTimeManager.DeleteWorkTimeById(workTimeId);
        }

        public List<EmployeeWorkTimeModel>GetEmployeesAndWorkTimes()
        {
            List<EmployeeDTO> workTimes = workTimeManager.GetEmployeesAndWorkTimes();
            return MapperConfigStorage.GetInstance().Map<List<EmployeeWorkTimeModel>>(workTimes);
        }

    }
}
