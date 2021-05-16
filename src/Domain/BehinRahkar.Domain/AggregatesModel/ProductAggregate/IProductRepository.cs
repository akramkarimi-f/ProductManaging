using Framework.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BehinRahkar.Domain.AggregatesModel.ProductAggregate
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<bool> ProductCodeIsDuplicateAsync(string code);


        Task AddAsync(Product product);
    }
}
