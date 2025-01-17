using BlogPost.Domain.Common;

namespace BlogPost.Domain.Tags;

public interface ITagRepository : IRepository<Guid, Tag>
{
    Task<IEnumerable<Tag>> GetTagsByIdsAsync(IEnumerable<Guid> tagIds, CancellationToken cancellationToken = default);
    Task<Tag?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<bool> IsNameUniqueAsync(string name, Guid excludeTagId, CancellationToken cancellationToken = default);
}