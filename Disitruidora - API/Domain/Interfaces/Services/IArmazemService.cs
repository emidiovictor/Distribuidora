using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IArmazemService
    {
        Task<IEnumerable<Armazem>> BuscarTodos();

        Armazem CadastrarArmazem(Armazem arm);

        Task<Armazem> BuscarArmazem(int id);

        Task DeletarArmzem(int id);


        Task<IEnumerable<Armazem>> BuscarArmazemComRegioes();
        Armazem Editar(Armazem arm);
    }
}