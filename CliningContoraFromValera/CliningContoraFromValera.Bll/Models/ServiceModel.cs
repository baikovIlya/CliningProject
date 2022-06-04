using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public ServiceType ServiceType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal CommercialPrice { get; set; }
        public string Unit { get; set; }
        public TimeSpan EstimatedTime { get; set; }

        public ServiceModel(ServiceType serviceType, string name, string description, decimal price, decimal commercialPrice ,
            string unit, TimeSpan estimatedTime)
        {
            ServiceType = serviceType;
            Name = name;
            Description = description;
            Price = price;
            CommercialPrice = commercialPrice;
            Unit = unit;
            EstimatedTime = estimatedTime;
        }
    }
}
