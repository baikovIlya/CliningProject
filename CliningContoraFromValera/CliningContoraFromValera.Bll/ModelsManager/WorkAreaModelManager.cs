﻿using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class WorkAreaModelManager
    {
        WorkAreaManager workAreaManager = new WorkAreaManager();
        EmployeeManager employeeManager = new EmployeeManager();

        public List<WorkAreaModel> GetAllWorkAreas()
        {
            List<WorkAreaDTO> workAreas = workAreaManager.GetAllWorkAreas();
            return MapperConfigStorage.GetInstance().Map<List<WorkAreaModel>>(workAreas);
        }

        public WorkAreaModel GetWorkAreaById(int workAreaId)
        {
            WorkAreaDTO workArea = workAreaManager.GetWorkAreaByID(workAreaId);
            return MapperConfigStorage.GetInstance().Map<WorkAreaModel>(workArea);
        }

        public void UpdateWorkAreaById(WorkAreaModel workAreaModel)
        {
            WorkAreaDTO workArea = MapperConfigStorage.GetInstance().Map<WorkAreaDTO>(workAreaModel);
            workAreaManager.UpdateWorkAreaById(workArea);
        }

        public void AddWorkArea(WorkAreaModel workAreaModel)
        {
            WorkAreaDTO workArea = MapperConfigStorage.GetInstance().Map<WorkAreaDTO>(workAreaModel);
            workAreaManager.AddWorkArea(workArea);
        }

        public void DeleteWorkAreaById(int workAreaId)
        {
            workAreaManager.DeleteWorkAreaById(workAreaId);
        }

        public void DeleteEmployeesWorkArea(int employeeId, int workAreaId)
        {
            employeeManager.DeleteEmployeesWorkArea(employeeId, workAreaId);
        }
        
    }
}
