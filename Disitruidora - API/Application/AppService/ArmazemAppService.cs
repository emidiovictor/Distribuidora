using System.Collections.Generic;
using Application.AppService.Base;
using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.AppService
{
    public class ArmazemAppService : BaseAppService, IArmazemAppService
    {
        private readonly IArmazemService _armazemService;

        public ArmazemAppService(IMapper mapper, IArmazemService armazemService) : base(mapper)
        {
            _armazemService = armazemService;
        }
        
        public IEnumerable<Armazem> BuscarTodosArmazens()
        {
            return _armazemService.BuscarTodos();
        }

        public IEnumerable<ArmazemConsultaDto> BuscarTodosArmazensComRegiao()
        {
            var listArmazem= _armazemService.BuscarArmazemComRegioes();

            var armazemDtoList = mapper.Map<IEnumerable<ArmazemConsultaDto>>(listArmazem);
            return armazemDtoList;
        }

        public void SalvarArmazem(Armazem armazem)
        {
            throw new System.NotImplementedException();
        }

        public void DeletarArmazem(Armazem arm)
        {
            throw new System.NotImplementedException();
        }

        public void EditarArmazem(Armazem arm)
        {
            throw new System.NotImplementedException();
        }

       
    }
}