namespace CliningContoraFromValera.DAL.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<ServiceDTO> Services { get; set; }
        public List<WorkAreaDTO> WorkAreas { get; set; }
        public List<OrderDTO> Orders { get; set; }
        public WorkTimeDTO WorkTime { get; set; }

        public EmployeeDTO()
        {

        }

    }
}
