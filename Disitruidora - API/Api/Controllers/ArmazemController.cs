using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            var armazensConsultaDtos = _armazemAppService.BuscarTodosArmazensComRegiao();
            return Ok(armazensConsultaDtos);
        }

        // GET api/values/5
        [HttpPost]
        public IActionResult Salvar(ArmazemCadastroDto dto)
        {
            var result = _armazemAppService.SalvarArmazem(dto);
            return Ok(result);
        }

       
    }

   
}