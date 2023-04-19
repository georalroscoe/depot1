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
    public class WarehouseBatchMap : IEntityTypeConfiguration<WarehouseBatch>
    {
        public void Configure(EntityTypeBuilder<WarehouseBatch> builder, string schema)
        {

            builder.HasKey(e => e.WarehouseBatchId).HasName("PK__Warehous__3214EC2705494396");

            builder.ToTable("WarehouseBatch");

            builder.Property(e => e.WarehouseBatchId).HasColumnName("WarehouseBatchId");

            builder.HasOne(d => d.LocationNavigation).WithMany(p => p.WarehouseBatches)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_WarehouseBatch_Location");
        }
        public void Configure(EntityTypeBuilder<WarehouseBatch> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
