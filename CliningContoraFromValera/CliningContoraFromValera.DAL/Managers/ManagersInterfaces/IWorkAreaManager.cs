using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.DAL.Managers.ManagersInterfaces
{
    public interface IWorkAreaManager
    {
        List<WorkAreaDTO> GetAllWorkAreas();
        WorkAreaDTO GetWorkAreaByID(int workAreaId);
        void AddWorkArea(WorkAreaDTO newWorkArea);
        void UpdateWorkAreaById(WorkAreaDTO workArea);
        void DeleteWorkAreaById(int workAreaId);
    }
}
