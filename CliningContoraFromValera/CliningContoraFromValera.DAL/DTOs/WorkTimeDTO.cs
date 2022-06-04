namespace CliningContoraFromValera.DAL.DTOs
{
    public class WorkTimeDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public int EmployeeId { get; set; }

    }
}
