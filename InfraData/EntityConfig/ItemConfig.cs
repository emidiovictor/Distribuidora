using System.Security.Cryptography.X509Certificates;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.EntityConfig
{
    public class ItemConfig : IEntityTypeConfiguration<Item>

    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("item");

            builder.Property(x => x.IdNota).HasColumnName("id_nota");

            builder.Property(x => x.IdProduto).HasColumnName("id_produto");

            builder.Property(x => x.Quantidade).HasColumnName("quantidade").HasColumnType("bigint");

            builder.HasOne(x => x.Nota)
                .WithMany(x => x.ListaItem)
                .HasForeignKey(x => x.IdNota);

            builder.HasOne(x => x.Produto)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.IdProduto);
            
            
            builder.Ignore(x => x.CascadeMode);
        }
    }
}