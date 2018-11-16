
using System.IO;
using Domain.Entities;
using InfraData.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InfraData.DataContext
{
    public class DataBaseContext : DbContext
    {

        public DbSet<Armazem> Armazem { get; set; }
        
        public DataBaseContext(DbContextOptions<DataBaseContext> op) : base(op)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArmazemConfig());
            modelBuilder.ApplyConfiguration(new ParticipanteConfig());
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new ProdutoArmazemConfig());
            modelBuilder.ApplyConfiguration(new ItemConfig());
            modelBuilder.ApplyConfiguration(new NotaConfig());
            modelBuilder.ApplyConfiguration(new RegiaoConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            
        }
    }
}