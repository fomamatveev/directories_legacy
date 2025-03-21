using DL.Core.Models.Storage;

namespace DL.Core.Models.Product;

/// <summary>
/// Сущность товара
/// </summary>
public class Product : Entity
{
    /// <summary>
    /// Описание товара
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Количество товара
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// Категория продукта
    /// </summary>
    public ProductType ProductType { get; set; }
    
    /// <summary>
    /// Место хранения
    /// </summary>
    public StorageLocation StorageLocation { get; set; }
    
    /// <summary>
    /// Идентификатор категории продукта
    /// </summary>
    public long ProductTypeId { get; set; }
    
    /// <summary>
    /// Идентификатор места хранения
    /// </summary>
    public long StorageLocationId { get; set; }
}