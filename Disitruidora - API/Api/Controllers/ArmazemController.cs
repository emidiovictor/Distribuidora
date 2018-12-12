using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ArmazemController : Controller
    {
        private readonly IArmazemAppService _armazemAppService;

        public ArmazemController(IArmazemAppService armazemAppService)
        {
            _armazemAppService = armazemAppService;
        }

        [HttpGet("tetete")]
        [ProducesResponseType(typeof(List<Armazem>), 200)]
        public IActionResult GetAll()
        {
            var dados = _armazemAppService.BuscarTodosArmazens().ToList();
            var teste = new List<Teste>();

            dados.ForEach(x =>
           {
               teste.Add(new Teste()
               {
                   Nome = x.Nome,
                   Id = x.Id
               });
           });
            return Ok(dados);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Teste
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}