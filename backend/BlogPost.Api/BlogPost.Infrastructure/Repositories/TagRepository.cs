using BlogPost.Domain.Tags;
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

    public async Task<Guid> CreateAsync(Tag entity, CancellationToken cancellationToken)
    {
        entity.Id = Guid.NewGuid();
        await _dbContext.Tags.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<Tag?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
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

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var affectedRows = await _dbContext.Tags
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        return affectedRows > 0;
    }

    public async Task<IEnumerable<Tag>> GetTagsByIdsAsync(IEnumerable<Guid> tagIds, CancellationToken cancellationToken)
    {
        var uniqueTagIds = new HashSet<Guid>(tagIds);

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
            .FirstOrDefaultAsync(t => t.Name.ToLower()  == name.ToLower() , cancellationToken);
    }

    public async Task<bool> IsNameUniqueAsync(string name, Guid excludedTagId, CancellationToken cancellationToken)
    {
        return !await _dbContext.Tags
            .AsNoTracking()
            .AnyAsync(t => t.Name.ToLower() == name.ToLower() && t.Id != excludedTagId, cancellationToken);
    }
}