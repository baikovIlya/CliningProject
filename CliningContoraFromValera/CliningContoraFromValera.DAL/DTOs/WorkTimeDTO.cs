namespace CliningContoraFromValera.DAL
{
    public class WorkTimeDTO
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly FinishTime { get; set; }
        public int EmployeeId { get; set; }

        public override string ToString()
        {
            return $"Id={Id} Date={Date} StartTime={StartTime} FinishTime={FinishTime} EmployeeId={EmployeeId}";
        }
    }
}
