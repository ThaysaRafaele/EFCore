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

        private readonly Context _context;
        public OrderController(Context context)
        {
            _context = context;
        }

        // GET: OrderController
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                return Ok(new Order());
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // GET: OrderController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: OrderController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: OrderController/Create
        [HttpPost]
        public ActionResult Create(Order model)
        {
            try
            {
                _context.Orders.Add(model);
                _context.SaveChanges();

                return Ok("Funcionou");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // GET: OrderController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // PUT: OrderController/Edit/5
        [HttpPut]
        public ActionResult Edit(int id, Order model)
        {
            try
            {
                if (_context.Orders
                    .AsNoTracking()
                    .FirstOrDefault(o => o.Id == id) != null)
                {
                    _context.Update(model);
                    _context.SaveChanges();
                    return Ok("Funcionou");
                }

                return Ok("Não encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // GET: OrderController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: OrderController/Delete/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
