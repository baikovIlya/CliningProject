namespace CliningContoraFromValera.DAL
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EstimatedEndTime { get; set; }
        public TimeOnly? FinishTime { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public int CountOfEmployees { get; set; }
        public bool IsCommercial { get; set; }
        public int ClientId { get; set; }
        public int AddressId { get; set; }

        public override string ToString()
        {
            return $"Id={Id} Date={Date} StartTime={StartTime} EstimatedEndTime={EstimatedEndTime} EndTime={FinishTime}" +
                $"SummOfOrder={Price} Status={Status} CountOfEmployees={CountOfEmployees} IsCommercial={IsCommercial}" +
                $"CliendId={ClientId} AddressId={AddressId}";
        }
    }
}
