using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.EntityConfig
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");

            builder.Property(x => x.Login).HasMaxLength(20).IsRequired().HasColumnName("nome").HasColumnType("varchar");
            builder.Property(x => x.Nome).HasMaxLength(20).HasColumnName("nome").IsRequired().HasColumnType("varchar");
            builder.Property(x => x.Senha).HasMaxLength(20).IsRequired().HasColumnName("senha").HasColumnType("varchar");

            builder.Ignore(x => x.CascadeMode);
        }
    }
}