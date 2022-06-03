using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string? Room { get; set; }
        public WorkAreaModel? WorkArea { get; set; }
    }
}
