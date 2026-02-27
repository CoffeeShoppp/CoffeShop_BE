using System;
using System.Collections.Generic;
using CofeeShop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CofeeShop.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Cateid).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Cateid).HasColumnName("cateid");
            entity.Property(e => e.Catename)
                .HasMaxLength(100)
                .HasColumnName("catename");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedat");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.CategoryCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("categories_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.CategoryModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("categories_modifiedby_fkey");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("customers_pkey");

            entity.ToTable("customers");

            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Customername)
                .HasMaxLength(100)
                .HasColumnName("customername");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedat");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Point)
                .HasDefaultValue(0)
                .HasColumnName("point");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.CustomerCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("customers_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.CustomerModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("customers_modifiedby_fkey");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Discountid).HasName("discounts_pkey");

            entity.ToTable("discounts");

            entity.Property(e => e.Discountid).HasColumnName("discountid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Discountname)
                .HasMaxLength(100)
                .HasColumnName("discountname");
            entity.Property(e => e.Discountpercent)
                .HasPrecision(5, 2)
                .HasColumnName("discountpercent");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedat");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Startdate).HasColumnName("startdate");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.DiscountCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("discounts_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.DiscountModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("discounts_modifiedby_fkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Employeeid).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Employeename)
                .HasMaxLength(100)
                .HasColumnName("employeename");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedat");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Deliveryaddress).HasColumnName("deliveryaddress");
            entity.Property(e => e.Discountid).HasColumnName("discountid");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedat");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Ordertime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ordertime");
            entity.Property(e => e.Ordertype)
                .HasMaxLength(50)
                .HasColumnName("ordertype");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Tableid).HasColumnName("tableid");
            entity.Property(e => e.Totalamount)
                .HasPrecision(12, 2)
                .HasColumnName("totalamount");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.OrderCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("orders_createdby_fkey");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("orders_customerid_fkey");

            entity.HasOne(d => d.Discount).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Discountid)
                .HasConstraintName("orders_discountid_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.OrderEmployees)
                .HasForeignKey(d => d.Employeeid)
                .HasConstraintName("orders_employeeid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.OrderModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("orders_modifiedby_fkey");

            entity.HasOne(d => d.Table).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Tableid)
                .HasConstraintName("orders_tableid_fkey");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.Orderdetailid).HasName("orderdetails_pkey");

            entity.ToTable("orderdetails");

            entity.Property(e => e.Orderdetailid).HasColumnName("orderdetailid");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Subtotal)
                .HasPrecision(12, 2)
                .HasColumnName("subtotal");
            entity.Property(e => e.Unitprice)
                .HasPrecision(10, 2)
                .HasColumnName("unitprice");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("orderdetails_orderid_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("orderdetails_productid_fkey");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("payments_pkey");

            entity.ToTable("payments");

            entity.Property(e => e.Paymentid).HasColumnName("paymentid");
            entity.Property(e => e.Amount)
                .HasPrecision(12, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Paymentmethod)
                .HasMaxLength(50)
                .HasColumnName("paymentmethod");
            entity.Property(e => e.Paymenttime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("paymenttime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("payments_orderid_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Cateid).HasColumnName("cateid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Modified)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modified");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Productname)
                .HasMaxLength(100)
                .HasColumnName("productname");

            entity.HasOne(d => d.Cate).WithMany(p => p.Products)
                .HasForeignKey(d => d.Cateid)
                .HasConstraintName("products_cateid_fkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.ProductCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("products_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.ProductModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("products_modifiedby_fkey");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Tableid).HasName("tables_pkey");

            entity.ToTable("tables");

            entity.Property(e => e.Tableid).HasColumnName("tableid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Modifiedat)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifiedat");
            entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.TableCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("tables_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.TableModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("tables_modifiedby_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
