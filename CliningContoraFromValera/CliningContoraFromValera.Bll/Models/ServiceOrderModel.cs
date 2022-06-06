
namespace CliningContoraFromValera.Bll.Models
{
    public class ServiceOrderModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public int Count { get; set; }

        public ServiceOrderModel()
        {

        }
    }
}
