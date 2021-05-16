using BehinRahkar.Application.Contracts.Dto.Responses.Product;
using BehinRahkar.Domain.AggregatesModel.ProductAggregate;

namespace BehinRahkar.Application.Mapping
{
    public static class ProductMapping
    {
        public static ProductListItem ToProductListItem(this Product model)
        {
            return new ProductListItem
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name,
                Price = model.Price?.Value ?? 0,
                PhotoFileName = model.Photo?.FileName,
                ModificationTime = model.ModificationTime
            };
        }
    }
}
