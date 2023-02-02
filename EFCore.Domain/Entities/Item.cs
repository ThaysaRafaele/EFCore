using EFCore.Domain.Entities.Shared;

namespace EFCore.Domain.Entities;

public class Item : Entity<int>
{
    public string Name { get; set; }
    public double UnitPrice { get; set; }
    public ICollection<OrderItem> OrdersItems { get; set; }
}
