using BehinRahkar.Domain.AggregatesModel.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BehinRahkar.Persistence.EF.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EfDbContext _dbContext;
        public ProductRepository(EfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _dbContext.Products.ToArrayAsync();
        }

        public async Task<bool> ProductCodeIsDuplicateAsync(string code)
        {
            return await _dbContext.Products.AnyAsync(x => x.Code == code);
        }


        public async Task AddAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
