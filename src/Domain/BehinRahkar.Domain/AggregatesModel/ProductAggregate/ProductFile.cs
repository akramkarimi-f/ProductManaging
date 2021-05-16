using BehinRahkar.Domain.Exceptions;
using Framework.Domain.Model;
using System.Collections.Generic;

namespace BehinRahkar.Domain.AggregatesModel.ProductAggregate
{
    public class ProductFile : ValueObject
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string FileName { get; set; }
        public FileType FileType { get; set; }

        public ProductFile() { }
        public ProductFile(string fileName, FileType fileType)
        {
            // validation
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentIsNullOrEmptyException(nameof(fileName));

            FileName = fileName;
            FileType = fileType;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FileName;
        }
    }
}
