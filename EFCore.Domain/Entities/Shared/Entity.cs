namespace EFCore.Domain.Entities.Shared;

public abstract class Entity<TId>
{
    public TId Id { get; set; }
}
