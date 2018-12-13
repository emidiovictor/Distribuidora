using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.EntityConfig
{
    public class EnderecoConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("enderecos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Bairro).HasColumnName("bairro").HasMaxLength(100).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.Cep).HasColumnName("cep").HasMaxLength(14).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.Cidade).HasColumnName("cidade").HasMaxLength(100).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.Complemento).HasColumnName("complemento").HasMaxLength(100).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.Estado).HasColumnName("estado").HasMaxLength(100).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.Numero).HasColumnName("numero").HasMaxLength(20).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.Referencia).HasColumnName("referencia").HasMaxLength(100).HasColumnType("varchar").IsRequired();
            builder.Property(x => x.Rua).HasColumnName("rua").HasMaxLength(200).HasColumnType("varchar").IsRequired();

            builder.Ignore(x => x.CascadeMode);
        }
    }
}