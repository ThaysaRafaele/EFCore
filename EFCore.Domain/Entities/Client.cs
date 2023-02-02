using EFCore.Domain.Entities.Shared;

namespace EFCore.Domain.Entities;

public class Client : Entity<int>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public virtual List<Order> Orders { get; set; }
}

