

namespace CliningContoraFromValera.DAL.DTOs
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price{ get; set; }
        public decimal CommercialPrice { get; set; }
        public string? Unit { get; set; }
        public int ServiceTypeId { get; set; }
        public string EstimatedTime { get; set; }

        public override string ToString()
        {
            return $"Id={Id} Name={Name} Description={Description} Price={Price} CommercialPrice={CommercialPrice}," +
                $" Unit = {Unit}, ServiceTypeId = {ServiceTypeId}, EstimatedTime = {EstimatedTime}  ";
        }


    }
}
