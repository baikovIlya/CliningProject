using CliningContoraFromValera.Bll.Models;

namespace CliningContoraFromValera.Bll.ModelsManager.ModelManagerInterfaces
{
    public interface IWorkAreaModelManager
    {
        List<WorkAreaModel> GetAllWorkAreas();
        WorkAreaModel GetWorkAreaById(int workAreaId);
        void UpdateWorkAreaById(WorkAreaModel workAreaModel);
        void AddWorkArea(WorkAreaModel workAreaModel);
        void DeleteWorkAreaById(int workAreaId);
    }
}
