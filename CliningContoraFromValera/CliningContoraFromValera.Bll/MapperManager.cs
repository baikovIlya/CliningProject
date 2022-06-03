using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Dtos;

namespace CliningContoraFromValera.Bll
{
    public class MapperManager
    {
        //public EmployeeModel MapEmployeeDtoToEmployeeModel (EmployeeDto employeeDto)
        //{
        //    return new EmployeeModel()
        //    {
        //        //Id = employeeDto.Id,
        //        FirstName = employeeDto.FirstName,
        //        LastName = employeeDto.LastName,
        //        Phone = employeeDto.Phone
        //    };
        //}

        public AllEmployeesInfoModel MapEmployeeDtoToAllEmployeeInfoModel(EmployeeDto employeeDto)
        {
            List<string> workArea = new List<string>();
            for (int i = 0; i <= employeeDto.WorkAreas!.Count - 1; i++)
            {
                workArea.Add(employeeDto.WorkAreas[i].Name);
            }
            string tmp = String.Join(" ", workArea);
            return new AllEmployeesInfoModel()
            {
                Id = employeeDto.Id,
                Phone = employeeDto.Phone,
                WorkArea = tmp
            };
        }

        //public AllEmployeesServiceModel MapEmployeeDtoToAllEmployeeServiceModel(EmployeeDto employeeDto)
        //{
        //    return new AllEmployeesServiceModel()
        //    {
        //        Id = employeeDto.Id,
        //        Service = employeeDto.Services.ToString();
        //    }
    }
}
