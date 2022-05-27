namespace CliningContoraFromValera.DAL
{
    public class WorkTimeDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int EmployeeId { get; set; }

        public override string ToString()
        {
            return $"Id={Id} Date={Date} StartTime={StartTime} FinishTime={FinishTime} EmployeeId={EmployeeId}";
        }
    }
}
