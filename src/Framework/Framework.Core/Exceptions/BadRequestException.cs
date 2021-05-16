using System;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Framework.Core.Exceptions
{
    public class BadRequestException : ExceptionBase
    {
        public HttpStatusCode Code { get; } = HttpStatusCode.BadRequest;
        public override string Message { get; } = "Bad Request";

        [JsonConstructor]
        public BadRequestException() : base()
        {
        }

        [JsonConstructor]
        public BadRequestException(string message) : base(message)
        {
        }

        [JsonConstructor]
        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        [JsonConstructor]
        public BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
