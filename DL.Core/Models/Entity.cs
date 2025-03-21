namespace DL.Core.Models;

/// <summary>
/// Базовая сущность
/// </summary>
public class Entity
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Наименование записи
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Краткое наименование записи
    /// </summary>
    public string? ShortName { get; set; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Пользователь, создавший запись
    /// </summary>
    public long CreatedBy { get; set; }
    
    /// <summary>
    /// Дата редактирования
    /// </summary>
    public DateTime UpdatedAt { get; set; }
    
    /// <summary>
    /// Пользователь, внесший изменения
    /// </summary>
    public long UpdatedBy { get; set; }
}