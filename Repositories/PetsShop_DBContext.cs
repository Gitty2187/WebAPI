﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities;

public partial class PetsShop_DBContext : DbContext
{
    public PetsShop_DBContext(DbContextOptions<PetsShop_DBContext> options)
        : base(options)
    {
    }

    public PetsShop_DBContext()
    {
        
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Orders).HasConstraintName("FK_UserID");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasConstraintName("FK_OrderID");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems).HasConstraintName("FK_Product_ID");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK_CategoryID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}