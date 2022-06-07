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


        public OrderModel()
        {

        }

        public OrderModel(DateTime date, TimeSpan startTime, TimeSpan estimatedEndTime, decimal price, StatusType status, bool isCommercial, int clientId, int addressId, int workAreaId)
        {
            Date = date;
            StartTime = startTime;
            EstimatedEndTime = estimatedEndTime;
            Price = price;
            Status = status;
            IsCommercial = isCommercial;
            ClientId = clientId;
            Address!.Id = addressId;
            Address.WorkAreaId = workAreaId;
        }
    }
}
