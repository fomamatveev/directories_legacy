using DL.Core.Interfaces;
using DL.Core.Models.Product;
using DL.Directories.Interfaces.ProductInterface;
using Microsoft.EntityFrameworkCore;

namespace DL.Directories.Services.ProductService;

public class ProductTypeService : IProductTypeService
{
    private readonly IRepository<ProductType> _repository;

    public ProductTypeService(IRepository<ProductType> repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductType>> ListAsync()
    {
        return await _repository.GetAll().ToListAsync();
    }

    public async Task<ProductType> GetAsync(int id)
    {
        var productType = await _repository.GetByIdAsync(id);

        if (productType == null)
        {
            throw new KeyNotFoundException($"ProductType with ID {id} not found.");
        }
        
        return productType;
    }

    public async Task<ProductType> CreateAsync(ProductType productType)
    {
        ArgumentNullException.ThrowIfNull(productType);

        productType.CreatedAt = DateTime.UtcNow;
        productType.UpdatedAt = DateTime.UtcNow;
        productType.UpdatedBy = productType.CreatedBy;
        
        await _repository.AddAsync(productType);

        return productType;
    }

    public async Task<ProductType> UpdateAsync(ProductType productType)
    {
        ArgumentNullException.ThrowIfNull(productType);

        var result = await _repository.GetByIdAsync(productType.Id);

        result.Name = productType.Name;
        result.ShortName = productType.ShortName;
        result.CreatedAt = DateTime.SpecifyKind(productType.CreatedAt, DateTimeKind.Utc);
        result.UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
        result.UpdatedBy = productType.UpdatedBy;
        
        await _repository.UpdateAsync(result);
        
        return result;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var productType = await _repository.GetByIdAsync(id);

        await _repository.DeleteAsync(productType);

        return true;
    }

    public async Task<string> GetForAuditAsync(int id)
    {
        var productType = await _repository.GetByIdAsync(id);

        if (productType == null)
        {
            throw new KeyNotFoundException($"ProductType with ID {id} not found.");
        }
        
        return productType.Name!;
    }
}