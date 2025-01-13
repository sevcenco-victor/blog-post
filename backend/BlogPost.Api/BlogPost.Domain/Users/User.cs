using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Primitives;

namespace BlogPost.Domain.Users;

public class User : Entity
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public UserRoles Role { get; set; } = UserRoles.USER;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiry { get; set; }
}