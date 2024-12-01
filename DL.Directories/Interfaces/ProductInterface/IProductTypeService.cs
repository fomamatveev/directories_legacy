using DL.Directories.Models.Product;

namespace DL.Directories.Interfaces.ProductInterface;

public interface IProductTypeService
{
    Task<List<ProductType>> ListAsync();

    Task<ProductType> GetAsync(int id);
    
    Task<ProductType> CreateAsync(ProductType productType);
    
    Task<ProductType> UpdateAsync(ProductType productType);
    
    Task<bool> DeleteAsync(int id);
}