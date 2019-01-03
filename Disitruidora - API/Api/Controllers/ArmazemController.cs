
using System.Threading.Tasks;
using Api.Controllers.Base;
using Application.Dtos;
using Application.Interfaces;
using Domain.Interfaces.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ArmazemController : ApiController
    {
        private readonly IArmazemAppService _armazemAppService;

        public ArmazemController(INotificationHandler notifications, IArmazemAppService armazemAppService) : base(notifications)
        {
            _armazemAppService = armazemAppService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var armazensConsultaDtos = await _armazemAppService.BuscarTodosArmazensComRegiao();
            return Ok(armazensConsultaDtos);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarAsync(ArmazemCadastroDto dto)
        {
            var result = await _armazemAppService.SalvarArmazem(dto);
            return Response(result);
        }

       
    }

   
}