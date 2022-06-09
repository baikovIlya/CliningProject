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
            return $"{Id} {Name}";
        }

        public override bool Equals(object? obj)
        {
            bool flag = true;

            if(obj == null || !(obj is WorkAreaModel))
            {
                flag = false;
            }
            else
            {
                WorkAreaModel waModel = (WorkAreaModel)obj;
                if (waModel.Id != this.Id || waModel.Name != this.Name)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
