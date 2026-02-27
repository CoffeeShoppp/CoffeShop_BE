using System;
using System.Collections.Generic;

namespace CofeeShop.Data.Entities;

public partial class Payment
{
    public int Paymentid { get; set; }

    public int? Orderid { get; set; }

    public decimal? Amount { get; set; }

    public string? Paymentmethod { get; set; }

    public DateTime? Paymenttime { get; set; }

    public string? Status { get; set; }

    public virtual Order? Order { get; set; }
}
