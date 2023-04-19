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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder, string schema)
        {

            builder.HasKey(e => e.ProductId).HasName("PK__Product__3214EC277904DC3A");

            builder.ToTable("Product");

            builder.Property(e => e.ProductId).HasColumnName("ProductId");
            builder.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Configure(builder, "dbo");
        }
    }
}
