using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IArmazemService
    {
        List<Armazem> BuscarTodos();

        void CadastrarArmazem(Armazem arm);

        Armazem BuscarArmazem(int id);

        void DeletarArmzem(int id);
    }
}