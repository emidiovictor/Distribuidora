using System.Security.Cryptography.X509Certificates;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.EntityConfig
{
    public class NotaConfig : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.ToTable("notas");

            builder.Property(x => x.IdParticipante).HasColumnName("id_particiapnte");

            builder.Property(x => x.IdUsuario).HasColumnName("id_usuario");

            builder.Property(x => x.TipoNota).HasColumnName("tipo_nota").IsRequired().HasColumnType("integer");

            builder.HasOne(x => x.Participante)
                .WithMany(x => x.Nota)
                .HasForeignKey(x => x.IdParticipante);

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Notas)
                .HasForeignKey(x => x.IdUsuario);

            builder.Ignore(x => x.CascadeMode);
        }
    }
}