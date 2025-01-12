namespace DL.Audit.Interfaces;

/// <summary>
/// Интерфейс сервиса для управления аудитом
/// </summary>
public interface IAuditService
{
    Task<List<Models.Audit>> ListAsync();

    Task<Models.Audit> GetAsync(int id);
    
    Task<Models.Audit> CreateAsync(Models.Audit action);
    
    Task<Models.Audit> UpdateAsync(Models.Audit action);
    
    Task<bool> DeleteAsync(int id);
}