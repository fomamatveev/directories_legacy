using DL.Audit.Enum;

namespace DL.Audit.Models;

public class Audit
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Действие
    /// </summary>
    public AuditActionEnum Action { get; set; }
    
    /// <summary>
    /// Наименование сущности
    /// </summary>
    public string EntityName { get; set; }
    
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public long EntityId { get; set; }
    
    /// <summary>
    /// Изменения
    /// </summary>
    public string Changes { get; set; }
    
    /// <summary>
    /// Дата действия
    /// </summary>
    public DateTime UpdatedAt { get; set; }
    
    /// <summary>
    /// Кем было затриггерено
    /// </summary>
    public long ChangedBy { get; set; }
}