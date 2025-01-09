using BlogPost.Domain.Entities;

namespace BlogPost.Domain.Abstractions;

public interface IPostRepository : IRepository<int, Post>
{
    Task<IEnumerable<Post>> GetPaginatedAsync(int pageNum, int pageSize, string? title, int[]? tagIds);
    Task<Post> GetByPostDateAsync(DateOnly date);
    Task SetTagsAsync(int postId, IEnumerable<Entities.Tag> tags);
    Task<IEnumerable<Post>> GetLatestAsync(int? requestNum);
    Task<int> GetPostCountAsync();
}