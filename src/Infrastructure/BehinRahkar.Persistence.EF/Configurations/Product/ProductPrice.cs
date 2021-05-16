using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using aggregate = BehinRahkar.Domain.AggregatesModel.ProductAggregate;

namespace BehinRahkar.Persistence.EF.Configurations.Product
{
    public class ProductPrice : EntityTypeConfiguration<aggregate.ProductPrice>
    {
        public override void Configure(EntityTypeBuilder<aggregate.ProductPrice> builder)
        {
            base.Configure(builder);

            // columns settings
            //builder.HasNoKey();

            // relations
            builder.HasOne<aggregate.Product>()
                .WithOne(prd => prd.Price)
                .HasForeignKey<aggregate.ProductPrice>(price => price.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
