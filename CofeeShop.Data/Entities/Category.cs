using System;
using System.Collections.Generic;

namespace CofeeShop.Data.Entities;

public partial class Category
{
    public int Cateid { get; set; }

    public string Catename { get; set; } = null!;

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Modifiedat { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual Employee? CreatedbyNavigation { get; set; }

    public virtual Employee? ModifiedbyNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
