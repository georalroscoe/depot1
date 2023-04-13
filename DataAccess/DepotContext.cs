using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using DataAccess.Mapping;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace depot.Models;

public class DepotContext : DbContext
{
    public DepotContext()
    {
    }

    public DepotContext(DbContextOptions<DepotContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<LocationType> LocationTypes { get; set; }

    public virtual DbSet<ManufactoringLot> ManufactoringLots { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<WarehouseBatch> WarehouseBatches { get; set; }

    public virtual DbSet<WarehouseBatchContent> WarehouseBatchContents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-1VFGI46F\\SQLExpress;Database=depot;Encrypt=false; Trusted_Connection=true");

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new LocationTypeMap());
        modelBuilder.ApplyConfiguration(new LocationMap());
        modelBuilder.ApplyConfiguration(new WarehouseBatchMap());
        modelBuilder.ApplyConfiguration(new WarehouseBatchContentMap());
        modelBuilder.ApplyConfiguration(new ProductMap());
        modelBuilder.ApplyConfiguration(new ManufactoringLotMap());


    }
}

   
    /* protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC273FDC68D8");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.LocationTypeNavigation).WithMany(p => p.Locations)
                .HasForeignKey(d => d.LocationType)
                .HasConstraintName("FK_Locations_LocationType");
        });

        modelBuilder.Entity<LocationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC272779AC50");

            entity.ToTable("LocationType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ManufactoringLot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Manufact__3214EC27FC6BB080");

            entity.ToTable("ManufactoringLot");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Product).WithMany(p => p.ManufactoringLots)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ManufactoringLot_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC277904DC3A");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WarehouseBatch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warehous__3214EC2705494396");

            entity.ToTable("WarehouseBatch");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.WarehouseBatches)
                .HasForeignKey(d => d.Location)
                .HasConstraintName("FK_WarehouseBatch_Locations");
        });

        modelBuilder.Entity<WarehouseBatchContent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warehous__3214EC27E58ACB78");

            entity.ToTable("WarehouseBatchContent");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.ManufactoringLotNavigation).WithMany(p => p.WarehouseBatchContents)
                .HasForeignKey(d => d.ManufactoringLot)
                .HasConstraintName("FK_WarehouseBatchContent_ManufactoringLot");

            entity.HasOne(d => d.WarehouseBatchNavigation).WithMany(p => p.WarehouseBatchContents)
                .HasForeignKey(d => d.WarehouseBatch)
                .HasConstraintName("FK_WarehouseBatchContent_WarehouseBatch");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}*/
