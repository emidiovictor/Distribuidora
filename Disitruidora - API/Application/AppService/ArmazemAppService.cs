using System.Collections.Generic;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.AppService
{
    public class ArmazemAppService : IArmazemAppService
    {
        private readonly IArmazemService _armazemService;

        public ArmazemAppService(IArmazemService armazemService)
        {
            _armazemService = armazemService;
        }
        
        public List<Armazem> BuscarTodosArmazens()
        {
            return _armazemService.BuscarTodos();
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