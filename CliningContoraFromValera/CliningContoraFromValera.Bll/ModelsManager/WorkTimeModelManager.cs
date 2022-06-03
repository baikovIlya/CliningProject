using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.Dtos;
    
namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class WorkTimeModelManager
    {
        WorkTimeManager WorkTimeManager = new WorkTimeManager();

        public List<WorkTimeModel> GetAllWorkTimes()
        {
            List<WorkTimeDto> workTimes = WorkTimeManager.GetAllWorkTimes();
            return MapperConfigStorage.GetInstance().Map<List<WorkTimeModel>>(workTimes);
        }

        public WorkTimeModel GetWorkTimeById(int workTimeId)
        {
            WorkTimeDto workTime = WorkTimeManager.GetWorkTimeById(workTimeId);
            return MapperConfigStorage.GetInstance().Map<WorkTimeModel>(workTime);
        }

        public void UpdateWorkTimeById(WorkTimeModel workTimeModel)
        {
            WorkTimeDto workTime = MapperConfigStorage.GetInstance().Map<WorkTimeDto>(workTimeModel);
            WorkTimeManager.UpdateWorkTimeById(workTime);
        }

        public void AddWorkTime(WorkTimeModel workTimeModel)
        {
            WorkTimeDto workTime = MapperConfigStorage.GetInstance().Map<WorkTimeDto>(workTimeModel);
            WorkTimeManager.AddWorkTime(workTime);
        }

        public void DeleteWorkTimeById(int workTimeId)
        {
            WorkTimeManager.DeleteWorkTimeById(workTimeId);
        }

    }
}
