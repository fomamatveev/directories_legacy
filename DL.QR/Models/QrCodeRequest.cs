namespace DL.QR.Models;

/// <summary>
/// QR-модель
/// </summary>
public class QrCodeRequest
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Количество
    /// </summary>
    public int Quantity { get; set; }
}