using System.ComponentModel;
using System.Reflection;

namespace DL.Core.Extensions;

/// <summary>
/// Расширение для работы с enum
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Получить описание
    /// </summary>
    /// <param name="value">Enum</param>
    /// <returns>Описание</returns>
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? value.ToString();
    }
}