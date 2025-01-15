using BlogPost.Domain.Common;
using BlogPost.Domain.Entities;
using BlogPost.Domain.Tags;

namespace BlogPost.Domain.Posts;

public interface IPostRepository : IRepository<int, Post>
{
    Task<IEnumerable<Post>> GetPaginatedAsync(int pageNum, int pageSize, string? title, int[]? tagIds,
        CancellationToken cancellationToken = default);

    Task<Post> GetByPostDateAsync(DateOnly date, CancellationToken cancellationToken = default);
    Task SetTagsAsync(int postId, IEnumerable<Tag> tags, CancellationToken cancellationToken = default);
    Task<IEnumerable<Post>> GetLatestAsync(int? requestNum, CancellationToken cancellationToken = default);
    Task<int> GetPostCountAsync(CancellationToken cancellationToken = default);
}