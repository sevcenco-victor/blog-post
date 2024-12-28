using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Entities;
using BlogPost.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly BlogDbContext _dbContext;

    public PostRepository(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<int> CreateAsync(Post entity)
    {
        await _dbContext.Posts.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        
        return entity.Id;
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        var post = await _dbContext.Posts
            .Include<Post, ICollection<Tag>>(p => p.Tags)
            .FirstOrDefaultAsync(p => p.Id == id);

        return post;
    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        return await _dbContext.Posts
            .Include<Post, ICollection<Tag>>(b => b.Tags)
            .ToListAsync();
    }


    public async Task<bool> UpdateAsync(Post entity, int entityId)
    {
        var rowsAffected = await _dbContext.Posts.Where(b => b.Id == entityId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(x => x.Title, entity.Title)
                    .SetProperty(x => x.Text, entity.Text)
                    .SetProperty(x => x.LastEdit, entity.LastEdit)
                    .SetProperty(x => x.ImageUrl, entity.ImageUrl));

        return rowsAffected > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var affectedRows = await _dbContext.Posts.Where(b => b.Id == id)
            .ExecuteDeleteAsync();

        return affectedRows > 0;
    }

    public async Task<IEnumerable<Post>> GetPaginatedAsync(int pageNum, int pageSize)
    {
        var skip = pageSize * (pageNum - 1);
        return await _dbContext.Posts
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Post> GetByPostDateAsync(DateOnly date)
    {
        return await _dbContext.Posts.FirstAsync<Post>(b => b.PostDate == date);
    }

    public async Task SetTagsAsync(int postId, IEnumerable<Tag> tags)
    {
        var post = await GetByIdAsync(postId);

        post!.Tags.Clear();
        foreach (var tag in tags)
        {
            post.Tags.Add(tag);
        }

        await _dbContext.SaveChangesAsync();
    }
}