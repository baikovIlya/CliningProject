using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll
{
    public class MapperManager
    {
        public EmployeeModel MapEmployeeDTOToEmployeeModel (EmployeeDTO employeeDTO)
        {
            return new EmployeeModel()
            {
                Id = employeeDTO.Id,
                Name = $"{employeeDTO.LastName} {employeeDTO.LastName}"
            };
        }

        public AllEmployeesInfoModel MapEmployeeDTOToAllEmployeeInfoModel(EmployeeDTO employeeDTO)
        {
            List<string> workArea = new List<string>();
            for (int i = 0; i <= employeeDTO.WorkAreas!.Count - 1; i++)
            {
                workArea.Add(employeeDTO.WorkAreas[i].Name);
            }
            string tmp = String.Join(" ", workArea);
            return new AllEmployeesInfoModel()
            {
                Id = employeeDTO.Id,
                Phone = employeeDTO.Phone,
                WorkArea = tmp
            };
        }

        //public AllEmployeesServiceModel MapEmployeeDTOToAllEmployeeServiceModel(EmployeeDTO employeeDTO)
        //{
        //    return new AllEmployeesServiceModel()
        //    {
        //        Id = employeeDTO.Id,
        //        Service = employeeDTO.Services.ToString();
        //    }
    }
}
