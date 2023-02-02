namespace EFCore.Application.Dtos.Order;

public class CreateOrderDto
{
    public int OrderNumber { get; set; }
    public List<int> Items { get; set; }
    public int ClientId { get; set; }
}
