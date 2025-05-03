using DL.Core.Models.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.Core.Configurations;

public class ProductNameEntityTypeConfiguration : BaseEntityTypeConfiguration<ProductName>
{
    protected override void ConfigureEntity(EntityTypeBuilder<ProductName> builder)
    {
        base.ConfigureEntity(builder);
        
        builder.ToTable("ProductName");
    }
}