namespace DL.Core.Models.Auth;

public class User
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование пользователя
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Хэш-пароль пользователя
    /// </summary>
    public byte[] PasswordHash { get; set; }
    
    /// <summary>
    /// Соль хэш-пароля пользователя
    /// </summary>
    public byte[] PasswordSalt { get; set; }
    
    /// <summary>
    /// Дата создания пользователя
    /// </summary>
    public DateTime CreatedAt { get; set; }
}