using EFCore.Domain.Contracts.Repositories;
using EFCore.Data.Repositories.Shared;
using EFCore.Domain.Entities;
using EFCore.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(MyContext context) : base(context) { }

    public async Task<List<Order>> GetAllOrders()
    {
        IQueryable<Order> query = GetQueryBase();

        return await query.ToListAsync();
    }

    public async Task<Order> GetOrderById(int id)
    {
        IQueryable<Order> query = GetQueryBase();

        return await query.FirstOrDefaultAsync(o => o.Id.Equals(id));
    }

    public async Task<List<Order>> GetOrderByNumber(int number)
    {
        IQueryable<Order> query = GetQueryBase();

        query = query.Where(o => o.OrderNumber.Equals(number));

        return await query.ToListAsync();
    }

    public async void DeleteOrderItem(OrderItem[] items)
    {
        _context.OrdersItems.RemoveRange(items);
    }

    private IQueryable<Order> GetQueryBase()
    {
        return _context.Orders
            .AsNoTracking()
            .Include(o => o.OrdersItems)
                .ThenInclude(i => i.Item)
            .Include(o => o.Client)
            .OrderBy(c => c.Id);
    }
}
