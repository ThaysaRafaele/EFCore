using EFCore.Domain.Entities;
using EFCore.Domain.Contracts.Repositories.Shared;

namespace EFCore.Domain.Contracts.Repositories;

public interface IItemRepository : IBaseRepository<Item>
{
    Task<List<Item>> GetAllItems();
    Task<Item> GetItemById(int id);
    Task<List<Item>> GetItemByName(string name);
}
