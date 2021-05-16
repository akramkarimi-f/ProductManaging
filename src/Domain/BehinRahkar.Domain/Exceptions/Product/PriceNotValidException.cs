using Framework.Core.Exceptions;

namespace BehinRahkar.Domain.Exceptions.Product
{
    public class PriceNotValidException : BadRequestException
    {
        public PriceNotValidException() : base(ErrorCodes.PriceNotValid.Message)
        {

        }
    }
}
