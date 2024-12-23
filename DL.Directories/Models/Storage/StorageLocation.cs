namespace DL.Directories.Models.Storage;

public class StorageLocation : Entity
{
    /// <summary>
    /// Стеллаж
    /// </summary>
    public int Rack { get; set; }
    
    /// <summary>
    /// Секция
    /// </summary>
    public int Compartment { get; set; }
    
    /// <summary>
    /// Часть
    /// </summary>
    public int Part { get; set; }
}