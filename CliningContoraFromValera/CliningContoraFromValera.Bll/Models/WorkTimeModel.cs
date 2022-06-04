namespace CliningContoraFromValera.Bll.Models
{
    public class WorkTimeModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
    }
}
