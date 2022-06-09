namespace CliningContoraFromValera.Bll.Models
{
    public class WorkAreaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public WorkAreaModel()
        {

        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            bool flag = false;

            if(obj == null || !(obj is WorkAreaModel))
            {
                flag = false;
            }
            else
            {
                WorkAreaModel waDto = (WorkAreaModel)obj;
                if (waDto.Id != this.Id || waDto.Name != this.Name)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
