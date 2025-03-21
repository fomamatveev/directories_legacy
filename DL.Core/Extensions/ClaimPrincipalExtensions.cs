using System.Security.Claims;

namespace DL.Core.Extensions;

/// <summary>
/// Расширение для получение идентификатора пользователя
/// </summary>
public static class ClaimPrincipalExtensions
{
    public static long? TryGetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        var claim = claimsPrincipal.FindFirst("id");

        if (claim == null)
        {
            return null;
        }

        return long.TryParse(claim.Value, out var id) ? id : null;
    }

    public static long GetUserId(this ClaimsPrincipal claimsPrincipal) =>
        TryGetUserId(claimsPrincipal) ?? throw new Exception("Пользователь не найден.");
}