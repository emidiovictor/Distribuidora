using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IArmazemRepository : IBaseRepository<Armazem>
    {
        IEnumerable<Armazem> BuscarArmazemERegioes();
    }
}