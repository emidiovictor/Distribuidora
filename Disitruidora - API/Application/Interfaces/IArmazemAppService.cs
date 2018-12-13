using System.Collections.Generic;
using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IArmazemAppService
    {

        IEnumerable<Armazem> BuscarTodosArmazens();
        IEnumerable<ArmazemConsultaDto> BuscarTodosArmazensComRegiao();

        void SalvarArmazem(Armazem armazem);

        void DeletarArmazem(Armazem arm);

    
        void EditarArmazem(Armazem arm);

    }
}