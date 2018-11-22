﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmazemController : ControllerBase
    {
        private readonly IArmazemAppService _armazemAppService;

        public ArmazemController(IArmazemAppService armazemAppService)
        {
            _armazemAppService = armazemAppService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var dados = _armazemAppService.BuscarTodosArmazens();

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
}