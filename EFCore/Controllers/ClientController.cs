using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly Context _context;
        public ClientController(Context context)
        {
            _context = context;
        }

        // GET: ClientController
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // GET: ClientController/Details/5
        [HttpGet("{id}", Name = "Details")]
        public ActionResult Details(int id)
        {
            return Ok("value");
        }

        //// GET: ClientController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: ClientController/Post
        [HttpPost]
        public ActionResult Create()
        {
            try
            {
                var client = new Client
                {
                    Name = "Cliente Teste",
                    Email = "teste@email.com",
                    Orders = new List<Order>
                    {
                        new Order { OrderNumber = 0123 },
                        new Order { OrderNumber = 01234 }
                    }
                };

                _context.Clients.Add(client);
                _context.SaveChanges();

                return Ok("Funcionou");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        //// GET: ClientController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: ClientController/Edit/5
        [HttpPut("{id}")]
        public ActionResult Update(int id)
        {
            try
            {
                var client = new Client
                {
                    Id = id,
                    Name = "Cliente Teste Alterado",
                    Email = "testeAlterado@email.com",
                    Orders = new List<Order>
                    {
                        new Order { Id = 1, OrderNumber = 12 },
                        new Order { Id = 2, OrderNumber = 123 }
                    }
                };

                _context.Clients.Update(client);
                _context.SaveChanges();

                return Ok("Funcionou");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        //// GET: ClientController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ClientController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
