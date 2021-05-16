using Framework.Core.Ioc;
using Framework.Domain.Model;

namespace Framework.Domain.Repository
{
    public interface IRepository<T> : ITransientDependency
        where T : IAggregateRoot
    {
    }
}