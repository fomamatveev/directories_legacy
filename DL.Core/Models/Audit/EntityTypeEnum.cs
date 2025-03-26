namespace DL.Core.Models.Audit;

/// <summary>
/// Тип сущности
/// </summary>
public enum EntityTypeEnum
{
    /// <summary>
    /// Пользователь
    /// </summary>
    User = 1,
    
    /// <summary>
    /// Товар
    /// </summary>
    Product = 2,
    
    /// <summary>
    /// Категория товара
    /// </summary>
    ProductType = 3,
    
    /// <summary>
    /// Место хранения
    /// </summary>
    StorageLocation = 4,
}