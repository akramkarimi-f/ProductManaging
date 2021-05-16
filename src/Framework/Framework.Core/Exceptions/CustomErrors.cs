using System.Collections.Generic;
using System.Linq;

namespace Framework.Core.Exceptions
{
    public static class CustomErrors
    {
        public static List<Error> Errors { get; private set; } = new List<Error>();
        public static List<string> Modules { get; private set; } = new List<string>();

        public static void Extend(string module, IEnumerable<Error> errors)
        {
            Modules.Add(module);
            Errors.AddRange(errors);
        }

        public static string GetErrorMessage(int code)
        {
            return Errors.FirstOrDefault(err => err.Code == code)?.Message;
        }

        public class Error
        {
            public int Code { get; private set; }
            public string Message { get; private set; }

            public Error(int code, string message)
            {
                Code = code;
                Message = message;
            }
        }
    }
}
