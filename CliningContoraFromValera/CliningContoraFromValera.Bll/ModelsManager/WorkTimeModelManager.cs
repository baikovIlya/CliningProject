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
    }
}
