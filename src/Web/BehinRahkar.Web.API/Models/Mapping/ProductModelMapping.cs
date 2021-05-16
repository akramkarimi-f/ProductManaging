using BehinRahkar.Application.Contracts.Dto.Requests.Product;
using BehinRahkar.Web.API.Models.Request.Product;
using BehinRahkar.Application.Contracts.Dto.Requests.Shared;

namespace BehinRahkar.Web.API.Models.Mapping
{
    public static class ProductModelMapping
    {
        public static CreateProductDto ToDto(this CreateProductRequestModel model)
        {
            return new CreateProductDto
            {
                Code = model.Product.Code,
                Name = model.Product.Name,
                Price = model.Product.Price,
                Photo = new AttachmentDto
                {
                    ContentType = model.Photo.ContentType,
                    FileContent = model.Photo.File
                }
            };
        }
    }
}
