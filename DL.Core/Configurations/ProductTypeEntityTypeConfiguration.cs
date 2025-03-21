using DL.Core.Models.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.Core.Configurations;

public class ProductTypeEntityTypeConfiguration : BaseEntityTypeConfiguration<ProductType>
{
    protected override void ConfigureEntity(EntityTypeBuilder<ProductType> builder)
    {
        base.ConfigureEntity(builder);

        builder.ToTable("ProductType");
    }
}