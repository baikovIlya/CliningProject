namespace CliningContoraFromValera.DAL.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }

        public ClientDTO()
        {

        }
        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is ClientDTO))
            {
                flag = false;
            }
            ClientDTO clDto = (ClientDTO)obj;
            if (clDto.Id != this.Id ||
                clDto.FirstName != this.FirstName ||
                clDto.LastName != this.LastName ||
                clDto.Email != this.Email ||
                clDto.Phone != this.Phone)
            {
                flag = false;
            }
            return flag;
        }
    }
}
