using System.ComponentModel;

namespace DL.Core.Models.Audit;

public enum AuditActionEnum
{
    /// <summary>
    /// Чтение/просмотр
    /// </summary>
    [Description("Просмотр")]
    Read = 1,
    
    /// <summary>
    /// Удаление
    /// </summary>
    [Description("Удаление")]
    Delete = 2,
    
    /// <summary>
    /// Обновление
    /// </summary>
    [Description("Изменение")]
    Update = 3,
    
    /// <summary>
    /// Создание
    /// </summary>
    [Description("Создание")]
    Create = 4,
}