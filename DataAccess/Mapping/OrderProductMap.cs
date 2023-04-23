using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Mapping
{
    public class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder, string schema)
        {

            builder.HasKey(e => e.OrderProductId);

            builder.ToTable("OrderProduct");

            builder.Property(e => e.OrderProductId).HasColumnName("OrderProductId");

            builder.HasOne(d => d.CustomerOrder).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderProduct_CustomerOrder");

            builder.HasOne(d => d.Product).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderProduct_Product");
        }
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
