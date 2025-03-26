using DL.Core.Models.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.Core.Configurations;

public class EntityTypeTypeConfiguration : IEntityTypeConfiguration<EntityType>
{
    public void Configure(EntityTypeBuilder<EntityType> builder)
    {
        builder.ToTable("EntityType");

        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.EntityId).HasColumnName("EntityId");
        builder.Property(x => x.EntityName).HasColumnName("EntityName");
    }
}