using DL.Directories.Models.Storage;

namespace DL.Directories.Interfaces.StorageInterface;

/// <summary>
/// Интерфейс сервиса для управления местом хранения
/// </summary>
public interface IStorageLocationService
{
    Task<List<StorageLocation>> ListAsync();

    Task<StorageLocation> GetAsync(int id);
    
    Task<StorageLocation> CreateAsync(StorageLocation product);
    
    Task<StorageLocation> UpdateAsync(StorageLocation product);
    
    Task<bool> DeleteAsync(int id);
}