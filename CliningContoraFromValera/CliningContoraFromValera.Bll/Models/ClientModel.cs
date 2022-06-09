namespace CliningContoraFromValera.Bll.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }

        public ClientModel()
        {

        }

        public ClientModel(int id, string firstName, string lastName, string email, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is ClientModel))
            {
                flag = false;
            }
            else
            {
                ClientModel clDto = (ClientModel)obj;
                if (clDto.Id != this.Id ||
                    clDto.FirstName != this.FirstName ||
                    clDto.LastName != this.LastName ||
                    clDto.Email != this.Email ||
                    clDto.Phone != this.Phone)
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
