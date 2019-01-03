using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IArmazemAppService
    {

        Task<IEnumerable<Armazem>> BuscarTodosArmazens();
        IEnumerable<ArmazemConsultaDto> BuscarTodosArmazensComRegiao();

        Armazem SalvarArmazem(ArmazemCadastroDto armazem);

        void DeletarArmazem(int id);


        void EditarArmazem(ArmazemCadastroDto arm);
    }
}