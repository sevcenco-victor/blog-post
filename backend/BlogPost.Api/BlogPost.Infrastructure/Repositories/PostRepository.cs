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


    public async Task<bool> UpdateAsync(Post entity)
    {
        var rowsAffected = await _dbContext.Posts.Where(b => b.Id == entity.Id)
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

    public async Task<IEnumerable<Post>> GetPaginatedAsync(int pageNum, int pageSize, string? title, int[]? tagIds)
    {
        var query = _dbContext.Posts
            .Include(p => p.Tags)
            .AsQueryable();
        
        if (tagIds != null)
        {
            query = query
                .Where(p => tagIds.All(tagId => p.Tags.Select(tag => tag.Id).Contains(tagId)));
        }

        if (!string.IsNullOrWhiteSpace(title))
        {
            query = query.Where(b => b.Title.ToLower().Contains(title.ToLower()));
        }


        var skip = pageSize * (pageNum - 1);
        return await query
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Post> GetByPostDateAsync(DateOnly date)
    {
        return await _dbContext.Posts.FirstAsync(b => b.PostDate == date);
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

    public async Task<IEnumerable<Post>> GetLatestAsync(int? requestNum)
    {
        var take = requestNum ?? 10;

        var posts = await _dbContext.Posts
            .Include<Post, ICollection<Tag>>(b => b.Tags)
            .OrderByDescending(p => p.PostDate)
            .Take(take)
            .ToListAsync();

        return posts;
    }

    public async Task<int> GetPostCountAsync()
    {
        return await _dbContext.Posts.CountAsync();
    }
}