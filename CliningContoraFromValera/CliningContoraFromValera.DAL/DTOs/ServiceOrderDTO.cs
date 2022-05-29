using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliningContoraFromValera.DAL.DTOs
{
    public class ServiceOrderDTO
    {
        public int Id { get; set; }
        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
        public List<ServiceDTO> Services { get; set; } = new List<ServiceDTO> { };
        public int Count { get; set; }
    }
}
