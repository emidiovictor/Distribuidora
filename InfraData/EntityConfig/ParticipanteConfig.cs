using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.EntityConfig
{
    public class ParticipanteConfig : IEntityTypeConfiguration<Participante>
    {
        public void Configure(EntityTypeBuilder<Participante> builder)
        {
            builder.ToTable("particiapntes");

            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(200).HasColumnType("varchar").IsRequired();

            builder.Property(x => x.Endereco).HasColumnName("endereco").HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Property(x => x.IdRegiao).HasColumnName("id_regiao");

            builder.Ignore(x => x.CascadeMode);
            builder.HasOne(x => x.Regiao)
                .WithMany(x => x.Participantes)
                .HasForeignKey(x => x.IdRegiao);
            
            
            builder.Ignore(x => x.CascadeMode);
        }
        
        
    }
}