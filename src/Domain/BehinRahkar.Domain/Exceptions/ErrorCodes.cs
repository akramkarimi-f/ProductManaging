using Framework.Core.Exceptions;
using System.Collections.Generic;
using System.Net;

namespace BehinRahkar.Domain.Exceptions
{
    public static class ErrorCodes
    {
        // 1000 - 1999
        public static CustomErrors.Error ArgumentIsNullOrEmpty { get; } = new CustomErrors.Error(1000, "{0} can not be null or empty.");
        public static CustomErrors.Error PriceNotValid { get; } = new CustomErrors.Error(1011, "The product's price should be higher than zero.");
        public static CustomErrors.Error ProductCodeIsDuplicated { get; } = new CustomErrors.Error(1012, "Product Code is duplicated.");


        public static IEnumerable<CustomErrors.Error> Errors { get; private set; }

        static ErrorCodes()
        {
            Errors = GetErrors();

            CustomErrors.Extend("Global", Errors);
        }

        private static IEnumerable<CustomErrors.Error> GetErrors()
        {
            var validTypeName = typeof(CustomErrors.Error).Name;

            foreach (var prop in typeof(ErrorCodes).GetProperties())
            {
                if (prop.PropertyType.Name != validTypeName)
                    continue;

                var error = (CustomErrors.Error)prop.GetValue(null, null);

                yield return new CustomErrors.Error(error.Code, error.Message);
            }
        }
    }
}
