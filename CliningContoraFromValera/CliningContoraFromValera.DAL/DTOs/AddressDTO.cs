namespace CliningContoraFromValera.DAL.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string? Room { get; set; }
        public WorkAreaDTO? WorkArea { get; set; }

        public AddressDTO()
        {

        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is AddressDTO))
            {
                flag = false;
            }
            AddressDTO addressDto = (AddressDTO)obj;
            if (    addressDto.Id != this.Id ||
                    addressDto.Street != this.Street ||
                    addressDto.Building != this.Building ||
                    addressDto.Room != this.Room ||
                    addressDto.WorkArea!.Id != this.WorkArea!.Id)
            {
                flag = false;
            }
            return flag;
        }

    }
}
