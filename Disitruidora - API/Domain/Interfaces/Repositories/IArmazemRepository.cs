using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IArmazemRepository : IBaseRepository<Armazem>
    {
        Task<List<Armazem>> BuscarArmazemERegioes();
    }
}