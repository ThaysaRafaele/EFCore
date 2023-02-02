using AutoMapper;
using EFCore.Application.Contracts.Services;
using EFCore.Application.Dtos.Item;
using EFCore.Domain.Contracts.Repositories;
using EFCore.Domain.Entities;

namespace EFCore.Application.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;
    public ItemService(IItemRepository itemRepository,
                              IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }

    public async Task CreateItemAsync(CreateItemDto newItem)
    {
        try
        {
            var item = _mapper.Map<Item>(newItem);
            _itemRepository.Add(item);
            await _itemRepository.SaveChangeAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
