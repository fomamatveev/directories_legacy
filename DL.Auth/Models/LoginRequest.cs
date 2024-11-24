namespace DL.Auth.Models;

public class LoginRequest
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string Password { get; set; }
}