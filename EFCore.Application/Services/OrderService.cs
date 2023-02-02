using AutoMapper;
using EFCore.Application.Contracts.Services;
using EFCore.Application.Dtos.Client;
using EFCore.Application.Dtos.Order;
using EFCore.Data.Repositories;
using EFCore.Domain.Contracts.Repositories;
using EFCore.Domain.Entities;

namespace EFCore.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    public OrderService(IOrderRepository orderRepository,
                              IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task CreateOrderAsync(CreateOrderDto newOrder)
    {
        try
        {
            var order = _mapper.Map<Order>(newOrder);
            _orderRepository.Add(order);
            await _orderRepository.SaveChangeAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<OrderDto>> GetAll()
    {
        try
        {
            var orders = await _orderRepository.GetAllOrders();
            var clientsDto = _mapper.Map<List<OrderDto>>(orders);

            return clientsDto;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<OrderDto> GetByIdAsync(int id)
    {
        try
        {
            var order = await _orderRepository.GetOrderById(id);
            var orderDto = _mapper.Map<OrderDto>(order);

            return orderDto;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<List<OrderDto>> GetOrderByNumber(int number)
    {
        try
        {
            var order = await _orderRepository.GetOrderByNumber(number);
            var orderDto = _mapper.Map<List<OrderDto>>(order);

            return orderDto;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task DeleteOrderAsync(int id)
    {
        try
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order is null) throw new Exception("Registro não encontrado");

            _orderRepository.Delete(order);
            await _orderRepository.SaveChangeAsync();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task UpdateOrderAsync(UpdateOrderDto updatedOrder)
    {
        try
        {
            var order = await _orderRepository.GetOrderById(updatedOrder.Id);
            updatedOrder.Id = order.Id;

            if (order is null) throw new Exception("Registro não encontrado");

            var itemsToRemove = order.OrdersItems
                 .Where(oi => !updatedOrder.Items.Contains(oi.ItemId))
                 .ToArray();

            _orderRepository.DeleteOrderItem(itemsToRemove);

            _mapper.Map(updatedOrder, order);
            _orderRepository.Update(order);
            await _orderRepository.SaveChangeAsync();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
