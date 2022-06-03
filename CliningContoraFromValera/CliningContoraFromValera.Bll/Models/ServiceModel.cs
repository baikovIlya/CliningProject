using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public ServiceType ServiceType { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal CommercialPrice { get; set; }
        public string Unit { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public ServiceOrderDTO ServiceOrder { get; set; }
    }
}
