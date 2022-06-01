using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.Models
{
    internal class AddressModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string? Room { get; set; }
        public WorkAreaDTO? WorkArea { get; set; }
    }
}
