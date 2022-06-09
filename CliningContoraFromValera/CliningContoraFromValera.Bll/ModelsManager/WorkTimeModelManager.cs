using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;
    
namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class WorkTimeModelManager
    {
        WorkTimeManager _workTimeManager = new WorkTimeManager();

        public List<WorkTimeModel> GetAllWorkTimes()
        {
            List<WorkTimeDTO> workTimes = _workTimeManager.GetAllWorkTimes();
            return MapperConfigStorage.GetInstance().Map<List<WorkTimeModel>>(workTimes);
        }

        public WorkTimeModel GetWorkTimeById(int workTimeId)
        {
            WorkTimeDTO workTime = _workTimeManager.GetWorkTimeById(workTimeId);
            return MapperConfigStorage.GetInstance().Map<WorkTimeModel>(workTime);
        }

        public void UpdateWorkTimeById(WorkTimeModel workTimeModel)
        {
            WorkTimeDTO workTime = MapperConfigStorage.GetInstance().Map<WorkTimeDTO>(workTimeModel);
            _workTimeManager.UpdateWorkTimeById(workTime);
        }

        public void AddWorkTime(WorkTimeModel workTimeModel)
        {
            WorkTimeDTO workTime = MapperConfigStorage.GetInstance().Map<WorkTimeDTO>(workTimeModel);
            _workTimeManager.AddWorkTime(workTime);
        }

        public void DeleteWorkTimeById(int workTimeId)
        {
            _workTimeManager.DeleteWorkTimeById(workTimeId);
        }

        public List<EmployeeWorkTimeModel>GetEmployeesAndWorkTimes()
        {
            List<EmployeeDTO> workTimes = _workTimeManager.GetEmployeesAndWorkTimes();
            return MapperConfigStorage.GetInstance().Map<List<EmployeeWorkTimeModel>>(workTimes);
        }

    }
}
