using System.ComponentModel;
using System.Reflection;

namespace DL.Core.Extensions;

/// <summary>
/// Расширение для работы с сущностью
/// </summary>
public static class PropertyExtensions
{
    /// <summary>
    /// Получить описание
    /// </summary>
    /// <param name="property"></param>
    /// <returns></returns>
    public static string GetDescription(this PropertyInfo property)
    {
        return property.GetCustomAttribute<DescriptionAttribute>()?.Description ?? property.Name;
    }

    public static string GetPropertyDescription<T>(this T obj, string propertyName)
    {
        var property = typeof(T).GetProperty(propertyName);
        return property?.GetDescription() ?? propertyName;
    }
}