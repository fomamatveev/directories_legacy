using DL.Directories.Interfaces;
using DL.Directories.Interfaces.StorageInterface;
using DL.Directories.Models.Storage;
using Microsoft.EntityFrameworkCore;

namespace DL.Directories.Services.Storage;

public class StorageLocationService : IStorageLocationService
{
    private readonly IRepository<StorageLocation> _repository;

    public StorageLocationService(IRepository<StorageLocation> storageLocationRepository)
    {
        _repository = storageLocationRepository;
    }
    
    public async Task<List<StorageLocation>> ListAsync()
    {
        return await _repository.GetAll().ToListAsync();
    }

    public async Task<StorageLocation> GetAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} not found.");
        }
        
        return product;
    }

    public async Task<StorageLocation> CreateAsync(StorageLocation product)
    {
        ArgumentNullException.ThrowIfNull(product);

        await _repository.AddAsync(product);

        return product;
    }

    public async Task<StorageLocation> UpdateAsync(StorageLocation product)
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