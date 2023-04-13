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
    public class ManufactoringLotMap : IEntityTypeConfiguration<ManufactoringLot>
    {
        public void Configure(EntityTypeBuilder<ManufactoringLot> builder, string schema)
        {

            builder.HasKey(e => e.Id).HasName("PK__Manufact__3214EC27FC6BB080");

            builder.ToTable("ManufactoringLot");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasOne(d => d.Product).WithMany(p => p.ManufactoringLots)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ManufactoringLot_Product");
        }
        public void Configure(EntityTypeBuilder<ManufactoringLot> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
