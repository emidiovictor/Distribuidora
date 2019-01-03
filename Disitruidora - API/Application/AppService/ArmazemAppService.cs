using System.Collections.Generic;
using System.Threading.Tasks;
using Application.AppService.Base;
using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using UoW.UoW;

namespace Application.AppService
{
    public class ArmazemAppService : BaseAppService, IArmazemAppService
    {
        private readonly IArmazemService _armazemService;

        public ArmazemAppService(IMapper mapper, IUnitOfWork uoW, IArmazemService armazemService) : base(mapper, uoW)
        {
            _armazemService = armazemService;
        }

        public async Task<IEnumerable<Armazem>> BuscarTodosArmazens()
        {
            return await _armazemService.BuscarTodos();
        }

        public IEnumerable<ArmazemConsultaDto> BuscarTodosArmazensComRegiao()
        {
            var listArmazem = _armazemService.BuscarArmazemComRegioes();
            var armazemDtoList = Mapper.Map<IEnumerable<ArmazemConsultaDto>>(listArmazem);
            return armazemDtoList;
        }

        public Armazem SalvarArmazem(ArmazemCadastroDto armazem)
        {
            var arm = Mapper.Map<Armazem>(armazem);
            _armazemService.CadastrarArmazem(arm);
            Commit();
            return arm;
        }

        public void DeletarArmazem(int id)
        {
            _armazemService.DeletarArmzem(id);
        }

        public void EditarArmazem(ArmazemCadastroDto arm)
        {
            var armazem = Mapper.Map<Armazem>(arm);
            _armazemService.Editar(armazem);
            Commit();
        }


    }
}