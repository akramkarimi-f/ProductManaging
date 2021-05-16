using BehinRahkar.Domain.Exceptions.Product;
using Framework.Domain.Model;
using System;
using System.Collections.Generic;

namespace BehinRahkar.Domain.AggregatesModel.ProductAggregate
{
    public class ProductPrice : ValueObject
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double Value { get; set; }
        public DateTime DateTime { get; set; }
        public bool? IsApproved { get; set; }

        public ProductPrice() { }
        public ProductPrice(double price, DateTime dateTime)
        {
            if (price <= 0)
                throw new PriceNotValidException();

            Value = price;
            DateTime = dateTime;
            IsApproved = price > 999 ? true : null;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return DateTime;
        }

        internal bool Approve()
        {
            if (IsApproved == null) IsApproved = true;

            return IsApproved == true;
        }
    }
}
