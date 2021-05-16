using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using aggregate = BehinRahkar.Domain.AggregatesModel.ProductAggregate;

namespace BehinRahkar.Persistence.EF.Configurations.Product
{
    public class ProductFile : EntityTypeConfiguration<aggregate.ProductFile>
    {
        public override void Configure(EntityTypeBuilder<aggregate.ProductFile> builder)
        {
            base.Configure(builder);

            // columns settings
            //builder.HasNoKey();

            // relations
            builder.HasOne<aggregate.Product>()
                .WithOne(prd => prd.Photo)
                .HasForeignKey<aggregate.ProductFile>(file => file.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
