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

    public async Task<int> CreateAsync(Tag entity)
    {
        await _dbContext.Tags.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<Tag?> GetByIdAsync(int id)
    {
        return await _dbContext.Tags.FindAsync(id);
    }

    public async Task<IEnumerable<Tag>> GetAllAsync()
    {
        return await _dbContext.Tags.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Tag entity)
    {
        var affectedRows = await _dbContext.Tags.Where(t => t.Id == entity.Id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(x => x.Name, entity.Name)
                .SetProperty(x => x.Color, entity.Color));

        return affectedRows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var affectedRows = await _dbContext.Tags.Where(t => t.Id == id)
            .ExecuteDeleteAsync();

        return affectedRows > 0;
    }

    public async Task<IEnumerable<Tag>> GetTagsByIdsAsync(IEnumerable<int> tagIds)
    {
        var uniqueTagIds = new HashSet<int>(tagIds);

        var tagEntities = await _dbContext.Tags
            .Where(t => uniqueTagIds.Contains(t.Id))
            .ToListAsync();

        return tagEntities;
    }

    public async Task<Tag?> GetByNameAsync(string name)
    {
        return await _dbContext.Tags.FirstOrDefaultAsync(t => t.Name == name);
    }

    public async Task<bool> IsNameUniqueAsync(string name, int excludedTagId)
    {
        return !await _dbContext.Tags.AnyAsync(t => t.Name == name && t.Id != excludedTagId);
    }
}