namespace BlogPost.Domain.Abstractions;

public interface IRepository<TK, T> where T : class
{
    Task<int> CreateAsync(T entity);
    Task<T?> GetByIdAsync(TK id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<bool> UpdateAsync(T entity, TK entityId);
    Task<bool> DeleteAsync(TK id);
}