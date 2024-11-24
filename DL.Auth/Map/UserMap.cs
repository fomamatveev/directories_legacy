using DL.Auth.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.Auth.Map;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.Property(u => u.Id).HasColumnName("id");
        builder.Property(u => u.Username).HasColumnName("username");
        builder.Property(u => u.PasswordHash).HasColumnName("password_hash");
        builder.Property(u => u.PasswordSalt).HasColumnName("password_salt");
        builder.Property(u => u.CreatedAt).HasColumnName("created_at");
    }
}