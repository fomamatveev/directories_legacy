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
        var storageLocation = await _repository.GetByIdAsync(id);

        if (storageLocation == null)
        {
            throw new KeyNotFoundException($"StorageLocation with ID {id} not found.");
        }
        
        return storageLocation;
    }

    public async Task<StorageLocation> CreateAsync(StorageLocation storageLocation)
    {
        ArgumentNullException.ThrowIfNull(storageLocation);

        storageLocation.CreatedAt = DateTime.UtcNow.Date;
        storageLocation.UpdatedAt = DateTime.UtcNow;
        
        await _repository.AddAsync(storageLocation);

        return storageLocation;
    }

    public async Task<StorageLocation> UpdateAsync(StorageLocation storageLocation)
    {
        ArgumentNullException.ThrowIfNull(storageLocation);

        var result = await _repository.GetByIdAsync(storageLocation.Id);
        
        result.CreatedAt = DateTime.SpecifyKind(storageLocation.CreatedAt, DateTimeKind.Utc);
        result.UpdatedAt = DateTime.UtcNow;
        result.Rack = storageLocation.Rack;
        result.Compartment = storageLocation.Compartment;
        result.Part = storageLocation.Part;
        
        await _repository.UpdateAsync(result);
        
        return result;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var storageLocation = await _repository.GetByIdAsync(id);

        await _repository.DeleteAsync(storageLocation);

        return true;
    }
}