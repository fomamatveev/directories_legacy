using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Core.Models.Audit;

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
    public EntityTypeEnum EntityId { get; set; }
    
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