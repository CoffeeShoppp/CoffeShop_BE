using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShop.Business.Models
{
    public class UpdateEmployeeRequest
    {
        [Required]
        [MaxLength(100)]
        public string Employeename { get; set; }

        public int? Modifiedby { get; set; }
    }
}
