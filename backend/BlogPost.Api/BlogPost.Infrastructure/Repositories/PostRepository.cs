using BlogPost.Domain.Posts;
using BlogPost.Domain.Tags;
using BlogPost.Domain.Users;
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


    public async Task<Guid> CreateAsync(Post entity, CancellationToken cancellationToken)
    {
        entity.Id = Guid.NewGuid();
        foreach (var tag in entity.Tags)
        {
            _dbContext.Entry(tag).State = EntityState.Unchanged;
        }

        await _dbContext.Posts.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task<Post?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var post = await _dbContext.Posts
            .AsNoTracking()
            .Include<Post, ICollection<Tag>>(p => p.Tags)
            .Include<Post, User>(x => x.User)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        return post;
    }

    public async Task<IEnumerable<Post>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Posts
            .AsNoTracking()
            .Include<Post, ICollection<Tag>>(b => b.Tags)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> UpdateAsync(Post entity, CancellationToken cancellationToken)
    {
        var rowsAffected = await _dbContext.Posts
            .Where(b => b.Id == entity.Id)
            .ExecuteUpdateAsync(setters =>
                    setters.SetProperty(x => x.Title, entity.Title)
                        .SetProperty(x => x.Text, entity.Text)
                        .SetProperty(x => x.LastEdit, entity.LastEdit)
                        .SetProperty(x => x.ImageUrl, entity.ImageUrl),
                cancellationToken);

        return rowsAffected > 0;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var affectedRows = await _dbContext.Posts
            .Where(b => b.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        return affectedRows > 0;
    }

    public async Task<IEnumerable<Post>> GetPaginatedAsync(Guid? userId, int pageNum, int pageSize, string? title,
        Guid[]? tagIds,
        CancellationToken cancellationToken)
    {
        var query = _dbContext.Posts
            .AsNoTracking()
            .Include(p => p.Tags)
            .AsQueryable();

        if (userId != null)
        {
            query = query.Where(b => b.UserId == userId);
        }

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
            .ToListAsync(cancellationToken);
    }

    public async Task<Post> GetByPostDateAsync(DateOnly date, CancellationToken cancellationToken)
    {
        return await _dbContext.Posts
            .AsNoTracking()
            .FirstAsync(b => b.PostDate == date, cancellationToken);
    }

    public async Task SetTagsAsync(Guid postId, IEnumerable<Tag> tags, CancellationToken cancellationToken)
    {
        var post = await _dbContext.Posts
            .Include(p => p.Tags)
            .FirstOrDefaultAsync(p => p.Id == postId, cancellationToken);

        post?.Tags.Clear();
        foreach (var tag in tags)
        {
            post?.Tags.Add(tag);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Post>> GetLatestAsync(int? requestNum, CancellationToken cancellationToken)
    {
        var take = requestNum ?? 10;

        var posts = await _dbContext.Posts
            .AsNoTracking()
            .Include<Post, ICollection<Tag>>(b => b.Tags)
            .OrderByDescending(p => p.PostDate)
            .Take(take)
            .ToListAsync(cancellationToken);

        return posts;
    }

    public async Task<int> GetPostCountAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Posts
            .AsNoTracking()
            .CountAsync(cancellationToken);
    }
}