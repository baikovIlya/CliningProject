namespace CliningContoraFromValera.Bll.Models
{
    public class WorkTimeModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public int EmployeeId { get; set; }

        public WorkTimeModel()
        {

        } 

        public WorkTimeModel(DateTime date, TimeSpan startTime, TimeSpan finishTime, int employeeId)
        {
            Date = date;
            StartTime = startTime;
            FinishTime = finishTime;
            EmployeeId = employeeId;
        }
    }
}
