using System;
using System.Runtime.Serialization;

namespace Framework.Core.Exceptions
{
    public class ExceptionBase : Exception
    {
        public override string Message { get; } = "An error occurred.";
        public ExceptionBase() : base()
        {
        }

        public ExceptionBase(string message) : base(message)
        {
        }

        public ExceptionBase(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ExceptionBase(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
