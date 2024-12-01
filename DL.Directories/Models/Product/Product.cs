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
    
    public int ProductTypeId { get; set; }
}