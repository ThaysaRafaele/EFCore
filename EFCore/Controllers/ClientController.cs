using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IEFCoreRepository _repository;
        public ClientController(IEFCoreRepository repo)
        {
            _repository = repo;
        }

        // GET: ClientController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var client = await _repository.GetAllClients(true);

                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // GET: ClientController/Details/5
        [HttpGet("GetClientById")]
        public async Task<IActionResult> GetClientById(int id)
        {
            try
            {
                var client = await _repository.GetClientById(id);

                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // GET: ClientController/GetByName/name
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var client = await _repository.GetClientByName(name);

                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // POST: ClientController/Post
        [HttpPost]
        public async Task<IActionResult> Create(Client modelClient)
        {
            try
            {
                _repository.Add(modelClient);

                if (await _repository.SaveChangeAsync())
                    return Ok("Registro salvo com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }

            return BadRequest("Não foi possível salvar o registro.");
        }

        // PUT: ClientController/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Client model)
        {
            try
            {
                var client = await _repository.GetClientById(id);

                if (client != null)
                {
                    _repository.Update(model);

                    if (await _repository.SaveChangeAsync())
                        return Ok("Registro alterado com sucesso!");
                }                
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
                var client = await _repository.GetClientById(id);
                if (client != null)
                {
                    _repository.Delete(client);

                    if (await _repository.SaveChangeAsync())
                        return Ok("Registro deletado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }

            return BadRequest("Não foi possível deletar o registro.");
        }
    }
}
