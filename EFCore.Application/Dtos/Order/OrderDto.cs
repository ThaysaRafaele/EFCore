
using EFCore.Application.Dtos.Item;

namespace EFCore.Application.Dtos.Order;

public class OrderDto
{
    public string ClientName { get; set; }
    public int OrderNumber { get; set; }
    public List<ItemDto> Items { get; set; }
    public int Total { get; set; }
    public int QuantityItems { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
}
