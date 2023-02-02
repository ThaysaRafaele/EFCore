using EFCore.Domain.Entities.Shared;

namespace EFCore.Domain.Contracts.Repositories.Shared;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity<int>
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<TEntity?> GetByIdAsync(int id);
    Task<bool> SaveChangeAsync();
}
