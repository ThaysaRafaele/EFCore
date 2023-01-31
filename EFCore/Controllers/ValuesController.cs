using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        public readonly Context _context;
        public ValuesController(Context context)
        {
            _context = context;
        }

        [HttpGet("{nameClient, email}")]
        public ActionResult Get(string nameClient, string email)
        {
            var client = new Client { Name = nameClient, Email = email };

            _context.Clients.Add(client);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Client { Name = "Anna Júlia", Email = "annajulia@gmail.com" },
                new Client { Name = "Tayler Gomes", Email = "tayler2019@gmail.com" },
                new Client { Name = "Davi Batista", Email = "batista_dv@gmail.com" }
            );
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public ActionResult Get()
        {
            var listClient = _context.Clients.ToList();

            return Ok(listClient);
        }

        [HttpGet("filter/{name}")]
        public ActionResult GetFilter(string name)
        {
            var listClient = _context.Clients
                                .Where(e => e.Name.Contains(name))
                                .ToList();

            return Ok(listClient);
        }

        [HttpGet("update/{name}")]
        public ActionResult Update(string name)
        {
            var client = _context.Clients
                            .Where(e => e.Id == 3)
                            .FirstOrDefault();

            client.Name = "Thaysa Rafaele Gomes";

            _context.SaveChanges();

            return Ok();
        }

        //// POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        //// PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        //// DELETE api/values/5
        [HttpGet("Delete/{id}")]
        public void Delete(int id)
        {
            var client = _context.Clients
                                .Where(x => x.Id == id)
                                .Single();
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }
    };
}