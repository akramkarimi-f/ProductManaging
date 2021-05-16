using BehinRahkar.Application.Contracts.Dto.Requests.Product;
using BehinRahkar.Application.Contracts.Dto.Responses.Product;
using Framework.Core.Ioc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BehinRahkar.Application.Contracts.Services.Product
{
    public interface IProductService : ITransientDependency
    {
        Task<IEnumerable<ProductListItem>> GetAllProductsAsync();
        Task<bool> ProductCodeIsDuplicateAsync(string code);

        Task CreateProductAsync(CreateProductDto product);
        //Task ApprovePrice(ApprovePrice approvePrice);
    }
}
