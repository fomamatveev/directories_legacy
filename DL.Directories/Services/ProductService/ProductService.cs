using DL.Core.Interfaces;
using DL.Core.Models.Product;
using DL.Directories.Dtos;
using DL.Directories.Interfaces;
using DL.Directories.Interfaces.ProductInterface;
using Microsoft.EntityFrameworkCore;

namespace DL.Directories.Services.ProductService;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;

    public ProductService(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductListDto>> ListAsync()
    {
        var products = await _repository.GetAll()
            .Select(x => new ProductListDto
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                Quantity = x.Quantity,
                ProductName = x.ProductName.Name,
                ProductTypeName = x.ProductType.Name,
                StorageLocationPosition = $"{x.StorageLocation.Rack}/{x.StorageLocation.Compartment}/{x.StorageLocation.Part}"
            })
            .ToListAsync();
        
        return products;
    }

    public async Task<Product> GetAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} not found.");
        }
        
        return product;
    }

    public async Task<Product> CreateAsync(ProductDto product)
    {
        ArgumentNullException.ThrowIfNull(product);

        var existsProduct = await _repository.GetAll()
            .Where(x => x.ProductNameId == product.ProductNameId
                        && x.ProductTypeId == product.ProductTypeId
                        && x.StorageLocationId == product.StorageLocationId)
            .FirstOrDefaultAsync();

        if (existsProduct is null)
        {
            var result = new Product
            {
                Name = product.Name,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = product.CreatedBy,
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = product.CreatedBy,
                Quantity = product.Quantity,
                ProductNameId = product.ProductNameId,
                ProductTypeId = product.ProductTypeId,
                StorageLocationId = product.StorageLocationId
            };
        
            await _repository.AddAsync(result);
            
            return result;
        }
        
        existsProduct.CreatedAt = DateTime.SpecifyKind(existsProduct.CreatedAt, DateTimeKind.Utc);
        existsProduct.UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
        existsProduct.UpdatedBy = product.CreatedBy;
        existsProduct.Quantity += product.Quantity;
        
        await _repository.UpdateAsync(existsProduct);

        return existsProduct;
    }

    public async Task<Product> UpdateAsync(ProductDto product)
    {
        ArgumentNullException.ThrowIfNull(product);

        var result = await _repository.GetByIdAsync(product.Id);

        result.Name = product.Name;
        result.CreatedAt = DateTime.SpecifyKind(product.CreatedAt, DateTimeKind.Utc);
        result.UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
        result.UpdatedBy = product.UpdatedBy;
        result.Quantity = product.Quantity;
        result.ProductTypeId = product.ProductTypeId;
        result.StorageLocationId = product.StorageLocationId;
        
        await _repository.UpdateAsync(result);
        
        return result;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);

        await _repository.DeleteAsync(product);

        return true;
    }
}