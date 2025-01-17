using BlogPost.Domain.Common;

namespace BlogPost.Domain.Users;

public interface IUserRepository : IRepository<Guid, User>
{
    Task<bool> IsEmailUnique(string email);
    Task<bool> IsUsernameUnique(string username);
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
}