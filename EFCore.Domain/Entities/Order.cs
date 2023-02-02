using EFCore.Domain.Entities.Shared;

namespace EFCore.Domain.Entities;

public class Order : Entity<int>
{
    public int OrderNumber { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public ICollection<OrderItem> OrdersItems { get; set; }
    public int? ClientId { get; set; }
    public virtual Client? Client { get; set; }
}
