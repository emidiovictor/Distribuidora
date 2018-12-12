using System.Collections.Generic;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IArmazemAppService
    {

        List<Armazem> BuscarTodosArmazens();

        void SalvarArmazem(Armazem armazem);

        void DeletarArmazem(Armazem arm);


        void EditarArmazem(Armazem arm);

    }
}