using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Entities;
using BlogPost.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.Infrastructure.Repositories;

public class TagRepository : ITagRepository
{
    private readonly BlogDbContext _dbContext;

    public TagRepository(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateAsync(Tag entity, CancellationToken cancellationToken)
    {
        await _dbContext.Tags.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<Tag?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Tags
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Tag>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Tags
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> UpdateAsync(Tag entity, CancellationToken cancellationToken)
    {
        var affectedRows = await _dbContext.Tags.Where(t => t.Id == entity.Id)
            .ExecuteUpdateAsync(setters => setters
                    .SetProperty(x => x.Name, entity.Name)
                    .SetProperty(x => x.Color, entity.Color)
                , cancellationToken);

        return affectedRows > 0;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var affectedRows = await _dbContext.Tags
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        return affectedRows > 0;
    }

    public async Task<IEnumerable<Tag>> GetTagsByIdsAsync(IEnumerable<int> tagIds, CancellationToken cancellationToken)
    {
        var uniqueTagIds = new HashSet<int>(tagIds);

        var tagEntities = await _dbContext.Tags
            .AsNoTracking()
            .Where(t => uniqueTagIds.Contains(t.Id))
            .ToListAsync(cancellationToken);

        return tagEntities;
    }

    public async Task<Tag?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _dbContext.Tags
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Name == name, cancellationToken);
    }

    public async Task<bool> IsNameUniqueAsync(string name, int excludedTagId, CancellationToken cancellationToken)
    {
        return !await _dbContext.Tags
            .AsNoTracking()
            .AnyAsync(t => t.Name == name && t.Id != excludedTagId, cancellationToken);
    }
}