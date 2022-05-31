namespace CliningContoraFromValera.DAL
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public string ServiceType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price{ get; set; }
        public decimal CommercialPrice { get; set; }
        public string? Unit { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public ServiceOrderDTO? ServiceOrder { get; set; }


    public override string ToString()
        {
            return $"Id={Id} ServiceType={ServiceType} Name={Name} Description={Description} Price={Price} CommercialPrice={CommercialPrice}," +
                $" Unit = {Unit}, EstimatedTime = {EstimatedTime}  ";
        }


    }
}
