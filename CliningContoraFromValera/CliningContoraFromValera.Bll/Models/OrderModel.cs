using CliningContoraFromValera.DAL.Dtos;

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
        public StatusType Status { get; set; }
        public int CountOfEmployees { get; set; }
        public bool IsCommercial { get; set; }
        public ClientDto? Client { get; set; }
        public AddressDto? Address { get; set; }
        public List<ServiceDto>? Services { get; set; }
    }
}
