using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliningContoraFromValera.DAL.DTOs
{
    public class ServiceOrderDTO
    {
        public int OrderID { get; set; }
        public string ServiceName { get; set; }
        public int Count { get; set; }
    }
}
