using EFCore.Application.Dtos.Order;

namespace EFCore.Application.Contracts.Services;

public interface IOrderService
{
    Task CreateOrderAsync(CreateOrderDto newOrder);
    Task<List<OrderDto>> GetAll();
    Task<OrderDto> GetByIdAsync(int id);
    Task<List<OrderDto>> GetOrderByNumber(int number);
    Task UpdateOrderAsync(UpdateOrderDto newClient);
    Task DeleteOrderAsync(int id);
}
