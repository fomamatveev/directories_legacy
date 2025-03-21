using DL.Core.Models;

namespace DL.Directories.Dtos;

public class ProductDto : Entity
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
    /// Идентификатор категории продукта
    /// </summary>
    public long ProductTypeId { get; set; }
    
    /// <summary>
    /// Идентификатор места хранения
    /// </summary>
    public long StorageLocationId { get; set; }
}