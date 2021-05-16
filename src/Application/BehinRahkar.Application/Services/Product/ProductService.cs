using BehinRahkar.Application.Contracts.Dto.Requests.Product;
using BehinRahkar.Application.Contracts.Dto.Responses.Product;
using BehinRahkar.Application.Contracts.Services.Product;
using BehinRahkar.Application.Helper.Attachment;
using BehinRahkar.Application.Mapping;
using BehinRahkar.Domain.Exceptions.Product;
using BehinRahkar.Domain.Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAggregate = BehinRahkar.Domain.AggregatesModel.ProductAggregate;

namespace BehinRahkar.Application.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly ProductAggregate.IProductRepository _productRepository;
        private readonly IProductDomainService _productDomainService;
        private readonly IAttachmentHelper _attachmentHelper;
        public ProductService(
            ProductAggregate.IProductRepository productRepository,
            IProductDomainService productDomainService,
            IAttachmentHelper attachmentHelper
            )
        {
            _productRepository = productRepository;
            _productDomainService = productDomainService;
            _attachmentHelper = attachmentHelper;
        }

        public async Task CreateProductAsync(CreateProductDto product)
        {
            // validation
            bool codeIsDuplicate = await _productDomainService.CheckForDuplicatedCodeAsync(product.Code);
            if (codeIsDuplicate) throw new ProductCodeIsDuplicatedException();

            // generate new file name
            var photoFileName = _attachmentHelper.GetFileName(product.Photo.ContentType);

            // save product
            var newProduct = new ProductAggregate.Product(product.Code, product.Name, product.Price, photoFileName);
            await _productRepository.AddAsync(newProduct);

            // save attachment
            await _attachmentHelper.SaveFileAsync(product.Photo.FileContent, photoFileName, "/images/products/" + newProduct.Id);
        }

        public async Task<IEnumerable<ProductListItem>> GetAllProductsAsync()
        {
            return (await _productRepository.GetProductsAsync()).Select(x => x.ToProductListItem());
        }

        public Task<bool> ProductCodeIsDuplicateAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
