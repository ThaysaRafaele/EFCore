using EFCore.Application.Dtos.Item;

namespace EFCore.Application.Contracts.Services;

public interface IItemService
{ 
    Task CreateItemAsync(CreateItemDto newItem);
    Task<List<ItemDto>> GetAll();
    Task<ItemDto> GetByIdAsync(int id);
    Task<List<ItemDto>> GetItemByName(string name);
    Task UpdateItemAsync(UpdateItemDto updateItem);
    Task DeleteItemAsync(int id);

}
