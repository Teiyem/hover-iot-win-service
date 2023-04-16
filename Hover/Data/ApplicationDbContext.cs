using Hover.Models;
using Microsoft.EntityFrameworkCore;

namespace Hover.Data;

/// <summary>
/// Represents the database context for the application, which provides access to the database through Entity Framework Core.
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class with the specified options.
    /// </summary>
    /// <param name="options">The options to be used by the context.</param>
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    /// <summary>
    /// Gets or sets the database set for the application users.
    /// </summary>
    public DbSet<AppUser> AppUsers { get; set; }
}