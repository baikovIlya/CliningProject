namespace CliningContoraFromValera.DAL
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<ServiceDTO> Services { get; set; } = new List<ServiceDTO>();
        public List<WorkAreaDTO> WorkAreas { get; set; } = new List<WorkAreaDTO>();

        public override string ToString()
        {
            return $"Id={Id} FirstName={FirstName} LastName={LastName} Phone={Phone}";
        }
    }
}
