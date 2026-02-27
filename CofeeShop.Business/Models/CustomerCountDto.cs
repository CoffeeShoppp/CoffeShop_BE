using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShop.Business.Models
{
    public class CustomerCountDto
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int TotalCustomers { get; set; }
    }
}
