using Framework.Core.Exceptions;

namespace BehinRahkar.Domain.Exceptions.Product
{
    public class ProductCodeIsDuplicatedException : BadRequestException
    {
        public ProductCodeIsDuplicatedException() : base(ErrorCodes.ProductCodeIsDuplicated.Message)
        {

        }
    }
}
