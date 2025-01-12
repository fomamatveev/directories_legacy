using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.Audit.Configurations;

public class AuditEntityTypeConfiguration : IEntityTypeConfiguration<Models.Audit>
{
    public void Configure(EntityTypeBuilder<Models.Audit> builder)
    {
        builder.ToTable("AuditLog");

        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.Action).HasColumnName("Action");
        builder.Property(x => x.EntityName).HasColumnName("EntityName");
        builder.Property(x => x.EntityId).HasColumnName("EntityId");
        builder.Property(x => x.Changes).HasColumnName("Changes");
        builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt");
        builder.Property(x => x.ChangedBy).HasColumnName("ChangedBy");
    }
}