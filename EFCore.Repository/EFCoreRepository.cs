using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly Context _context;
        public EFCoreRepository(Context context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<Client>> GetAllClients(bool includeOrder = false)
        {
            IQueryable<Client> query = _context.Clients;

            if(includeOrder)
            {
                query = _context.Clients.Include(c => c.Orders);
            }

            query = query.AsNoTracking().OrderBy(c => c.Id);

            return await query.ToListAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            IQueryable<Client> query = _context.Clients;

            query = query.AsNoTracking().OrderBy(c => c.Id);

            return await query.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client[]> GetClientByName(string name)
        {
            IQueryable<Client> query = _context.Clients;

            query = query.AsNoTracking()
                .Where(c => c.Name.Contains(name))
                .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrders(bool includeItems = false)
        {
            IQueryable<Order> query = _context.Orders;

            if (includeItems)
            {
                query = _context.Orders.Include(o => o.OrdersItems)
                    .ThenInclude(i => i.Item);
            }

            query = query.AsNoTracking().OrderBy(c => c.Id);

            return await query.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id, bool includeItems = false)
        {
            IQueryable<Order> query = _context.Orders;

            if (includeItems)
            {
                query = _context.Orders.Include(o => o.OrdersItems)
                    .ThenInclude(i => i.Item);
            }

            query = query.AsNoTracking().OrderBy(c => c.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Order[]> GetOrderByNumber(int number)
        {
            IQueryable<Order> query = _context.Orders;

            query = query.AsNoTracking()
                .Where(o => o.OrderNumber == number)
                .OrderBy(o => o.Id);

            return await query.ToArrayAsync();
        }
    }
}
