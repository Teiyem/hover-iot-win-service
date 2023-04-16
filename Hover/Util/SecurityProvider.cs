using Hover.Models;
using Microsoft.AspNetCore.Identity;

namespace Hover.Util;

/// <summary>
/// A class that provides methods for hashing, hashing verification and API key creation.
/// </summary>
public class SecurityProvider
{
    /// <summary>
    /// Hashes the password of the given AppUser.
    /// </summary>
    /// <param name="user">The AppUser to hash the password for.</param>
    /// <returns>The hashed password.</returns>
    public static string HashPassword(AppUser user)
    {
        var hasher = new PasswordHasher<AppUser>();

        return hasher.HashPassword(user, user.Password); ;
    }

    /// <summary>
    /// Verifies if the given password matches the hashed password for the given AppUser.
    /// </summary>
    /// <param name="user">The AppUser to verify the password for.</param>
    /// <param name="hashedPassword">The hashed password to compare against.</param>
    /// <param name="password">The password to verify.</param>
    /// <returns>True if the password matches the hashed password, false otherwise.</returns>
    public static bool VerifyPassword(AppUser user, string hashedPassword, string password)
    {
        var hasher = new PasswordHasher<AppUser>();

        var result = hasher.VerifyHashedPassword(user, hashedPassword, password);

        return result == PasswordVerificationResult.Success;
    }
}