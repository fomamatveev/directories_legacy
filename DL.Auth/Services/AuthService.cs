using System.Security.Cryptography;
using System.Text;
using DL.Auth.Models;
using DL.Auth.Repositories;

namespace DL.Auth.Services;

public class AuthService(UserRepository userRepository)
{
    private readonly UserRepository _userRepository = userRepository;

    /// <summary>
    /// Метод регистрации пользователя
    /// </summary>
    /// <param name="registerRequest">Сущность запроса регистрации</param>
    /// <returns>AuthResult</returns>
    public async Task<AuthResult> RegisterAsync(RegisterRequest registerRequest)
    {
        if (await _userRepository.GetUserByNameAsync(registerRequest.Username) != null ||
            registerRequest.Password != registerRequest.ConfirmPassword)
            return AuthResult.Failure();
        
        CreatePasswordHash(registerRequest.Password, out var passwordHash, out var passwordSalt);

        var user = new User()
        {
            Username = registerRequest.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            CreatedAt = DateTime.Now.ToUniversalTime()
        };

        await _userRepository.CreateAsync(user);

        return AuthResult.Success(user);
    }

    /// <summary>
    /// Метод авторизации пользователя
    /// </summary>
    /// <param name="loginRequest">Сущность запроса авторизации</param>
    /// <returns>AuthResult</returns>
    public async Task<AuthResult> LoginAsync(LoginRequest loginRequest)
    {
        var user = await _userRepository.GetUserByNameAsync(loginRequest.Username);
        if (user == null || !VerifyPasswordHash(loginRequest.Password, user.PasswordHash, user.PasswordSalt))
            return AuthResult.Failure();

        return AuthResult.Success(user);
    }
    
    /// <summary>
    /// Метод, создающий хэш-пароль и соль пароля
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <param name="passwordHash">Хэш-пароль</param>
    /// <param name="passwordSalt">Соль пароля</param>
    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    /// <summary>
    /// Метод верификации пароля
    /// </summary>
    /// <param name="password">Пароль</param>
    /// <param name="passwordHash">Хэш-пароль</param>
    /// <param name="passwordSalt">Соль пароля</param>
    /// <returns>Возвращает хэш-пароль</returns>
    /// <exception cref="Exception">Ошибка, если хэш и соль пустые</exception>
    private static bool VerifyPasswordHash(string password, byte[]? passwordHash, byte[]? passwordSalt)
    {
        if (passwordHash == null || passwordSalt == null) throw new Exception("User is null.");
        using var hmac = new HMACSHA512(passwordSalt);
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return hash.SequenceEqual(passwordHash);

    }
}