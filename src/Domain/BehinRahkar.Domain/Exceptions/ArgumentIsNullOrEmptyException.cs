using Framework.Core.Exceptions;

namespace BehinRahkar.Domain.Exceptions
{
    public class ArgumentIsNullOrEmptyException : BadRequestException
    {
        public ArgumentIsNullOrEmptyException(string argumentName = "Argument")
            : base(string.Format(ErrorCodes.ArgumentIsNullOrEmpty.Message, argumentName))
        {

        }
    }
}
