using AutoMapper;
using EFCore.Application.Dtos.Client;
using EFCore.Application.Dtos.Item;
using EFCore.Application.Dtos.Order;
using EFCore.Domain.Entities;

namespace EFCore.Application.AutoMapper;

public class DafaultMapper : Profile
{
    public DafaultMapper()
    {
        CreateMap<CreateClienteDto, Client>().ReverseMap();
        CreateMap<CreateItemDto, Item>().ReverseMap();
        CreateMap<ItemDto, Item>().ReverseMap();

        CreateMap<CreateOrderDto, Order>()
            .ForMember(o => o.OrdersItems, opt => opt.MapFrom(src => src.Items.Select(itemId => new OrderItem
            {
                ItemId = itemId
            })));

        CreateMap<Client, UpdateClienteDto>().ReverseMap();
        CreateMap<UpdateOrderDto, Order>()
                .ForMember(o => o.OrdersItems, opt => opt.MapFrom(src => src.Items.Select(itemId => new OrderItem
                {
                    ItemId = itemId
                })));

        CreateMap<Client, ClientDto>()
            .ForMember(dto => dto.AmountSpent, opt => opt.MapFrom(src => src.Orders.Sum(o => o.OrdersItems.Sum(oi => oi.Item.UnitPrice))));

        CreateMap<Order, OrderDto>()
            .ForMember(dto => dto.ClientName, opt => opt.MapFrom(src => src.Client.Name))
            .ForMember(dto => dto.Items,
                opt => opt.MapFrom(opt => opt.OrdersItems.Select(oi => oi.Item)))
            .ForMember(dto => dto.Total, opt => opt.MapFrom(src => src.OrdersItems.Sum(oi => oi.Item.UnitPrice)))
            .ForMember(dest => dest.QuantityItems, opt => opt.MapFrom(src => src.OrdersItems.Count));
    }
}
