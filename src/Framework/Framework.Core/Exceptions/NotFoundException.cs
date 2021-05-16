using System;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Framework.Core.Exceptions
{
    public class NotFoundException : ExceptionBase
    {
        public HttpStatusCode Code { get; } = HttpStatusCode.NotFound;
        public override string Message { get; } = "Not Found";

        [JsonConstructor]
        public NotFoundException() : base()
        {
        }

        [JsonConstructor]
        public NotFoundException(string message) : base(message)
        {
        }

        [JsonConstructor]
        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        [JsonConstructor]
        public NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
