using DL.Core.Models;
using DL.Core.Models.Audit;
using DL.Core.Models.Auth;
using DL.Core.Models.Product;
using DL.Core.Models.Storage;
using Microsoft.EntityFrameworkCore;

namespace DL.Core.Data;

public class DirectoriesDbContext : DbContext
{
    public DirectoriesDbContext(DbContextOptions<DirectoriesDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<AuditAction> AuditActions { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<ProductName> ProductNames { get; set; }
    
    public DbSet<ProductType> ProductTypes { get; set; }
    
    public DbSet<StorageLocation> StorageLocations { get; set; }
    
    public DbSet<AuditAction> Actions { get; set; }
    
    public DbSet<EntityType> EntityTypes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DirectoriesDbContext).Assembly);
    }
}