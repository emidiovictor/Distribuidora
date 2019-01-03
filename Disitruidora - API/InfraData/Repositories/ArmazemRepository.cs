using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraData.DataContext;
using Microsoft.EntityFrameworkCore;

namespace InfraData.Repositories
{
    public class ArmazemRepository : BaseRepository<Armazem> , IArmazemRepository
    {
        public ArmazemRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }


        public Task<List<Armazem>> BuscarArmazemERegioes()
        {
            return entry.Include(x => x.Regiao).ToListAsync();
        }
    }
}