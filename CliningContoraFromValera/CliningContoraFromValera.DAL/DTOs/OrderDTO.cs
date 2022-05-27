namespace CliningContoraFromValera.DAL
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EstimatedEndTime { get; set; }
        public DateTime? FinishTime { get; set; }
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
