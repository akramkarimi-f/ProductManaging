using BehinRahkar.Application.Contracts.Dto.Requests.Shared;

namespace BehinRahkar.Application.Contracts.Dto.Requests.Product
{
    public class CreateProductDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public AttachmentDto Photo { get; set; }
    }
}
