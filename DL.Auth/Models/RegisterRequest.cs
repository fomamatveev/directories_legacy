namespace DL.Auth.Models;

public class RegisterRequest
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Подтверждение пароля
    /// </summary>
    public string ConfirmPassword { get; set; }
}