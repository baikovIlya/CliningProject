namespace CliningContoraFromValera.Bll.Models
{
    public class WorkAreaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
