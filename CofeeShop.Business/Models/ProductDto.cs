using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShop.Business.Models
{
    public class ProductDto
    {
        public int Productid { get; set; }
        public string Productname { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public int? Cateid { get; set; }
        public string? CategoryName { get; set; }
    }
}
