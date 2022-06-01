namespace CliningContoraFromValera.DAL.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string? Room { get; set; }
        public int WorkAreaId { get; set; }
        public WorkAreaDTO? WorkArea { get; set; }

    }
}
