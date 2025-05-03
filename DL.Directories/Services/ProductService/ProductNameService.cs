using DL.Core.Interfaces;
using DL.Core.Models.Product;
using DL.Directories.Interfaces.ProductInterface;
using Microsoft.EntityFrameworkCore;

namespace DL.Directories.Services.ProductService;

/// <summary>
/// Сервис взаимодействия с наименованием товара
/// </summary>
public class ProductNameService : IProductNameService
{
    private readonly IRepository<ProductName> _repository;

    public ProductNameService(IRepository<ProductName> repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductName>> ListAsync()
    {
        var products = await _repository.GetAll().ToListAsync();
        
        return products;
    }

    public async Task<ProductName> GetAsync(int id)
    {
        var productName = await _repository.GetByIdAsync(id);

        if (productName == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} not found.");
        }
        
        return productName;
    }

    public async Task<ProductName> CreateAsync(ProductName productName)
    {
        ArgumentNullException.ThrowIfNull(productName);
        
        productName.CreatedAt = DateTime.UtcNow;
        productName.UpdatedAt = DateTime.UtcNow;
        productName.UpdatedBy = productName.CreatedBy;
        
        await _repository.AddAsync(productName);

        return productName;
    }

    public async Task<ProductName> UpdateAsync(ProductName productName)
    {
        ArgumentNullException.ThrowIfNull(productName);

        var result = await _repository.GetByIdAsync(productName.Id);

        result.Name = productName.Name;
        result.ShortName = productName.ShortName;
        result.CreatedAt = DateTime.SpecifyKind(productName.CreatedAt, DateTimeKind.Utc);
        result.UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
        result.UpdatedBy = productName.UpdatedBy;
        
        await _repository.UpdateAsync(result);
        
        return result;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var productName = await _repository.GetByIdAsync(id);

        await _repository.DeleteAsync(productName);

        return true;
    }
    
    public async Task<string> GetForAuditAsync(int id)
    {
        var productName = await _repository.GetByIdAsync(id);

        if (productName == null)
        {
            throw new KeyNotFoundException($"ProductName with ID {id} not found.");
        }
        
        return productName.Name!;
    }
}