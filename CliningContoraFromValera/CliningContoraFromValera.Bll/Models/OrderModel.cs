namespace CliningContoraFromValera.Bll.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EstimatedEndTime { get; set; }
        public TimeSpan? FinishTime { get; set; }
        public decimal Price { get; set; }
        public StatusType Status { get; set; }
        public int CountOfEmployees { get; set; }
        public bool IsCommercial { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string? Room { get; set; }
        public int ClientId { get; set; }
        public int AddressId{ get; set; }
        public int WorkAreaId { get; set; }


        public AddressModel Address { get; set; }

        public OrderModel()
        {

        }

        public OrderModel(DateTime date, TimeSpan startTime, TimeSpan estimatedEndTime, TimeSpan finishTime, decimal price, StatusType status, bool isCommercial, int clientId, int addressId, int workAreaId)
        {
            Date = date;
            StartTime = startTime;
            EstimatedEndTime = estimatedEndTime;
            FinishTime = finishTime;
            Price = price;
            Status = status;
            IsCommercial = isCommercial;
            ClientId = clientId;
            AddressId = addressId;
            WorkAreaId = workAreaId;
        }
    }
}
