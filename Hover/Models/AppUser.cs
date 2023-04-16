namespace Hover.Models;

/// <summary>
/// Application User model class.
/// </summary>
public class AppUser
{
    /// <summary>
    /// Gets or sets the application user's id.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// Gets or sets the application user's username.
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the application user's password.
    /// </summary>
    public string? Password { get; set; }
}