using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using aggregate = BehinRahkar.Domain.AggregatesModel.ProductAggregate;

namespace BehinRahkar.Persistence.EF.Configurations.Product
{
    public class Product : EntityTypeConfiguration<aggregate.Product>
    {
        public override void Configure(EntityTypeBuilder<aggregate.Product> builder)
        {
            base.Configure(builder);

            // columns settings

            // relations
        }
    }
}
