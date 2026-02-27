using System;
using System.Collections.Generic;

namespace CofeeShop.Data.Entities;

public partial class Order
{
    public int Orderid { get; set; }

    public DateTime? Ordertime { get; set; }

    public string? Ordertype { get; set; }

    public decimal? Totalamount { get; set; }

    public string? Deliveryaddress { get; set; }

    public string? Status { get; set; }

    public int? Employeeid { get; set; }

    public int? Tableid { get; set; }

    public int? Customerid { get; set; }

    public int? Discountid { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Modifiedat { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual Employee? CreatedbyNavigation { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Discount? Discount { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Employee? ModifiedbyNavigation { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Table? Table { get; set; }
}
