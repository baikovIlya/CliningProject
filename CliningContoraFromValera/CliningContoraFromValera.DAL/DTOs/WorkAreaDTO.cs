namespace CliningContoraFromValera.DAL.DTOs
{
    public class WorkAreaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public WorkAreaDTO()
        {

        }
        public override string ToString()
        {
            return $"{Id} {Name}";
        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if (obj == null || !(obj is WorkAreaDTO))
            {
                flag = false;
            }
            else
            {
                WorkAreaDTO waDto = (WorkAreaDTO)obj;
                if (waDto.Id != this.Id || waDto.Name != this.Name)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
