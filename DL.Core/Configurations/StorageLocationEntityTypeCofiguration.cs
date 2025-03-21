using DL.Core.Models.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.Core.Configurations;

public class StorageLocationEntityTypeCofiguration : BaseEntityTypeConfiguration<StorageLocation>
{
    protected override void ConfigureEntity(EntityTypeBuilder<StorageLocation> builder)
    {
        base.ConfigureEntity(builder);

        builder.ToTable("StorageLocation");
        
        builder.Property(x => x.Rack).HasColumnName("Rack");
        builder.Property(x => x.Compartment).HasColumnName("Compartment");
        builder.Property(x => x.Part).HasColumnName("Part");
    }
}