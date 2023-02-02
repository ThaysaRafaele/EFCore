using EFCore.Application.Contracts.Services;
using EFCore.Application.Dtos.Client;
using EFCore.Application.Dtos.Order;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly IOrderService _service;
    public OrderController(IOrderService service)
    {
        _service = service;
    }

    // GET: OrderController
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var order = await _service.GetAll();
            return Ok(order);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex}");
        }
    }

    //GET: ClientController/Details/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var client = await _service.GetByIdAsync(id);

            return Ok(client);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex}");
        }
    }

    //// GET: api/Order/555
    [HttpGet("{number}/order-number")]
    public async Task<IActionResult> GetByOrderNumber(int number)
    {
        try
        {
            var order = await _service.GetOrderByNumber(number);
            return Ok(order);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex}");
        }
    }

    // POST: OrderController/Create
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderDto newOder)
    {
        try
        {
            await _service.CreateOrderAsync(newOder);
            return Ok("Registro salvo com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex}");
        }

        return BadRequest("Não foi possível salvar o registro.");
    }


    //// PUT: ClientController/Edit
    [HttpPut]
    public async Task<IActionResult> Update(UpdateOrderDto model)
    {
        try
        {
            await _service.UpdateOrderAsync(model);

            return Ok("Registro alterado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex}");
        }

        return BadRequest("Não foi possível alterar o registro.");
    }

    // POST: ClientController/Delete/5
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteOrderAsync(id);
            return Ok("Registro deletado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex}");
        }

        return BadRequest("Não foi possível deletar o registro.");
    }
}
