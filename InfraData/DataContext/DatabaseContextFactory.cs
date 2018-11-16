using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InfraData.DataContext
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
    {
        public DataBaseContext CreateDbContext(string[] args)
        {
            const string connectionString =
                "User ID=postgres;Password=masterkey;Host=localhost;Port=5432;Database=distri;Pooling=true;";
            
            var builder = new DbContextOptionsBuilder<DataBaseContext>();
            builder.UseNpgsql(connectionString,
                options => options.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));

            
            return new DataBaseContext(builder.Options);
        }
    }
}