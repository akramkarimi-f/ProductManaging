using BehinRahkar.Domain.AggregatesModel.ProductAggregate;
using BehinRahkar.Domain.Exceptions;
using System.Threading.Tasks;

namespace BehinRahkar.Domain.Services.Product
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IProductRepository _productRepository;
        public ProductDomainService(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> CheckForDuplicatedCodeAsync(string code)
        {
            // validation
            if (string.IsNullOrEmpty(code)) throw new ArgumentIsNullOrEmptyException(nameof(code));

            return await _productRepository.ProductCodeIsDuplicateAsync(code);
        }
    }
}
