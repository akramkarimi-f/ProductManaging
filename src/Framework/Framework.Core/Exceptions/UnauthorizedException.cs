using System;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Framework.Core.Exceptions
{
    public class UnauthorizedException : ExceptionBase
    {
        public HttpStatusCode Code { get; } = HttpStatusCode.Unauthorized;
        public override string Message { get; } = "Unauthorized Exception";

        [JsonConstructor]
        public UnauthorizedException() : base()
        {
        }

        [JsonConstructor]
        public UnauthorizedException(string message) : base(message)
        {
        }

        [JsonConstructor]
        public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        [JsonConstructor]
        public UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
