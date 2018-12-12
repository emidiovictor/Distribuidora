using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InfraData.EntityConfig.Shared
{
    public abstract class BaseConfiguration<TEntidade> : IEntityTypeConfiguration<TEntidade>
        where TEntidade : BaseEntity<TEntidade>
    {
        public virtual void Configure(EntityTypeBuilder<TEntidade> builder)
        {
            builder.Ignore(x => x.CascadeMode);
        }
    }
}