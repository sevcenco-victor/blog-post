using BlogPost.Domain.Posts;
using BlogPost.Domain.Primitives;

namespace BlogPost.Domain.Users;

public class User : Entity<Guid>
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public UserRoles Role { get; set; } = UserRoles.User;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiry { get; set; }
    public IEnumerable<Post> Posts { get; set; }
}