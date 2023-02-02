using EFCore.Application.Dtos.Item;

namespace EFCore.Application.Contracts.Services;

public interface IItemService
{ 
    Task CreateItemAsync(CreateItemDto newItem);
}
