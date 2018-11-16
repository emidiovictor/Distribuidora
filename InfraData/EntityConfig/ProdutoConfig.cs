using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace InfraData.EntityConfig
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produtos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Custo).HasColumnName("custo").IsRequired();

            builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(200).HasColumnType("varchar").IsRequired();

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(200).HasColumnType("varchar").IsRequired();

            builder.Property(x => x.PrecoVenda).HasColumnName("preco_venda").IsRequired();

            builder.Ignore(x => x.CascadeMode);
        }
    }
}