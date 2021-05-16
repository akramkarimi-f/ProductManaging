using System;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Framework.Core.Exceptions
{
    public class ForbiddenException : ExceptionBase
    {
        public HttpStatusCode Code { get; } = HttpStatusCode.Forbidden;
        public override string Message { get; } = "Forbidden Exception";

        [JsonConstructor]
        public ForbiddenException() : base()
        {
        }

        [JsonConstructor]
        public ForbiddenException(string message) : base(message)
        {
        }

        [JsonConstructor]
        public ForbiddenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        [JsonConstructor]
        public ForbiddenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
