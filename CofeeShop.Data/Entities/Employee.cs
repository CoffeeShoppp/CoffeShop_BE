using System;
using System.Collections.Generic;

namespace CofeeShop.Data.Entities;

public partial class Employee
{
    public int Employeeid { get; set; }

    public string Employeename { get; set; } = null!;

    public int? Createdby { get; set; }

    public int? Modifiedby { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Modifiedat { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual ICollection<Category> CategoryCreatedbyNavigations { get; set; } = new List<Category>();

    public virtual ICollection<Category> CategoryModifiedbyNavigations { get; set; } = new List<Category>();

    public virtual ICollection<Customer> CustomerCreatedbyNavigations { get; set; } = new List<Customer>();

    public virtual ICollection<Customer> CustomerModifiedbyNavigations { get; set; } = new List<Customer>();

    public virtual ICollection<Discount> DiscountCreatedbyNavigations { get; set; } = new List<Discount>();

    public virtual ICollection<Discount> DiscountModifiedbyNavigations { get; set; } = new List<Discount>();

    public virtual ICollection<Order> OrderCreatedbyNavigations { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderEmployees { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderModifiedbyNavigations { get; set; } = new List<Order>();

    public virtual ICollection<Product> ProductCreatedbyNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductModifiedbyNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Table> TableCreatedbyNavigations { get; set; } = new List<Table>();

    public virtual ICollection<Table> TableModifiedbyNavigations { get; set; } = new List<Table>();
}
