using BlogPost.Domain.Entities;

namespace BlogPost.Domain.Abstractions;

public interface ITagRepository : IRepository<int, Tag>
{
    Task<IEnumerable<Tag>> GetTagsByIdsAsync(IEnumerable<int> tagIds);
    Task<Tag?> GetByNameAsync(string name);
    Task<bool> IsNameUniqueAsync(string name, int excludeTagId);
}