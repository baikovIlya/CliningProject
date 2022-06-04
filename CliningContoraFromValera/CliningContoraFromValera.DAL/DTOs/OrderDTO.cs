namespace CliningContoraFromValera.DAL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EstimatedEndTime { get; set; }
        public TimeSpan? FinishTime { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public int CountOfEmployees { get; set; }
        public bool IsCommercial { get; set; }
        public int ClientId { get; set; }
        public int AddressId { get; set; }
        public ClientDTO? Client { get; set; }
        public AddressDTO? Address { get; set; }
        public List<ServiceDTO>? Services { get; set; }

    }
}
