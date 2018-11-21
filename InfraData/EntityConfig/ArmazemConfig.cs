using System.Security.Cryptography.X509Certificates;
using Domain.Entities;
using InfraData.EntityConfig.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.EntityConfig
{
    public class ArmazemConfig : BaseConfiguration<Armazem>
    {
        public override void Configure(EntityTypeBuilder<Armazem> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdRegiao)
                .HasColumnName("id_regiao");
            builder.Property(x => x.Nome)
                .HasMaxLength(200)
                .HasColumnName("nome")
                .HasColumnType("varchar");
            
            
            builder.Property(x => x.Id).HasColumnName("id");
            builder.HasOne(x => x.Regiao)
                .WithMany(x => x.Armazens)
                .HasForeignKey(x => x.IdRegiao);        }
        }

}