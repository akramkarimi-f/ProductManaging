using BehinRahkar.Web.API.Models.Shared.Product;

namespace BehinRahkar.Web.API.Models.Request.Product
{
    public class CreateProductRequestModel
    {
        public CreateProductModel Product { get; set; }
        public UploadProductFileModel Photo { get; set; }
    }
}
