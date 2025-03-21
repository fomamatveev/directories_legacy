using DL.Audit.Dtos;

namespace DL.Audit.Interfaces;

/// <summary>
/// Интерфейс сервиса для управления аудитом
/// </summary>
public interface IAuditService
{
    Task<List<AuditActionDto>> ListAsync();
}