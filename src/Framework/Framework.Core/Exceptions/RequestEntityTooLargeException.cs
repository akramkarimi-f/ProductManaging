using System;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Framework.Core.Exceptions
{
    public class RequestEntityTooLargeException : ExceptionBase
    {
        public HttpStatusCode Code { get; } = HttpStatusCode.RequestEntityTooLarge;
        public override string Message { get; } = "Request Entity Is Too Large.";

        [JsonConstructor]
        public RequestEntityTooLargeException() : base()
        {
        }

        [JsonConstructor]
        public RequestEntityTooLargeException(string message) : base(message)
        {
        }

        [JsonConstructor]
        public RequestEntityTooLargeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        [JsonConstructor]
        public RequestEntityTooLargeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
