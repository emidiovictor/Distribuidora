using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraData.DataContext;

namespace InfraData.Repositories
{
    public class ArmazemRepository : BaseRepository<Armazem> , IArmazemRepository
    {
        public ArmazemRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }
    }
}