namespace BlogPost.Domain.Common;

public interface IRepository<TK, T> where T : class
{
    Task<int> CreateAsync(T entity, CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(TK id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(TK id, CancellationToken cancellationToken = default);
}