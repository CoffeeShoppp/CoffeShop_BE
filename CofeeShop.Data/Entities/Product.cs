using System;
using System.Collections.Generic;

namespace CofeeShop.Data.Entities;

public partial class Product
{
    public int Productid { get; set; }

    public string Productname { get; set; } = null!;

    public decimal Price { get; set; }

    public int? Cateid { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Modified { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual Category? Cate { get; set; }

    public virtual Employee? CreatedbyNavigation { get; set; }

    public virtual Employee? ModifiedbyNavigation { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();
}
