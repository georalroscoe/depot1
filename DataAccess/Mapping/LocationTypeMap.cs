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
    public class LocationTypeMap : IEntityTypeConfiguration<LocationType>
    {
        public void Configure(EntityTypeBuilder<LocationType> builder, string schema)
        {

            builder.HasKey(e => e.Id).HasName("PK__Location__3214EC272779AC50");

            builder.ToTable("LocationType");

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
        public void Configure(EntityTypeBuilder<LocationType> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
