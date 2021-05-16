using System;

namespace BehinRahkar.Application.Contracts.Dto.Responses.Product
{
    public class ProductListItem
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string PhotoFileName { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}
