namespace CliningContoraFromValera.Bll.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string? Room { get; set; }
        public int WorkAreaId { get; set; }

        public AddressModel()
        {

        }

        public AddressModel(string street, string building, string room, int workAreaId)
        {
            Street = street;
            Building = building;
            Room = room;
            WorkAreaId = workAreaId;
        }

        public override bool Equals(object? obj)
        {
            bool flag = false;
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
                    addressDto.WorkAreaId != this.WorkAreaId)
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
