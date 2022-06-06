namespace CliningContoraFromValera.DAL.DTOs
{
    public class ServiceOrderDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public int Count { get; set; }

        public ServiceOrderDTO()
        {

        }
    }
}
