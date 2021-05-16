using BehinRahkar.Domain.Exceptions;
using Framework.Domain.Model;
using System;

namespace BehinRahkar.Domain.AggregatesModel.ProductAggregate
{
    public class Product : AggregateRoot<int>, IModificationAudit
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ProductPrice Price { get; set; }
        public virtual ProductFile Photo { get; set; }
        public bool IsActive { get; set; }
        public string ModifierUserId { get; set; }
        public DateTime ModificationTime { get; set; }

        public Product() { }

        public Product(string code, string name, double price, string photoFileName,
            string modifierId = null)
        {
            // validation
            if (string.IsNullOrEmpty(code)) throw new ArgumentIsNullOrEmptyException(nameof(code));
            if (string.IsNullOrEmpty(name)) throw new ArgumentIsNullOrEmptyException(nameof(name));

            Code = code;
            Name = name;
            Price = new ProductPrice(price, DateTime.Now);
            if (!string.IsNullOrEmpty(photoFileName))
                Photo = new ProductFile(photoFileName, FileType.Image);
            IsActive = Price.IsApproved == true;
            ModifierUserId = modifierId == string.Empty ? null : modifierId;
            ModificationTime = DateTime.Now;
        }

        public bool ApprovePrice()
        {
            if (Price.IsApproved == true) return true;

            if (Price.Approve()) IsActive = true;

            return Price.IsApproved == true;
        }
    }
}
