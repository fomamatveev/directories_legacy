using DL.Directories.Models.Storage;

namespace DL.Directories.Models.Product;

/// <summary>
/// Сущность товара
/// </summary>
public class Product : Entity
{
    /// <summary>
    /// Описание товара
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Количество товара
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// Тип продукта
    /// </summary>
    public ProductType ProductType { get; set; }
    
    /// <summary>
    /// Место хранения
    /// </summary>
    public StorageLocation StorageLocation { get; set; }
    
    public int ProductTypeId { get; set; }
    
    public int StorageLocationId { get; set; }
}