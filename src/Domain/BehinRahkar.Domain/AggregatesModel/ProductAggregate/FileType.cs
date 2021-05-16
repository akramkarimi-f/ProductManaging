using Framework.Domain.Models;

namespace BehinRahkar.Domain.AggregatesModel.ProductAggregate
{
    public class FileType
    : Enumeration
    {
        public static FileType Image => new(1, nameof(Image));

        public FileType(int id, string name)
            : base(id, name)
        {
        }
    }

}
