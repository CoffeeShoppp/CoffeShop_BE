using System;
using System.Collections.Generic;

namespace CofeeShop.Data.Entities;

public partial class Discount
{
    public int Discountid { get; set; }

    public string? Discountname { get; set; }

    public decimal? Discountpercent { get; set; }

    public DateOnly? Startdate { get; set; }

    public DateOnly? Enddate { get; set; }

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Modifiedat { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual Employee? CreatedbyNavigation { get; set; }

    public virtual Employee? ModifiedbyNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
