using DL.Directories.Dtos;
using DL.Directories.Models.Product;

namespace DL.Directories.Interfaces.ProductInterface;

/// <summary>
/// Интерфейс сервиса для управления товарами
/// </summary>
public interface IProductService
{
    Task<List<ProductListDto>> ListAsync();

    Task<Product> GetAsync(int id);
    
    Task<Product> CreateAsync(ProductDto product);
    
    Task<Product> UpdateAsync(ProductDto product);
    
    Task<bool> DeleteAsync(int id);
}