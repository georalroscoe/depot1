using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using DataAccess.Mapping;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DataAccess;

public class DepotContext : DbContext
{
    public DepotContext()
    {
    }

    public DepotContext(DbContextOptions<DepotContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Location> Location { get; set; }

    public virtual DbSet<LocationType> LocationTypes { get; set; }

    public virtual DbSet<ManufactoringLot> ManufactoringLots { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<WarehouseBatch> WarehouseBatches { get; set; }

    public virtual DbSet<WarehouseBatchContent> WarehouseBatchContents { get; set; }
    public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }


    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new LocationTypeMap());
        modelBuilder.ApplyConfiguration(new LocationMap());
        modelBuilder.ApplyConfiguration(new WarehouseBatchMap());
        modelBuilder.ApplyConfiguration(new WarehouseBatchContentMap());
        modelBuilder.ApplyConfiguration(new ProductMap());
        modelBuilder.ApplyConfiguration(new ManufactoringLotMap());
        modelBuilder.ApplyConfiguration(new CustomerOrderMap());
        modelBuilder.ApplyConfiguration(new OrderProductMap());


    }
}

  
