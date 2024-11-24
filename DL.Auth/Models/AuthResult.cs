namespace DL.Auth.Models;

public class AuthResult
{
    private AuthResult() {}

    public User? User { get; init; }

    public bool IsSuccess => User is not null;

    public static AuthResult Success(User user)
    {
        return new AuthResult { User = user };
    }
    
    public static AuthResult Failure()
    {
        return new AuthResult();
    }
}