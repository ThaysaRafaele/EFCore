using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IEFCoreRepository _repo;
        public OrderController(IEFCoreRepository repo)
        {
            _repo = repo;
        }

        // GET: OrderController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var order = await _repo.GetAllOrders();
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var order = await _repo.GetOrderById(id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // POST: OrderController/Create
        [HttpPost]
        public async Task<IActionResult> Create(Order model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangeAsync())
                    return Ok("Registro salvo com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }

            return BadRequest("Não foi possível salvar o registro.");
        }

        // PUT: OrderController/Edit/5
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Order model)
        {
            try
            {
                var order = await _repo.GetOrderById(id);
                
                if (order != null)
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

        // POST: OrderController/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {            
            try
            {  
                var order = await _repo.GetOrderById(id);              
                if (order != null)
                {
                    _repo.Delete(order);

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
