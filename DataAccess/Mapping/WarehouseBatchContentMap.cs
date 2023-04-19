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
    public class WarehouseBatchContentMap : IEntityTypeConfiguration<WarehouseBatchContent>
    {
        public void Configure(EntityTypeBuilder<WarehouseBatchContent> builder, string schema)
        {

            builder.HasKey(e => e.WarehouseBatchContentId).HasName("PK__Warehous__3214EC27E58ACB78");

            builder.ToTable("WarehouseBatchContent");

            builder.Property(e => e.WarehouseBatchContentId).HasColumnName("WarehouseBatchContentId");

            builder.HasOne(d => d.ManufactoringLotNavigation).WithMany(p => p.WarehouseBatchContents)
                .HasForeignKey(d => d.ManufactoringLotId)
                .HasConstraintName("FK_WarehouseBatchContent_ManufactoringLot");

            builder.HasOne(d => d.WarehouseBatchNavigation).WithMany(p => p.WarehouseBatchContents)
                .HasForeignKey(d => d.WarehouseBatchId)
                .HasConstraintName("FK_WarehouseBatchContent_WarehouseBatch");
        }
        public void Configure(EntityTypeBuilder<WarehouseBatchContent> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
