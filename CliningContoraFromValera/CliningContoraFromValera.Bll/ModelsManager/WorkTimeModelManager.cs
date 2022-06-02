using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class WorkTimeModelManager
    {
        WorkTimeManager WorkTimeManager = new WorkTimeManager();

        public List<WorkTimeModel> GetAll()
        {
            List<WorkTimeDTO> workTimes = WorkTimeManager.GetAllWorkTimes();
            return MapperConfigStorage.GetInstance().Map<List<WorkTimeModel>>(workTimes);
        }

        public WorkTimeModel GetWorkTimeById(int workTimeId)
        {
            WorkTimeDTO workTime = WorkTimeManager.GetWorkTimeById(workTimeId);
            return MapperConfigStorage.GetInstance().Map<WorkTimeModel>(workTime);
        }

        public void UpdateWorkTimeById(WorkTimeModel workTimeModel)
        {
            WorkTimeDTO workTime = MapperConfigStorage.GetInstance().Map<WorkTimeDTO>(workTimeModel);
            WorkTimeManager.UpdateWorkTimeById(workTime);
        }

        public void AddWorkTime(WorkTimeModel workTimeModel)
        {
            WorkTimeDTO workTime = MapperConfigStorage.GetInstance().Map<WorkTimeDTO>(workTimeModel);
            WorkTimeManager.AddWorkTime(workTime);
        }

        public void DeleteWorkTime(int workTimeId)
        {
            WorkTimeDTO workTime = MapperConfigStorage.GetInstance().Map<WorkTimeDTO>(workTimeId);
            WorkTimeManager.DeleteWorkTimeById(workTime.Id);
        }
    }
}
