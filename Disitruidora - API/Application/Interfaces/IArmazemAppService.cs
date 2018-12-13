using System.Collections.Generic;
using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IArmazemAppService
    {

        IEnumerable<Armazem> BuscarTodosArmazens();
        IEnumerable<ArmazemConsultaDto> BuscarTodosArmazensComRegiao();

        Armazem SalvarArmazem(ArmazemCadastroDto armazem);

        void DeletarArmazem(int id);


        void EditarArmazem(ArmazemCadastroDto arm);
    }
}