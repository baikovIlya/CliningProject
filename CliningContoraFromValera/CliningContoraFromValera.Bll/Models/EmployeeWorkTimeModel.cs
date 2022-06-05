namespace CliningContoraFromValera.Bll.Models
{
    public class EmployeeWorkTimeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public int WorkTimeId { get; set; }
        public int EmployeeId { get; set; }


    }
}
