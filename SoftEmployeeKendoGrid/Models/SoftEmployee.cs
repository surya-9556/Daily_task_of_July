using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftEmployeeKendoGrid.Models
{
    public class SoftEmployee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal EmpSalary { get; set; }
        public DateTime EmpDOB { get; set; }
        public string EmpAddress { get; set; }
        public string EmpStatus { get; set; }
    }
}
