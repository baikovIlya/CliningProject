namespace CliningContoraFromValera.DAL.DTOs
{
    public class WorkAreaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public override string ToString()
        {
            return $"Id={Id} Name={Name}";
        }
    }
}
