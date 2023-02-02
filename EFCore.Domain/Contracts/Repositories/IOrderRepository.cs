using EFCore.Domain.Entities;
using EFCore.Domain.Contracts.Repositories.Shared;

namespace EFCore.Domain.Contracts.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<List<Order>> GetAllOrders();
    Task<Order> GetOrderById(int id);
    Task<List<Order>> GetOrderByNumber(int number);
    void DeleteOrderItem(OrderItem[] items);
}
