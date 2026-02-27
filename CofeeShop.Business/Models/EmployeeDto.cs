using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShop.Business.Models
{
    public class EmployeeDto
    {
        public int Employeeid { get; set; }
        public string Employeename { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Modifiedat { get; set; }
    }
}
