using DL.Core.Models.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.Core.Configurations;

public class ProductEntityTypeConfiguration : BaseEntityTypeConfiguration<Product>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Product> builder)
    {
        base.ConfigureEntity(builder);
        
        builder.ToTable("Product");
        
        builder.Property(x => x.Description).HasColumnName("Description");
        builder.Property(x => x.Quantity).HasColumnName("Quantity");
        builder.Property(x => x.ProductTypeId).HasColumnName("ProductTypeId");
        builder.Property(x => x.StorageLocationId).HasColumnName("StorageLocationId");

        builder
            .HasOne(x => x.ProductType)
            .WithMany();
        
        builder
            .HasOne(x => x.StorageLocation)
            .WithMany();
    }
}