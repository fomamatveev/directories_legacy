namespace DL.Core.Models.Audit;

/// <summary>
/// Тип сущности для аудита
/// </summary>
public class EntityType
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public EntityTypeEnum EntityId { get; set; }
    
    /// <summary>
    /// Наименование сущности для отображения
    /// </summary>
    public string EntityName { get; set; }
}