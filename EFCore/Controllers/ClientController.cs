using EFCore.Application.Contracts.Services;
using EFCore.Application.Dtos.Client;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : Controller
{
    private readonly IClientService _service;
    public ClientController(IClientService service)
    {
        _service = service;
    }

    // GET: ClientController
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var client = await _service.GetAllAsync();

            return Ok(client);
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

    // GET: ClientController/GetByName/name
    [HttpGet("{name}/name")]
    public async Task<IActionResult> Get(string name)
    {
        try
        {
            var client = await _service.GetByNameAsync(name);

            return Ok(client);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex}");
        }
    }

    // POST: ClientController/Post
    [HttpPost]
    public async Task<IActionResult> Create(CreateClienteDto modelClient)
    {
        try
        {
            await _service.CreateClientAsync(modelClient);
            return Ok("Registro salvo com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex}");
        }

        return BadRequest("Não foi possível salvar o registro.");
    }

    //// PUT: ClientController/Edit/5
    [HttpPut]
    public async Task<IActionResult> Update(UpdateClienteDto model)
    {
        try
        {
            await _service.UpdateClientAsync(model);

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
            await _service.DeleteClientAsync(id);
            return Ok("Registro deletado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex}");
        }

        return BadRequest("Não foi possível deletar o registro.");
    }
}
