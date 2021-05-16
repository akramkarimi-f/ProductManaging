using System;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Framework.Core.Exceptions
{
    public class InternalServerException : ExceptionBase
    {
        public HttpStatusCode Code { get; } = HttpStatusCode.InternalServerError;
        public override string Message { get; } = "Internal Server Error";
        public new string StackTrace { get; }

        [JsonConstructor]
        public InternalServerException() : base()
        {
        }

        [JsonConstructor]
        public InternalServerException(string message) : base(message)
        {
        }

        [JsonConstructor]
        public InternalServerException(string message, string trace) : this(message)
        {
            StackTrace = trace;
        }

        [JsonConstructor]
        public InternalServerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        [JsonConstructor]
        public InternalServerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
