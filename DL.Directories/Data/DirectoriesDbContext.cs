using DL.Directories.Models;
using DL.Directories.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace DL.Directories.Data;

public class DirectoriesDbContext : DbContext
{
    public DirectoriesDbContext(DbContextOptions<DirectoriesDbContext> options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<ProductType> ProductTypes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DirectoriesDbContext).Assembly);
    }
}