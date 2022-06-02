using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class WorkAreaModelManager
    {
        WorkAreaManager WorkAreaManager = new WorkAreaManager();

        public List<WorkAreaModel> GetAll()
        {
            List<WorkAreaDTO> workAreas = WorkAreaManager.GetAllWorkAreas();
            return MapperConfigStorage.GetInstance().Map<List<WorkAreaModel>>(workAreas);
        }

        public WorkAreaModel GetWorkAreaById(int workAreaId)
        {
            WorkAreaDTO workArea = WorkAreaManager.GetWorkAreaByID(workAreaId);
            return MapperConfigStorage.GetInstance().Map<WorkAreaModel>(workArea);
        }

        public void UpdateWorkAreaById(WorkAreaModel workAreaModel)
        {
            WorkAreaDTO workArea = MapperConfigStorage.GetInstance().Map<WorkAreaDTO>(workAreaModel);
            WorkAreaManager.UpdateWorkAreaById(workArea);
        }

        public void AddWorkArea(WorkAreaModel workAreaModel)
        {
            WorkAreaDTO workArea = MapperConfigStorage.GetInstance().Map<WorkAreaDTO>(workAreaModel);
            WorkAreaManager.AddWorkArea(workArea);
        }

        public void DeleteWorkAreaById(int workAreaId)
        {
            WorkAreaDTO workArea = MapperConfigStorage.GetInstance().Map<WorkAreaDTO>(workAreaId);
            WorkAreaManager.DeleteWorkAreaById(workArea.Id);
        }
    }
}
