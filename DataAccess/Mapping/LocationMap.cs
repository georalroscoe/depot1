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
    public class LocationMap : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder, string schema)
        {

            builder.HasKey(e => e.LocationId).HasName("PK__Location__3214EC273FDC68D8");

            builder.Property(e => e.LocationId).HasColumnName("LocationId");

            builder.HasOne(d => d.LocationTypeNavigation).WithMany(p => p.Locations)
                .HasForeignKey(d => d.LocationTypeId)
                .HasConstraintName("FK_Location_LocationType");
        }
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
