using CliningContoraFromValera.DAL;

namespace CliningContoraFromValera.Bll.Models
{
    public class OrderModel
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
        public ClientDTO? Client { get; set; }
        public AddressDTO? Address { get; set; }
        public Dictionary<int, ServiceDTO>? Services { get; set; }
    }
}
