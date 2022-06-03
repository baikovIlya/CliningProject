using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public EmployeeModel(int id, string firstName, string lastName, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }
}
