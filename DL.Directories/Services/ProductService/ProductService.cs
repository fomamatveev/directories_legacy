using DL.Directories.Interfaces;
using DL.Directories.Interfaces.ProductInterface;
using DL.Directories.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace DL.Directories.Services.ProductService;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;

    public ProductService(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> ListAsync()
    {
        return await _repository.GetAll().ToListAsync();
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

    public async Task<Product> CreateAsync(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        await _repository.AddAsync(product);

        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        var result = await _repository.GetByIdAsync(product.Id);

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