using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.EntityConfig
{
    public class ProdutoArmazemConfig : IEntityTypeConfiguration<ProdutoArmazem>
    {
        public void Configure(EntityTypeBuilder<ProdutoArmazem> builder)
        {
            builder.ToTable("produto_armazem");

            builder.HasKey(x => x.Id);
            
            
            builder.Property(x => x.Quantidade).IsRequired().HasColumnType("integer").HasColumnName("quantidade");

            builder.Ignore(x => x.CascadeMode);

            builder.HasOne(x => x.Armazem)
                .WithMany(x => x.ProdutoArmazem)
                .HasForeignKey(x => x.IdArmazem);

            builder.HasOne(x => x.Produto)
                .WithMany(x => x.ProdutosArmazens)
                .HasForeignKey(x => x.IdProduto);
            
            builder.Ignore(x => x.CascadeMode);

        }
    }
}