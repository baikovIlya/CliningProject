namespace CliningContoraFromValera.Bll.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public EmployeeModel()
        {

        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}
