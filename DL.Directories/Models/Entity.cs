namespace DL.Directories.Models;

/// <summary>
/// Базовая сущность
/// </summary>
public class Entity
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Наименование записи
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Краткое наименование записи
    /// </summary>
    public string? ShortName { get; set; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Дата редактирования
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}