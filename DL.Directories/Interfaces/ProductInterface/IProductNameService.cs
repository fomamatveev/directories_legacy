using DL.Core.Models.Product;
using DL.Directories.Dtos;

namespace DL.Directories.Interfaces.ProductInterface;

/// <summary>
/// Интерфейс сервиса для управления наименованиями товаров
/// </summary>
public interface IProductNameService
{
    Task<List<ProductName>> ListAsync();

    Task<ProductName> GetAsync(int id);
    
    Task<ProductName> CreateAsync(ProductName product);
    
    Task<ProductName> UpdateAsync(ProductName product);
    
    Task<bool> DeleteAsync(int id);
    
    Task<string> GetForAuditAsync(int id);
}