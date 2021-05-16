using System.Threading.Tasks;

namespace BehinRahkar.Domain.Services.Product
{
    public interface IProductDomainService
    {
        Task<bool> CheckForDuplicatedCodeAsync(string code);
    }
}
