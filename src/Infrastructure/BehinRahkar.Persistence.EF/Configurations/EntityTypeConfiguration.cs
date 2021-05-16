using BehinRahkar.Infrastructure.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace BehinRahkar.Persistence.EF.Configurations
{
    public class EntityTypeConfiguration<TEntity>
        : IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            var aggregateName = typeof(TEntity).Namespace.Split('.').LastOrDefault();
            var schema = aggregateName.Substring(0, aggregateName.Length - "Aggregate".Length);
            builder.ToTable(typeof(TEntity).Name.ToPluralString(), schema);
        }
    }
}
