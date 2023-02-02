
using EFCore.Domain.Contracts.Repositories;
using EFCore.Data.Repositories.Shared;
using EFCore.Domain.Entities;
using EFCore.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data.Repositories;

public class ClientRepository : BaseRepository<Client>, IClientRepository
{
    public ClientRepository(MyContext context) : base(context) { }

    public async Task<List<Client>> GetAllClients()
    {
        IQueryable<Client> query = GetQueryBase();


        return await query.ToListAsync();
    }

    public async Task<Client> GetClientById(int id)
    {
        IQueryable<Client> query = GetQueryBase();

        return await query.FirstOrDefaultAsync(c => c.Id.Equals(id));
    }

    public async Task<List<Client>> GetClientByName(string name)
    {
        IQueryable<Client> query = GetQueryBase();

        query = query.Where(c => c.Name.ToLower().Contains(name.ToLower()));

        return await query.ToListAsync();
    }

    private IQueryable<Client> GetQueryBase()
    {
        return _context.Clients
            .AsNoTracking()
            .OrderBy(c => c.Id)
            .Include(c => c.Orders)
                .ThenInclude(o => o.OrdersItems)
                    .ThenInclude(oi => oi.Item);
    }
}
