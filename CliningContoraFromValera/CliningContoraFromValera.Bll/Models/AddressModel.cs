namespace CliningContoraFromValera.Bll.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Room { get; set; }
        public WorkAreaModel WorkArea { get; set; }

        public AddressModel()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is AddressModel))
            {
                flag = false;
            }
            else
            {
                AddressModel addressDto = (AddressModel)obj;
                if (addressDto.Id != this.Id ||
                    addressDto.Street != this.Street ||
                    addressDto.Building != this.Building ||
                    addressDto.Room != this.Room ||
                    addressDto.WorkArea.Id != this.WorkArea.Id)
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
