using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliningContoraFromValera.DAL
{
    public class WorkTimeDTO
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public int EmployeeId { get; set; }

        public override string ToString()
        {
            return $"Id={Id} Date={Date} StartTime={StartTime} FinishTime={FinishTime} EmployeeId={EmployeeId}";
        }
    }
}
