using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.Dtos;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class WorkAreaModelManager
    {
        WorkAreaManager WorkAreaManager = new WorkAreaManager();

        public List<WorkAreaModel> GetAllWorkAreas()
        {
            List<WorkAreaDto> workAreas = WorkAreaManager.GetAllWorkAreas();
            return MapperConfigStorage.GetInstance().Map<List<WorkAreaModel>>(workAreas);
        }

        public WorkAreaModel GetWorkAreaById(int workAreaId)
        {
            WorkAreaDto workArea = WorkAreaManager.GetWorkAreaByID(workAreaId);
            return MapperConfigStorage.GetInstance().Map<WorkAreaModel>(workArea);
        }

        public void UpdateWorkAreaById(WorkAreaModel workAreaModel)
        {
            WorkAreaDto workArea = MapperConfigStorage.GetInstance().Map<WorkAreaDto>(workAreaModel);
            WorkAreaManager.UpdateWorkAreaById(workArea);
        }

        public void AddWorkArea(WorkAreaModel workAreaModel)
        {
            WorkAreaDto workArea = MapperConfigStorage.GetInstance().Map<WorkAreaDto>(workAreaModel);
            WorkAreaManager.AddWorkArea(workArea);
        }

        public void DeleteWorkAreaById(int workAreaId)
        {
            WorkAreaManager.DeleteWorkAreaById(workAreaId);
        }
    }
}
