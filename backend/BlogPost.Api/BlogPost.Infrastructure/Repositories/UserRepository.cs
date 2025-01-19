using BlogPost.Domain.Users;
using BlogPost.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogPost.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BlogDbContext _dbContext;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(ILogger<UserRepository> logger, BlogDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<Guid> CreateAsync(User entity, CancellationToken cancellationToken)
    {
        entity.Id = Guid.NewGuid();
        await _dbContext.Users.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> UpdateAsync(User entity, CancellationToken cancellationToken = default)
    {
        var affectedRows = await _dbContext.Users
            .Where(x => x.Id == entity.Id)
            .ExecuteUpdateAsync(p =>
                    p.SetProperty(x => x.Email, entity.Email)
                        .SetProperty(x => x.Username, entity.Username)
                        .SetProperty(x => x.PasswordHash, entity.PasswordHash)
                        .SetProperty(x => x.BirthDate, entity.BirthDate)
                        .SetProperty(x => x.RefreshToken, entity.RefreshToken)
                        .SetProperty(x => x.RefreshTokenExpiry, entity.RefreshTokenExpiry)
                , cancellationToken);

        return affectedRows > 0;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var affectedRows = await _dbContext.Users
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        return affectedRows > 0;
    }

    public async Task<bool> IsEmailUnique(string email)
    {
        return !await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Email == email);
    }

    public async Task<bool> IsUsernameUnique(string username)
    {
        return !await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Username == username);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .Where(u => u.Username == userName)
            .FirstOrDefaultAsync(cancellationToken);
    }
}