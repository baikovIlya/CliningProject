namespace CliningContoraFromValera.DAL.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<ServiceDto>? Services { get; set; }
        public List<WorkAreaDto>? WorkAreas { get; set; }
        public List<OrderDto>? Orders { get; set; }
        public WorkTimeDto? WorkTime { get; set; }

        public override string ToString()
        {
            return $"Id={Id} FirstName={FirstName} LastName={LastName} Phone={Phone}";
        }
    }
}
