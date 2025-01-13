using BlogPost.Domain.Entities;
using BlogPost.Domain.Tags;

namespace BlogPost.Domain.Abstractions;

public interface ITagRepository : IRepository<int, Tag>
{
    Task<IEnumerable<Tag>> GetTagsByIdsAsync(IEnumerable<int> tagIds, CancellationToken cancellationToken = default);
    Task<Tag?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<bool> IsNameUniqueAsync(string name, int excludeTagId, CancellationToken cancellationToken = default);
}