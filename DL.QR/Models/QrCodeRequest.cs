namespace DL.QR.Models;

/// <summary>
/// QR-модель
/// </summary>
public class QrCodeRequest
{
    /// <summary>
    /// Наименование
    /// </summary>
    public long Name { get; set; }
    
    /// <summary>
    /// Количество
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// Категория
    /// </summary>
    public long ProductTypeId { get; set; }
}