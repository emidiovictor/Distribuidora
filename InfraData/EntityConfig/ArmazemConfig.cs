using System.Security.Cryptography.X509Certificates;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.EntityConfig
{
    public class ArmazemConfig : IEntityTypeConfiguration<Armazem>
    {
        public void Configure(EntityTypeBuilder<Armazem> builder)
        {
            builder.ToTable("armazem");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdRegiao).HasColumnName("id_regiao");

            builder.Property(x => x.Nome).HasMaxLength(200).HasColumnName("nome").HasColumnType("varchar");


            builder.Property(x => x.Id).HasColumnName("id");


            builder.Ignore(x => x.CascadeMode);
            
            builder.HasOne(x => x.Regiao)
                .WithMany(x => x.Armazens)
                .HasForeignKey(x => x.IdRegiao);
        }
    }
}