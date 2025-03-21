using DL.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.Core.Configurations;

public class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T>
    where T : Entity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        ConfigureEntity(builder);
    }

    protected virtual void ConfigureEntity(EntityTypeBuilder<T> builder)
    {
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.Name).HasColumnName("Name");
        builder.Property(x => x.ShortName).HasColumnName("ShortName");
        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt");
        builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy");
        builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy");
    }
}