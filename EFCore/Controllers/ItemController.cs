using EFCore.Application.Contracts.Services;
using EFCore.Application.Dtos.Item;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : Controller
{
    private readonly IItemService _service;
    public ItemController(IItemService service)
    {
        _service = service;
    }

    // GET: ItemController
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var item = await _service.GetAll();
            return Ok(item);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex}");
        }
    }

    //// GET: api/Item/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemById(int id)
    {
        try
        {
            var item = await _service.GetByIdAsync(id);
            return Ok(item);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex}");
        }
    }

    //// GET: api/Item/555
    [HttpGet("{name}/name")]
    public async Task<IActionResult> GetByItemName(string name)
    {
        try
        {
            var item = await _service.GetItemByName(name);
            return Ok(item);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex}");
        }
    }

    // POST: ItemController/Create
    [HttpPost]
    public async Task<IActionResult> Create(CreateItemDto newItem)
    {
        try
        {
            await _service.CreateItemAsync(newItem);
            return Ok("Registro salvo com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex}");
        }

        return BadRequest("Não foi possível salvar o registro.");
    }

    // PUT: ItemController/Edit/5
    [HttpPut]
    public async Task<IActionResult> Edit(UpdateItemDto model)
    {
        try
        {
            await _service.UpdateItemAsync(model);

            return Ok("Registro alterado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex}");
        }
    }

    // POST: ItemController/Delete/5
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteItemAsync(id);
            return Ok("Registro deletado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex}");
        }

        return BadRequest("Não foi possível deletar o registro.");
    }
}
