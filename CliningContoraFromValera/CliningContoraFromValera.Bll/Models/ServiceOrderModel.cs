namespace CliningContoraFromValera.Bll.Models
{
    public class ServiceOrderModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public ServiceType ServiceType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal CommercialPrice { get; set; }
        public string Unit { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public int Count { get; set; }

        public ServiceOrderModel()
        {

        }
    }
}
