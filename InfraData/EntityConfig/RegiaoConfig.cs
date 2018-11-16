using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.EntityConfig
{
    public class RegiaoConfig : IEntityTypeConfiguration<Regiao>
    {
        public void Configure(EntityTypeBuilder<Regiao> builder)
        {

            builder.ToTable("regioes");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.CoordenadaX).IsRequired().HasColumnName("coordenada_x");
            builder.Property(x => x.CoordenadaY).IsRequired().HasColumnName("coordenada_y");

            builder.Property(x => x.Nome).HasColumnName("nome");

            builder.Ignore(x => x.CascadeMode);
            
        }
    }
}