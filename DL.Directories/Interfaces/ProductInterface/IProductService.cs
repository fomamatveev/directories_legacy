using DL.Directories.Models;
using DL.Directories.Models.Product;

namespace DL.Directories.Interfaces.ProductInterface;

/// <summary>
/// Интерфейс сервиса для управления товарами
/// </summary>
public interface IProductService
{
    Task<List<Product>> ListAsync();

    Task<Product> GetAsync(int id);
    
    Task<Product> CreateAsync(Product product);
    
    Task<Product> UpdateAsync(Product product);
    
    Task<bool> DeleteAsync(int id);
}