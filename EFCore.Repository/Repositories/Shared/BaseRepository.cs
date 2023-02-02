using EFCore.Domain.Contracts.Repositories.Shared;
using EFCore.Domain.Entities.Shared;
using EFCore.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data.Repositories.Shared;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity<int>
{
    protected readonly MyContext _context;
    public BaseRepository(MyContext context)
    {
        _context = context;
    }

    public virtual void Add(TEntity entity)
    {
        _context.Add(entity);
    }

    public virtual void Update(TEntity entity)
    {
        _context.Update(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        _context.Remove(entity);
    }
    public virtual void DeleteRange(TEntity[] entities)
    {
        _context.RemoveRange(entities);
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id) =>
        await _context.Set<TEntity>().FindAsync(id);

    public virtual async Task<bool> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Dispose() => _context.Dispose();
}
