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

    public async Task DeleteItemAsync(int id)
    {
        try
        {
            var item = await _itemRepository.GetByIdAsync(id);

            if (item is null) throw new Exception("Registro não encontrado");

            _itemRepository.Delete(item);
            await _itemRepository.SaveChangeAsync();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<ItemDto>> GetAll()
    {
        try
        {
            var items = await _itemRepository.GetAllItems();
            var itemsDto = _mapper.Map<List<ItemDto>>(items);

            return itemsDto;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ItemDto> GetByIdAsync(int id)
    {
        try
        {
            var item = await _itemRepository.GetItemById(id);
            var itemDto = _mapper.Map<ItemDto>(item);

            return itemDto;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<ItemDto>> GetItemByName(string name)
    {
        try
        {
            var items = await _itemRepository.GetItemByName(name);
            var itemsDto = _mapper.Map<List<ItemDto>>(items);

            return itemsDto;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task UpdateItemAsync(UpdateItemDto updateItem)
    {
        try
        {
            var item = await _itemRepository.GetItemById(updateItem.Id);
            updateItem.Id = item.Id;

            if (item is null) throw new Exception("Registro não encontrado");


            _mapper.Map(updateItem, item);
            _itemRepository.Update(item);
            await _itemRepository.SaveChangeAsync();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
