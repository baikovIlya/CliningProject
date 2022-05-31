namespace CliningContoraFromValera.DAL
{
    public class WorkAreaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AddressDTO> Addresses { get; set; } = new List<AddressDTO>();
        
        public override string ToString()
        {
            return $"Id={Id} Name={Name}";
        }
    }
}
