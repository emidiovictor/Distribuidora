using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IArmazemService
    {
        IEnumerable<Armazem> BuscarTodos();

        Armazem CadastrarArmazem(Armazem arm);

        Armazem BuscarArmazem(int id);

        void DeletarArmzem(int id);


        IEnumerable<Armazem> BuscarArmazemComRegioes();
        Armazem Editar(Armazem arm);
    }
}