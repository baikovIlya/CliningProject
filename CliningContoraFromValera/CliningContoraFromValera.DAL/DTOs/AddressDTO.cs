namespace CliningContoraFromValera.DAL.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string? Room { get; set; }
        public int WorkAreaId { get; set; }
        public WorkAreaDto? WorkArea { get; set; }

    }
}
