using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShop.Business.Models
{
    public class UpdateProductRequest
    {
        public string Productname { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int? Cateid { get; set; }
        public int? Modifiedby { get; set; }
    }
}
