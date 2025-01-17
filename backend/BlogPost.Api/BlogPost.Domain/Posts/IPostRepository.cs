using BlogPost.Domain.Common;
using BlogPost.Domain.Tags;

namespace BlogPost.Domain.Posts;

public interface IPostRepository : IRepository<Guid, Post>
{
    Task<IEnumerable<Post>> GetPaginatedAsync(int pageNum, int pageSize, string? title, Guid[]? tagIds,
        CancellationToken cancellationToken = default);

    Task<Post> GetByPostDateAsync(DateOnly date, CancellationToken cancellationToken = default);
    Task SetTagsAsync(Guid postId, IEnumerable<Tag> tags, CancellationToken cancellationToken = default);
    Task<IEnumerable<Post>> GetLatestAsync(int? requestNum, CancellationToken cancellationToken = default);
    Task<int> GetPostCountAsync(CancellationToken cancellationToken = default);
}