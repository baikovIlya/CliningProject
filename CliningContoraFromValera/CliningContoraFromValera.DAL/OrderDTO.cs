using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliningContoraFromValera.DAL
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EstimatedEndTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal SummOfOrder { get; set; }
        public string Status { get; set; }
        public int CountOfEmployees { get; set; }
        public bool IsCommercial { get; set; }
        public int ClientId { get; set; }
        public int AddressId { get; set; }
    }
}
