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
    public class CustomerOrderMap : IEntityTypeConfiguration<CustomerOrder>
    {
        public void Configure(EntityTypeBuilder<CustomerOrder> builder, string schema)
        {

            builder.HasKey(e => e.OrderId).HasName("PK_CustomerOrder");

            builder.ToTable("CustomerOrder");

            builder.Property(e => e.OrderId).HasColumnName("OrderId");



        }
        public void Configure(EntityTypeBuilder<CustomerOrder> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
