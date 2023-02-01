﻿using EFCore.Domain;
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
                return Ok(new Client());
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        // GET: ClientController/Details/5
        //[HttpGet("{id}", Name = "Details")]
        //public ActionResult Details(int id)
        //{
        //    return Ok("value");
        //}

        //// GET: ClientController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: ClientController/Post
        [HttpPost]
        public ActionResult Create(Client modelClient)
        {
            try
            {
                _context.Clients.Add(modelClient);
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

        // PUT: ClientController/Edit/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, Client model)
        {
            try
            {
                if(_context.Clients
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Id == id) != null)
                {
                    _context.Clients.Update(model);
                    _context.SaveChanges();
                    return Ok("Funcionou");
                }

                //var client = new Client
                //{
                //    Id = id,
                //    Name = "Cliente Teste Alterado",
                //    Email = "testeAlterado@email.com",
                //    Orders = new List<Order>
                //    {
                //        new Order { Id = 1, OrderNumber = 12 },
                //        new Order { Id = 2, OrderNumber = 123 }
                //    }
                //};

                return Ok("Não Encontrado");
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
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
