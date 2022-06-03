namespace CliningContoraFromValera.DAL.Dtos
{
    public class WorkAreaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public override string ToString()
        {
            return $"Id={Id} Name={Name}";
        }
    }
}
