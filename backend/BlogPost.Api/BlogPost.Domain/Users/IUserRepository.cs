using BlogPost.Domain.Entities;
using BlogPost.Domain.Users;

namespace BlogPost.Domain.Abstractions;

public interface IUserRepository : IRepository<int, User>
{
    Task<bool> IsEmailUnique(string email);
    Task<bool> IsUsernameUnique(string username);
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
    // Task SetRefreshToken(string refreshToken, DateTime expiresOn, CancellationToken cancellationToken = default);
}