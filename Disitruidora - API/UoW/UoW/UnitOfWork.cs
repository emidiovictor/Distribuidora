using InfraData.DataContext;

namespace UoW.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            var success = false;

            try
            {
                success = _context.SaveChanges() > 0;
            }
            catch (System.Exception ex)
            {
                var teste = ex;
                throw;
            }

            return success;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}