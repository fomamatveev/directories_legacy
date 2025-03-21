using DL.Core.Models;

namespace DL.Directories.Dtos;

public class ProductListDto : Entity
{
    /// <summary>
    /// Количество товара
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// Категория продукта
    /// </summary>
    public string ProductTypeName { get; set; }
    
    /// <summary>
    /// Место хранения
    /// </summary>
    public string StorageLocationPosition { get; set; }
}