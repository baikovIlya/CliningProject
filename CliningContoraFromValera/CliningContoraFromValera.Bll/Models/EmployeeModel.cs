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

        public EmployeeModel(string firstName, string lastName, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}
