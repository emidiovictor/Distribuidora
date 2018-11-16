using Domain.Entities;
using Domain.Repositories;
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