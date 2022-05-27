namespace CliningContoraFromValera.DAL
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"Id={Id} FirstName={FirstName} LastName={LastName} Phone={Phone}";
        }
    }
}
