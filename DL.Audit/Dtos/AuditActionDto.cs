namespace DL.Audit.Dtos;

public class AuditActionDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Действие
    /// </summary>
    public string Action { get; set; }
    
    /// <summary>
    /// Наименование сущности
    /// </summary>
    public string EntityName { get; set; }
    
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
    public string UpdatedBy { get; set; }
}