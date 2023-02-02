using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IEFCoreRepository _repo;
        public ItemController(IEFCoreRepository repo)
        {
            _repo = repo;
        }

        // GET: ItemController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var item = await _repo.GetAllItems(true);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // GET: api/Item/5
        [HttpGet("GetItemById")]
        public async Task<IActionResult> GetItemById(int id)
        {
            try
            {
                var item = await _repo.GetItemById(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // GET: api/Item/555
        [HttpGet("GetByItemName")]
        public async Task<IActionResult> GetByItemName(string name)
        {
            try
            {
                var item = await _repo.GetItemByName(name);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // POST: ItemController/Create
        [HttpPost]
        public async Task<IActionResult> Create(Item model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangeAsync())
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
        public async Task<IActionResult> Edit(int id, Item model)
        {
            try
            {
                var item = await _repo.GetItemById(id);

                if (item != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangeAsync())
                        return Ok("Registro alterado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }

            return BadRequest("Não foi possível alterar o registro.");
        }

        // POST: ItemController/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await _repo.GetItemById(id);
                if (item != null)
                {
                    _repo.Delete(item);

                    if (await _repo.SaveChangeAsync())
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
