using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeShop.Business.Models
{
    public class UpdateCategoryRequest
    {
        public string Catename { get; set; } = string.Empty;
        public int? Modifiedby { get; set; }
    }
}
