using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Core.Models;

public enum AuditActionEnum
{
    /// <summary>
    /// Чтение/просмотр
    /// </summary>
    Read = 1,
    
    /// <summary>
    /// Удаление
    /// </summary>
    Delete = 2,
    
    /// <summary>
    /// Обновление
    /// </summary>
    Update = 3,
    
    /// <summary>
    /// Создание
    /// </summary>
    Create = 4,
}

[Table("AuditLog")]
public class AuditAction
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Действие
    /// </summary>
    [Column("Action")]
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
    public long UpdatedBy { get; set; }
}