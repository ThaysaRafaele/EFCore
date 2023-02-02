using EFCore.Domain.Contracts.Repositories;
using EFCore.Data.Repositories.Shared;
using EFCore.Domain.Entities;
using EFCore.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data.Repositories;

public class ItemRepository : BaseRepository<Item>, IItemRepository
{
    public ItemRepository(MyContext context) : base(context) { }

    public async Task<List<Item>> GetAllItems()
    {
        IQueryable<Item> query = _context.Items.AsNoTracking().OrderBy(i => i.Id);

        return await query.ToListAsync();
    }

    public async Task<Item> GetItemById(int id)
    {
        IQueryable<Item> query = _context.Items.AsNoTracking().OrderBy(i => i.Id);

        return await query.FirstOrDefaultAsync(i => i.Id.Equals(id));
    }

    public async Task<List<Item>> GetItemByName(string name)
    {
        IQueryable<Item> query = _context.Items
                .AsNoTracking()
                .OrderBy(i => i.Id)
                .Where(i => i.Name.Contains(name));

        return await query.ToListAsync();
    }
}
