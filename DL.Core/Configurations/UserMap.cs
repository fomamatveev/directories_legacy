using DL.Core.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.Core.Configurations;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.Property(u => u.Id).HasColumnName("Id");
        builder.Property(u => u.Username).HasColumnName("Username");
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordSalt");
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordHash");
        builder.Property(u => u.CreatedAt).HasColumnName("CreatedAt");
    }
}