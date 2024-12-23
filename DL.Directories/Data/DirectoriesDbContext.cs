using DL.Directories.Models.Product;
using DL.Directories.Models.Storage;
using Microsoft.EntityFrameworkCore;

namespace DL.Directories.Data;

public class DirectoriesDbContext : DbContext
{
    public DirectoriesDbContext(DbContextOptions<DirectoriesDbContext> options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<ProductType> ProductTypes { get; set; }
    
    public DbSet<StorageLocation> StorageLocations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DirectoriesDbContext).Assembly);
    }
}